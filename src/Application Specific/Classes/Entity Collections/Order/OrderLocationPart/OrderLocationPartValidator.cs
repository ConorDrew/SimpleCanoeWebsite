using System.Collections;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace OrderLocationPart
    {
        // make sure that contact object is valid
        public class OrderLocationPartValidator : BaseValidator
        {
            public void Validate(OrderLocationPart oOrderLocationPart)
            {

                // make sure that contact object is valid
                if (oOrderLocationPart.Errors.Count > 0)
                {
                    DictionaryEntry de;
                    foreach (var de in oOrderLocationPart.Errors)
                        AddCriticalMessage(Conversions.ToString(de.Value));
                }

                if (!(oOrderLocationPart.Quantity > 0))
                {
                    AddCriticalMessage("Quantity must be greater than 0");
                }
                else
                {
                    int amountInStock = App.DB.Part.Part_Check_Stock_Level(oOrderLocationPart.PartID, oOrderLocationPart.LocationID);
                    if (amountInStock < oOrderLocationPart.Quantity)
                    {
                        if (App.ShowMessage("You have asked for a quantity of " + oOrderLocationPart.Quantity + ". Only " + amountInStock + " are available. Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
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

            public void Validate(OrderLocationPart oOrderLocationPart, System.Data.SqlClient.SqlTransaction trans)
            {

                // make sure that contact object is valid
                if (oOrderLocationPart.Errors.Count > 0)
                {
                    DictionaryEntry de;
                    foreach (var de in oOrderLocationPart.Errors)
                        AddCriticalMessage(Conversions.ToString(de.Value));
                }

                if (!(oOrderLocationPart.Quantity > 0))
                {
                    AddCriticalMessage("Quantity must be greater than 0");
                }
                else
                {
                    int amountInStock = App.DB.Part.Part_Check_Stock_Level(oOrderLocationPart.PartID, oOrderLocationPart.LocationID, trans);
                    if (amountInStock < oOrderLocationPart.Quantity)
                    {
                        if (App.ShowMessage("You have asked for a quantity of " + oOrderLocationPart.Quantity + ". Only " + amountInStock + " are available. Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
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