// Decompiled with JetBrains decompiler
// Type: FSM.Entity.OrderParts.OrderPartValidator
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System.Collections;

namespace FSM.Entity.OrderParts
{
  public class OrderPartValidator : BaseValidator
  {
    public void Validate(OrderPart oOrderPart)
    {
      if (oOrderPart.Errors.Count > 0)
      {
        foreach (object error in oOrderPart.Errors)
          this.AddCriticalMessage(Conversions.ToString((error != null ? (DictionaryEntry) error : new DictionaryEntry()).Value));
      }
      if (oOrderPart.Quantity <= 0)
        this.AddCriticalMessage("Quantity must be greater than 0");
      if (Information.IsDBNull((object) oOrderPart.BuyPrice))
        this.AddCriticalMessage("Buy Price not entered");
      if (Information.IsDBNull((object) oOrderPart.SellPrice))
        this.AddCriticalMessage("Sell Price not entered");
      if (this.ValidatorMessages.CriticalMessages.Count > 0)
        throw new ValidationException((BaseValidator) this);
    }
  }
}
