using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace Products
    {
        // make sure that contact object is valid
        public class ProductValidator : BaseValidator
        {
            public void Validate(Product oProduct)
            {

                // make sure that contact object is valid
                if (oProduct.Errors.Count > 0)
                {
                    DictionaryEntry de;
                    foreach (var de in oProduct.Errors)
                    {
                        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(de.Key, "RecommendedQuantity", false)))
                        {
                            AddCriticalMessage("Maximum Quantity Invalid");
                        }
                        else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(de.Key, "MinimumQuantity", false)))
                        {
                            AddCriticalMessage("Minimum Quantity Invalid");
                        }
                        else
                        {
                            AddCriticalMessage(Conversions.ToString(de.Value));
                        }
                    }
                }

                if (oProduct.Number.Trim().Length == 0)
                {
                    AddCriticalMessage("*GC Number Missing");
                }
                else if (App.DB.Product.Check_Unique_Number(oProduct.Number, oProduct.ProductID) == false)
                {
                    AddCriticalMessage("GC Number already exists");
                }

                if (oProduct.TypeID == 0)
                {
                    AddCriticalMessage("*Type Missing");
                }

                if (oProduct.MakeID == 0)
                {
                    AddCriticalMessage("*Make Missing");
                }

                if (oProduct.ModelID == 0)
                {
                    AddCriticalMessage("*Model Missing");
                }

                if (oProduct.RecommendedQuantity < oProduct.MinimumQuantity)
                {
                    AddCriticalMessage("*Maximum Quantity cannot be less than the Minimum Quantity");
                }

                if (ValidatorMessages.CriticalMessages.Count > 0)
                {
                    throw new ValidationException(this);
                }
            }
        }
    }
}