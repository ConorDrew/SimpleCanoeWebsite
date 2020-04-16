// Decompiled with JetBrains decompiler
// Type: FSM.Entity.OrderCharges.OrderChargeValidator
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic.CompilerServices;
using System.Collections;

namespace FSM.Entity.OrderCharges
{
    public class OrderChargeValidator : BaseValidator
    {
        public void Validate(OrderCharge oOrderCharge)
        {
            if (oOrderCharge.Errors.Count > 0)
            {
                foreach (object error in oOrderCharge.Errors)
                    this.AddCriticalMessage(Conversions.ToString((error != null ? (DictionaryEntry)error : new DictionaryEntry()).Value));
            }
            if (oOrderCharge.OrderChargeTypeID == 0)
                this.AddCriticalMessage("Charge Type Missing");
            if (oOrderCharge.Amount <= 0.0)
                this.AddCriticalMessage("Amount Missing");
            if (this.ValidatorMessages.CriticalMessages.Count > 0)
                throw new ValidationException((BaseValidator)this);
        }
    }
}