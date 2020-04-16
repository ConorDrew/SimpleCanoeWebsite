// Decompiled with JetBrains decompiler
// Type: FSM.UserAbsenceValidator
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic.CompilerServices;
using System.Collections;

namespace FSM
{
  public class UserAbsenceValidator : BaseValidator
  {
    public void Validate(FSM.Entity.UserAbsence.UserAbsence oEA)
    {
      if (oEA.Errors.Count > 0)
      {
        foreach (object error in oEA.Errors)
          this.AddCriticalMessage(Conversions.ToString((error != null ? (DictionaryEntry) error : new DictionaryEntry()).Value));
      }
      if (Operators.CompareString(oEA.UserID, "-1", false) == 0)
        this.AddCriticalMessage(ErrorMsg.FieldRequired("User"));
      if (oEA.AbsenceTypeID == -1)
        this.AddCriticalMessage(ErrorMsg.FieldRequired("Absence Type"));
      if (this.ValidatorMessages.CriticalMessages.Count > 0)
        throw new ValidationException((BaseValidator) this);
    }
  }
}
