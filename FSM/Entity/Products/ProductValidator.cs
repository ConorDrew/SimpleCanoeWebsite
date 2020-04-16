// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Products.ProductValidator
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic.CompilerServices;
using System.Collections;

namespace FSM.Entity.Products
{
    public class ProductValidator : BaseValidator
    {
        public void Validate(Product oProduct)
        {
            if (oProduct.Errors.Count > 0)
            {
                foreach (object error in oProduct.Errors)
                {
                    DictionaryEntry dictionaryEntry = error != null ? (DictionaryEntry)error : new DictionaryEntry();
                    if (Operators.ConditionalCompareObjectEqual(dictionaryEntry.Key, (object)"RecommendedQuantity", false))
                        this.AddCriticalMessage("Maximum Quantity Invalid");
                    else if (Operators.ConditionalCompareObjectEqual(dictionaryEntry.Key, (object)"MinimumQuantity", false))
                        this.AddCriticalMessage("Minimum Quantity Invalid");
                    else
                        this.AddCriticalMessage(Conversions.ToString(dictionaryEntry.Value));
                }
            }
            if (oProduct.Number.Trim().Length == 0)
                this.AddCriticalMessage("*GC Number Missing");
            else if (!App.DB.Product.Check_Unique_Number(oProduct.Number, oProduct.ProductID))
                this.AddCriticalMessage("GC Number already exists");
            if (oProduct.TypeID == 0)
                this.AddCriticalMessage("*Type Missing");
            if (oProduct.MakeID == 0)
                this.AddCriticalMessage("*Make Missing");
            if (oProduct.ModelID == 0)
                this.AddCriticalMessage("*Model Missing");
            if (oProduct.RecommendedQuantity < oProduct.MinimumQuantity)
                this.AddCriticalMessage("*Maximum Quantity cannot be less than the Minimum Quantity");
            if (this.ValidatorMessages.CriticalMessages.Count > 0)
                throw new ValidationException((BaseValidator)this);
        }
    }
}