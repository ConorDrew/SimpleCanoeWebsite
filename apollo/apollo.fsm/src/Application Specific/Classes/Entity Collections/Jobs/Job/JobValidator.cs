using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace Jobs
    {
        // make sure that contact object is valid
        public class JobValidator : BaseValidator
        {
            public void Validate(Job oJob)
            {
                // make sure that contact object is valid
                if (oJob.Errors.Count > 0)
                {
                    foreach (DictionaryEntry de in oJob.Errors)
                        AddCriticalMessage(Conversions.ToString(de.Value));
                }

                if (oJob.PropertyID == 0)
                {
                    AddCriticalMessage("Property not set");
                }

                if (oJob.JobNumber.Trim().Length == 0)
                {
                    AddCriticalMessage("Job Number not set");
                }

                if (oJob.JobTypeID == 0)
                {
                    AddCriticalMessage("Job Type not selected");
                }

                if (Conversions.ToInteger(oJob.FOC) == 0 & Conversions.ToInteger(oJob.OTI) == 0 & Conversions.ToInteger(oJob.POC) == 0)
                {
                    AddCriticalMessage("Payment Method not selected");
                }

                int jobOfWorkIndex = 1;
                foreach (JobOfWorks.JobOfWork jobOfWork in oJob.JobOfWorks)
                {
                    if (jobOfWork.Priority == 0 & App.DB.Job.JobOfWork_Required_Priority(oJob.PropertyID) == true)
                    {
                        AddCriticalMessage("Job Of Work #" + jobOfWorkIndex + " Priority Missing");
                    }

                    int jobOfItemIndex = 1;
                    foreach (JobItems.JobItem jobItem in jobOfWork.JobItems)
                    {
                        if (jobItem.Summary.Trim().Length == 0)
                        {
                            AddCriticalMessage("Job Of Work #" + jobOfWorkIndex + " Job Item #" + jobOfItemIndex + " Summary Missing");
                        }

                        jobOfItemIndex += 1;
                    }

                    int engineerVisitIndex = 1;
                    foreach (EngineerVisits.EngineerVisit engineerVisit in jobOfWork.EngineerVisits)
                    {
                        if (engineerVisit.StatusEnumID == 0)
                        {
                            AddCriticalMessage("Job Of Work #" + jobOfWorkIndex + " Visit #" + engineerVisitIndex + " Status Not Selected");
                        }

                        if (engineerVisit.NotesToEngineer.Trim().Length == 0)
                        {
                            AddCriticalMessage("Job Of Work #" + jobOfWorkIndex + " Visit #" + engineerVisitIndex + " Notes To Engineer Missing");
                        }

                        engineerVisitIndex += 1;
                    }

                    jobOfWorkIndex += 1;
                }

                // If oJob.Assets.Count = 0 Then
                // If ShowMessage("You have not selected any appliances - would you like to continue anyway?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                // Me.AddCriticalMessage("No appliances selected")
                // End If
                // End If

                if (ValidatorMessages.CriticalMessages.Count > 0)
                {
                    throw new ValidationException(this);
                }
            }
        }
    }
}