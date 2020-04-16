// Decompiled with JetBrains decompiler
// Type: FSM.Entity.ProductAssociatedParts.ProductAssociatedPartValidator
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic.CompilerServices;
using System.Collections;

namespace FSM.Entity.ProductAssociatedParts
{
  public class ProductAssociatedPartValidator : BaseValidator
  {
    public void Validate(ProductAssociatedPart oProductAssociatedPart)
    {
      if (oProductAssociatedPart.Errors.Count > 0)
      {
        foreach (object error in oProductAssociatedPart.Errors)
          this.AddCriticalMessage(Conversions.ToString((error != null ? (DictionaryEntry) error : new DictionaryEntry()).Value));
      }
      if (this.ValidatorMessages.CriticalMessages.Count > 0)
        throw new ValidationException((BaseValidator) this);
    }
  }
}
