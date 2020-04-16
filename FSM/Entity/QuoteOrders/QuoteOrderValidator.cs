// Decompiled with JetBrains decompiler
// Type: FSM.Entity.QuoteOrders.QuoteOrderValidator
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic.CompilerServices;
using System.Collections;

namespace FSM.Entity.QuoteOrders
{
    public class QuoteOrderValidator : BaseValidator
    {
        public void Validate(QuoteOrder oQuoteOrder)
        {
            if (oQuoteOrder.Errors.Count > 0)
            {
                foreach (object error in oQuoteOrder.Errors)
                    this.AddCriticalMessage(Conversions.ToString((error != null ? (DictionaryEntry)error : new DictionaryEntry()).Value));
            }
            if (oQuoteOrder.CustomerRef.Trim().Length == 0)
                this.AddCriticalMessage("*Customer Ref Missing");
            else if (oQuoteOrder.QuoteOrderID == 0 && App.DB.Order.Order_CheckReference(oQuoteOrder.CustomerRef).Table.Rows.Count > 0)
                this.AddCriticalMessage("*The Customer Ref you have chosen has already been allocated to another Quote or Order in the system.  Please choose a unique Reference.");
            if (oQuoteOrder.CustomerID == 0)
                this.AddCriticalMessage("*Customer Missing");
            if (oQuoteOrder.PropertyID == 0 & oQuoteOrder.WarehouseID == 0)
                this.AddCriticalMessage("*Please select a Property or Warehouse");
            if (oQuoteOrder.AllocatedToUser == 0)
                this.AddCriticalMessage("*Co-ordinator Missing");
            if (this.ValidatorMessages.CriticalMessages.Count > 0)
                throw new ValidationException((BaseValidator)this);
        }
    }
}