// Decompiled with JetBrains decompiler
// Type: FSM.Entity.ProductSupplierPriceRequests.ProductSupplierPriceRequestValidator
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic.CompilerServices;
using System.Collections;

namespace FSM.Entity.ProductSupplierPriceRequests
{
    public class ProductSupplierPriceRequestValidator : BaseValidator
    {
        public void Validate(
          ProductSupplierPriceRequest oProductSupplierPriceRequest)
        {
            if (oProductSupplierPriceRequest.Errors.Count > 0)
            {
                foreach (object error in oProductSupplierPriceRequest.Errors)
                    this.AddCriticalMessage(Conversions.ToString((error != null ? (DictionaryEntry)error : new DictionaryEntry()).Value));
            }
            if (oProductSupplierPriceRequest.OrderID == 0)
                this.AddCriticalMessage("Order missing");
            if (oProductSupplierPriceRequest.SupplierID == 0)
                this.AddCriticalMessage("Supplier missing");
            if (oProductSupplierPriceRequest.ProductID == 0)
                this.AddCriticalMessage("Product missing");
            if (oProductSupplierPriceRequest.QuantityInPack <= 0)
                this.AddCriticalMessage("Quantity must be greater than 0");
            if (this.ValidatorMessages.CriticalMessages.Count > 0)
                throw new ValidationException((BaseValidator)this);
        }
    }
}