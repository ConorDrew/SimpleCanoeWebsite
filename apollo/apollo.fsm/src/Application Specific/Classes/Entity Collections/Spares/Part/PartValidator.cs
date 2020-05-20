using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace Parts
    {
        // make sure that contact object is valid
        public class PartValidator : BaseValidator
        {
            public void Validate(Part oPart)
            {
                // make sure that contact object is valid
                if (oPart.Errors.Count > 0)
                {
                    foreach (DictionaryEntry de in oPart.Errors)
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

                if (oPart.Name.Trim().Length == 0)
                {
                    AddCriticalMessage("*Name Missing");
                }

                if (oPart.Number.Trim().Length == 0)
                {
                    AddCriticalMessage("*Number Missing");
                }
                else if (App.DB.Part.Check_Unique_Number(oPart.Number, oPart.PartID) == false)
                {
                    AddCriticalMessage("*Number already exists");
                }

                if (!(oPart.UnitTypeID > 0))
                {
                    AddCriticalMessage("*Unit Type Missing");
                }

                if (!(oPart.CategoryID > 0))
                {
                    AddCriticalMessage("*Category Missing");
                }

                if (oPart.RecommendedQuantity < oPart.MinimumQuantity)
                {
                    AddCriticalMessage("*Maximum Quantity cannot be less than the Minimum Quantity");
                }

                if (!(oPart.BinID == 0))
                {
                    if (App.DB.Part.Check_Unique_Bin(oPart.BinID, oPart.PartID, "BinID") == false)
                    {
                        AddCriticalMessage("*BIN reference already used");
                    }
                }

                if (!(oPart.BinIDAlternative == 0))
                {
                    if (App.DB.Part.Check_Unique_Bin(oPart.BinIDAlternative, oPart.PartID, "BinIDAlternative") == false)
                    {
                        AddCriticalMessage("*Alternative BIN reference already used");
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