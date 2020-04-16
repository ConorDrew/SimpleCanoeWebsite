// Decompiled with JetBrains decompiler
// Type: FSM.Entity.OrderProducts.OrderProductValidator
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic.CompilerServices;
using System.Collections;

namespace FSM.Entity.OrderProducts
{
  public class OrderProductValidator : BaseValidator
  {
    public void Validate(OrderProduct oOrderProduct)
    {
      if (oOrderProduct.Errors.Count > 0)
      {
        foreach (object error in oOrderProduct.Errors)
          this.AddCriticalMessage(Conversions.ToString((error != null ? (DictionaryEntry) error : new DictionaryEntry()).Value));
      }
      if (oOrderProduct.Quantity <= 0)
        this.AddCriticalMessage("Quantity must be greater than 0");
      if (this.ValidatorMessages.CriticalMessages.Count > 0)
        throw new ValidationException((BaseValidator) this);
    }
  }
}
