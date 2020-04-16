// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Jobs.JobValidator
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.EngineerVisits;
using FSM.Entity.JobItems;
using FSM.Entity.JobOfWorks;
using Microsoft.VisualBasic.CompilerServices;
using System.Collections;

namespace FSM.Entity.Jobs
{
    public class JobValidator : BaseValidator
    {
        public void Validate(Job oJob)
        {
            if (oJob.Errors.Count > 0)
            {
                foreach (object error in oJob.Errors)
                    this.AddCriticalMessage(Conversions.ToString((error != null ? (DictionaryEntry)error : new DictionaryEntry()).Value));
            }
            if (oJob.PropertyID == 0)
                this.AddCriticalMessage("Property not set");
            if (oJob.JobNumber.Trim().Length == 0)
                this.AddCriticalMessage("Job Number not set");
            if (oJob.JobTypeID == 0)
                this.AddCriticalMessage("Job Type not selected");
            if (-(oJob.FOC ? 1 : 0) == 0 & -(oJob.OTI ? 1 : 0) == 0 & -(oJob.POC ? 1 : 0) == 0)
                this.AddCriticalMessage("Payment Method not selected");
            int num1 = 1;

            foreach (JobOfWork current1 in oJob.JobOfWorks)
            {
                if (current1.Priority == 0 & App.DB.Job.JobOfWork_Required_Priority(oJob.PropertyID))
                    this.AddCriticalMessage("Job Of Work #" + Conversions.ToString(num1) + " Priority Missing");
                int num2 = 1;
                foreach (JobItem current in current1.JobItems)
                {
                    if (current.Summary.Trim().Length == 0)
                        this.AddCriticalMessage("Job Of Work #" + Conversions.ToString(num1) + " Job Item #" + Conversions.ToString(num2) + " Summary Missing");
                    checked { ++num2; }
                }

                int num3 = 1;

                foreach (EngineerVisit current2 in current1.EngineerVisits)
                {
                    if (current2.StatusEnumID == 0)
                        this.AddCriticalMessage("Job Of Work #" + Conversions.ToString(num1) + " Visit #" + Conversions.ToString(num3) + " Status Not Selected");
                    if (current2.NotesToEngineer.Trim().Length == 0)
                        this.AddCriticalMessage("Job Of Work #" + Conversions.ToString(num1) + " Visit #" + Conversions.ToString(num3) + " Notes To Engineer Missing");
                    checked { ++num3; }
                }

                checked { ++num1; }
            }

            if (this.ValidatorMessages.CriticalMessages.Count > 0)
                throw new ValidationException((BaseValidator)this);
        }
    }
}