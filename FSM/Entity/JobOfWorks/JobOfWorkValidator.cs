﻿// Decompiled with JetBrains decompiler
// Type: FSM.Entity.JobOfWorks.JobOfWorkValidator
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic.CompilerServices;
using System.Collections;

namespace FSM.Entity.JobOfWorks
{
    public class JobOfWorkValidator : BaseValidator
    {
        public void Validate(JobOfWork oJobOfWork)
        {
            if (oJobOfWork.Errors.Count > 0)
            {
                foreach (object error in oJobOfWork.Errors)
                    this.AddCriticalMessage(Conversions.ToString((error != null ? (DictionaryEntry)error : new DictionaryEntry()).Value));
            }
            if (this.ValidatorMessages.CriticalMessages.Count > 0)
                throw new ValidationException((BaseValidator)this);
        }
    }
}