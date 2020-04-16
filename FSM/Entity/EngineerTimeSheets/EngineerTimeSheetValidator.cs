// Decompiled with JetBrains decompiler
// Type: FSM.Entity.EngineerTimeSheets.EngineerTimeSheetValidator
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;

namespace FSM.Entity.EngineerTimeSheets
{
    public class EngineerTimeSheetValidator : BaseValidator
    {
        public void Validate(EngineerTimeSheet oEngineerTimeSheet)
        {
            if (oEngineerTimeSheet.Errors.Count > 0)
            {
                foreach (object error in oEngineerTimeSheet.Errors)
                    this.AddCriticalMessage(Conversions.ToString((error != null ? (DictionaryEntry)error : new DictionaryEntry()).Value));
            }
            if (oEngineerTimeSheet.EngineerID == 0)
                this.AddCriticalMessage("Engineer Missing");
            if (oEngineerTimeSheet.TimeSheetTypeID == 0)
                this.AddCriticalMessage("Type Missing");
            if (DateTime.Compare(Conversions.ToDate(Strings.Format((object)oEngineerTimeSheet.StartDateTime, "dd/MM/yyyy HH:mm")), Conversions.ToDate(Strings.Format((object)oEngineerTimeSheet.EndDateTime, "dd/MM/yyyy HH:mm"))) >= 0)
                this.AddCriticalMessage("End Date/Time must be greater than Start Date/Time Missing");
            if (this.ValidatorMessages.CriticalMessages.Count > 0)
                throw new ValidationException((BaseValidator)this);
        }
    }
}