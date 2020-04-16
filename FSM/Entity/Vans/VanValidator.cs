// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Vans.VanValidator
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic.CompilerServices;
using System.Collections;

namespace FSM.Entity.Vans
{
  public class VanValidator : BaseValidator
  {
    public void Validate(Van oVan)
    {
      if (oVan.Errors.Count > 0)
      {
        foreach (object error in oVan.Errors)
          this.AddCriticalMessage(Conversions.ToString((error != null ? (DictionaryEntry) error : new DictionaryEntry()).Value));
      }
      if (oVan.Registration.Trim().Length == 0)
        this.AddCriticalMessage("Profile Name Missing");
      else if (oVan.Registration.Contains("*"))
        this.AddCriticalMessage("An asterix (*) cannot be placed in the profile name");
      else if (!App.DB.Van.Check_Unique_Registration(oVan.Registration, oVan.VanID))
        this.AddCriticalMessage("Profile name already exists");
      if (this.ValidatorMessages.CriticalMessages.Count > 0)
        throw new ValidationException((BaseValidator) this);
    }
  }
}
