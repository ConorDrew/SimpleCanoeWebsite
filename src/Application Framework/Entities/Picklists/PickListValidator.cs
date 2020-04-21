using Microsoft.VisualBasic.CompilerServices;
using System.Collections;

namespace FSM.Entity
{
    namespace PickLists
    {
        public class PickListValidator : BaseValidator
        {
            public void Validate(PickList picklist)
            {
                if (picklist.Errors.Count > 0)
                {
                    foreach (DictionaryEntry de in picklist.Errors)
                    {
                        if (picklist.EnumTypeID == Conversions.ToInteger(Sys.Enums.PickListTypes.VATCodes))
                        {
                            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(de.Key, "PercentageRate", false)))
                            {
                                AddCriticalMessage("Rate Invalid");
                            }
                            else
                            {
                                AddCriticalMessage(Conversions.ToString(de.Value));
                            }
                        }
                        else
                        {
                            AddCriticalMessage(Conversions.ToString(de.Value));
                        }
                    }
                }

                if (picklist.Name.Trim().Length == 0)
                {
                    AddCriticalMessage("Name Missing");
                }
                else if (picklist.EnumTypeID == (int)Sys.Enums.PickListTypes.PartBinReferences)
                {
                    if (App.DB.Picklists.Check_Unique_Name(picklist.Name, picklist.ManagerID, (Sys.Enums.PickListTypes)picklist.EnumTypeID) == false)
                    {
                        AddCriticalMessage("Name already exists");
                    }
                }

                if (picklist.EnumTypeID == 0)
                {
                    AddCriticalMessage("Type Missing");
                }

                if (picklist.EnumTypeID == (int)Sys.Enums.PickListTypes.VATCodes)
                {
                    if (picklist.PercentageRate < 0 | picklist.PercentageRate > 100)
                    {
                        AddCriticalMessage("Rate must be between 0 and 100");
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