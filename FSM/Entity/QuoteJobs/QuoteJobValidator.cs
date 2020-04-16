// Decompiled with JetBrains decompiler
// Type: FSM.Entity.QuoteJobs.QuoteJobValidator
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic.CompilerServices;
using System.Collections;
using System.Data;

namespace FSM.Entity.QuoteJobs
{
    public class QuoteJobValidator : BaseValidator
    {
        public void Validate(QuoteJob qJob, DataView JobItems)
        {
            if (qJob.Errors.Count > 0)
            {
                foreach (object error in qJob.Errors)
                    this.AddCriticalMessage(Conversions.ToString((error != null ? (DictionaryEntry)error : new DictionaryEntry()).Value));
            }
            if (qJob.SiteID == 0)
                this.AddCriticalMessage("* Property not set");
            if (qJob.Reference.Trim().Length == 0)
                this.AddCriticalMessage("*Reference Missing");
            if (!qJob.Exists)
                qJob.SetStatusEnumID = (object)1;
            else if (qJob.StatusEnumID == 0)
                this.AddCriticalMessage("*Status Missing");
            if (!Versioned.IsNumeric((object)qJob.PartsAndProductsMarkup))
                this.AddCriticalMessage("*Parts And Products Markup must be Numeric");
            if (!Versioned.IsNumeric((object)qJob.ScheduleOfRatesMarkup))
                this.AddCriticalMessage("*Schedule Of Rates Markup must be Numeric");
            if (this.ValidatorMessages.CriticalMessages.Count > 0)
                throw new ValidationException((BaseValidator)this);
        }
    }
}