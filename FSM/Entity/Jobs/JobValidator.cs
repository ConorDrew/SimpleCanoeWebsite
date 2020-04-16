// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Jobs.JobValidator
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.EngineerVisits;
using FSM.Entity.JobItems;
using FSM.Entity.JobOfWorks;
using Microsoft.VisualBasic.CompilerServices;
using System;
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
          this.AddCriticalMessage(Conversions.ToString((error != null ? (DictionaryEntry) error : new DictionaryEntry()).Value));
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
      IEnumerator enumerator1;
      try
      {
        enumerator1 = oJob.JobOfWorks.GetEnumerator();
        while (enumerator1.MoveNext())
        {
          JobOfWork current1 = (JobOfWork) enumerator1.Current;
          if (current1.Priority == 0 & App.DB.Job.JobOfWork_Required_Priority(oJob.PropertyID))
            this.AddCriticalMessage("Job Of Work #" + Conversions.ToString(num1) + " Priority Missing");
          int num2 = 1;
          IEnumerator enumerator2;
          try
          {
            enumerator2 = current1.JobItems.GetEnumerator();
            while (enumerator2.MoveNext())
            {
              if (((JobItem) enumerator2.Current).Summary.Trim().Length == 0)
                this.AddCriticalMessage("Job Of Work #" + Conversions.ToString(num1) + " Job Item #" + Conversions.ToString(num2) + " Summary Missing");
              checked { ++num2; }
            }
          }
          finally
          {
            if (enumerator2 is IDisposable)
              (enumerator2 as IDisposable).Dispose();
          }
          int num3 = 1;
          IEnumerator enumerator3;
          try
          {
            enumerator3 = current1.EngineerVisits.GetEnumerator();
            while (enumerator3.MoveNext())
            {
              EngineerVisit current2 = (EngineerVisit) enumerator3.Current;
              if (current2.StatusEnumID == 0)
                this.AddCriticalMessage("Job Of Work #" + Conversions.ToString(num1) + " Visit #" + Conversions.ToString(num3) + " Status Not Selected");
              if (current2.NotesToEngineer.Trim().Length == 0)
                this.AddCriticalMessage("Job Of Work #" + Conversions.ToString(num1) + " Visit #" + Conversions.ToString(num3) + " Notes To Engineer Missing");
              checked { ++num3; }
            }
          }
          finally
          {
            if (enumerator3 is IDisposable)
              (enumerator3 as IDisposable).Dispose();
          }
          checked { ++num1; }
        }
      }
      finally
      {
        if (enumerator1 is IDisposable)
          (enumerator1 as IDisposable).Dispose();
      }
      if (this.ValidatorMessages.CriticalMessages.Count > 0)
        throw new ValidationException((BaseValidator) this);
    }
  }
}
