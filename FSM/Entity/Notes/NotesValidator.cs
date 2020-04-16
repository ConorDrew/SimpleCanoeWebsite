// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Notes.NotesValidator
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic.CompilerServices;
using System.Collections;

namespace FSM.Entity.Notes
{
  public class NotesValidator : BaseValidator
  {
    public void Validate(FSM.Entity.Notes.Notes oNotes)
    {
      if (oNotes.Errors.Count > 0)
      {
        foreach (object error in oNotes.Errors)
          this.AddCriticalMessage(Conversions.ToString((error != null ? (DictionaryEntry) error : new DictionaryEntry()).Value));
      }
      if (oNotes.CategoryID <= 0)
        this.AddCriticalMessage("* Category Missing");
      if (oNotes.Note.Trim().Length == 0)
        this.AddCriticalMessage("* Note Missing");
      if (oNotes.UserIDFor == 0)
        this.AddCriticalMessage("* User For Missing");
      if (this.ValidatorMessages.CriticalMessages.Count > 0)
        throw new ValidationException((BaseValidator) this);
    }
  }
}
