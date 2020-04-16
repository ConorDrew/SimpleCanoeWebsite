// Decompiled with JetBrains decompiler
// Type: FSM.EngineerAbsenceValidator
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Engineers;
using Microsoft.VisualBasic.CompilerServices;
using System.Collections;

namespace FSM
{
  public class EngineerAbsenceValidator : BaseValidator
  {
    public void Validate(FSM.Entity.EngineerAbsence.EngineerAbsence oEA)
    {
      if (oEA.Errors.Count > 0)
      {
        foreach (object error in oEA.Errors)
          this.AddCriticalMessage(Conversions.ToString((error != null ? (DictionaryEntry) error : new DictionaryEntry()).Value));
      }
      Engineer engineer = new Engineer();
      engineer = App.DB.Engineer.Engineer_Get(Conversions.ToInteger(oEA.EngineerID));
      if (Operators.CompareString(oEA.EngineerID, "-1", false) == 0)
        this.AddCriticalMessage(ErrorMsg.FieldRequired("Engineer"));
      if (oEA.AbsenceTypeID == -1)
        this.AddCriticalMessage(ErrorMsg.FieldRequired("Absence Type"));
      if (oEA.MorningSlots < 0)
        this.AddCriticalMessage(ErrorMsg.NegativeNumber("Morning Slots"));
      if (oEA.AfternoonSlots < 0)
        this.AddCriticalMessage(ErrorMsg.NegativeNumber("Afternoon Slots"));
      if (this.ValidatorMessages.CriticalMessages.Count > 0)
        throw new ValidationException((BaseValidator) this);
    }
  }
}
