// Decompiled with JetBrains decompiler
// Type: FSM.Entity.JobImport.JobImportTypeValidator
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic.CompilerServices;
using System.Collections;

namespace FSM.Entity.JobImport
{
  public class JobImportTypeValidator : BaseValidator
  {
    public void Validate(JobImportType oJobImportType)
    {
      if (oJobImportType.Errors.Count > 0)
      {
        foreach (object error in oJobImportType.Errors)
          this.AddCriticalMessage(Conversions.ToString((error != null ? (DictionaryEntry) error : new DictionaryEntry()).Value));
      }
      JobImportType jobImportType = oJobImportType;
      if (jobImportType.Name.Trim().Length == 0)
        this.AddCriticalMessage("Job Import Type missing name");
      if (jobImportType.JobTypeID == 0)
        this.AddCriticalMessage("Job Type missing");
      if (jobImportType.Cycle == 0)
        this.AddCriticalMessage("Cycle missing");
      if (jobImportType.Cycle < 0)
        this.AddCriticalMessage("Cycle incorrect");
      if (jobImportType.Cycle > 20)
        this.AddCriticalMessage("Cycle incorrect");
      if (this.ValidatorMessages.CriticalMessages.Count > 0)
        throw new ValidationException((BaseValidator) this);
    }
  }
}
