using System.Collections;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace OrderLocationProduct
    {
        // make sure that contact object is valid
        public class OrderLocationProductValidator : BaseValidator
        {
            public void Validate(OrderLocationProduct oOrderLocationProduct)
            {
                // make sure that contact object is valid
                if (oOrderLocationProduct.Errors.Count > 0)
                {
                    foreach (DictionaryEntry de in oOrderLocationProduct.Errors)
                        AddCriticalMessage(Conversions.ToString(de.Value));
                }

                if (!(oOrderLocationProduct.Quantity > 0))
                {
                    AddCriticalMessage("Quantity must be greater than 0");
                }
                else
                {
                    int amountInStock = App.DB.Product.Product_Check_Stock_Level(oOrderLocationProduct.ProductID, oOrderLocationProduct.LocationID);
                    if (amountInStock < oOrderLocationProduct.Quantity)
                    {
                        if (App.ShowMessage("You have asked for a quantity of " + oOrderLocationProduct.Quantity + ", " + amountInStock + " are available. Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            AddCriticalMessage("Not enough stock");
                        }
                    }
                }

                if (ValidatorMessages.CriticalMessages.Count > 0)
                {
                    throw new ValidationException(this);
                }
            }

            public void Validate(OrderLocationProduct oOrderLocationProduct, System.Data.SqlClient.SqlTransaction trans)
            {
                // make sure that contact object is valid
                if (oOrderLocationProduct.Errors.Count > 0)
                {
                    foreach (DictionaryEntry de in oOrderLocationProduct.Errors)
                        AddCriticalMessage(Conversions.ToString(de.Value));
                }

                if (!(oOrderLocationProduct.Quantity > 0))
                {
                    AddCriticalMessage("Quantity must be greater than 0");
                }
                else
                {
                    int amountInStock = App.DB.Product.Product_Check_Stock_Level(oOrderLocationProduct.ProductID, oOrderLocationProduct.LocationID, trans);
                    if (amountInStock < oOrderLocationProduct.Quantity)
                    {
                        if (App.ShowMessage("You have asked for a quantity of " + oOrderLocationProduct.Quantity + ", " + amountInStock + " are available. Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            AddCriticalMessage("Not enough stock");
                        }
                    }
                }

                if (ValidatorMessages.CriticalMessages.Count > 0)
                {
                    throw new ValidationException(this);
                }
            }
        }
    }
}