// Decompiled with JetBrains decompiler
// Type: FSM.Entity.PartsToBeCrediteds.PartsToBeCreditedValidator
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic.CompilerServices;
using System.Collections;
using System.Data;

namespace FSM.Entity.PartsToBeCrediteds
{
  public class PartsToBeCreditedValidator : BaseValidator
  {
    public void Validate(PartsToBeCredited oPartsToBeCredited)
    {
      if (oPartsToBeCredited.Errors.Count > 0)
      {
        foreach (object error in oPartsToBeCredited.Errors)
          this.AddCriticalMessage(Conversions.ToString((error != null ? (DictionaryEntry) error : new DictionaryEntry()).Value));
      }
      if (oPartsToBeCredited.PartID == 0)
        this.AddCriticalMessage("Part Missing");
      else if (oPartsToBeCredited.OrderID > 0)
      {
        DataRow[] dataRowArray = App.DB.Order.OrderPart_GetForOrder(oPartsToBeCredited.OrderID).Table.Select("PartID=" + Conversions.ToString(oPartsToBeCredited.PartID));
        if (dataRowArray.Length > 0 && Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectGreater((object) oPartsToBeCredited.Qty, dataRowArray[0]["Qty"], false))
          this.AddCriticalMessage("Qty cannot be higher than quantity ordered.");
      }
      if (oPartsToBeCredited.SupplierID == 0)
        this.AddCriticalMessage("Supplier Missing");
      if (oPartsToBeCredited.OrderReference.Length == 0)
        this.AddCriticalMessage("Select an order or enter a reference ");
      if (this.ValidatorMessages.CriticalMessages.Count > 0)
        throw new ValidationException((BaseValidator) this);
    }
  }
}
