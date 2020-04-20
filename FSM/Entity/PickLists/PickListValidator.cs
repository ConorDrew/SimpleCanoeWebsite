// Decompiled with JetBrains decompiler
// Type: FSM.Entity.PickLists.PickListValidator
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System.Collections;

namespace FSM.Entity.PickLists
{
    public class PickListValidator : BaseValidator
    {
        public void Validate(PickList picklist)
        {
            if (picklist.Errors.Count > 0)
            {
                foreach (object error in picklist.Errors)
                {
                    DictionaryEntry dictionaryEntry = error != null ? (DictionaryEntry)error : new DictionaryEntry();
                    if (picklist.EnumTypeID == 41)
                    {
                        if (Operators.ConditionalCompareObjectEqual(dictionaryEntry.Key, (object)"PercentageRate", false))
                            this.AddCriticalMessage("Rate Invalid");
                        else
                            this.AddCriticalMessage(Conversions.ToString(dictionaryEntry.Value));
                    }
                    else
                        this.AddCriticalMessage(Conversions.ToString(dictionaryEntry.Value));
                }
            }
            if (picklist.Name.Trim().Length == 0)
                this.AddCriticalMessage("Name Missing");
            else if (picklist.EnumTypeID == 34 && !App.DB.Picklists.Check_Unique_Name(picklist.Name, picklist.ManagerID, (Enums.PickListTypes)picklist.EnumTypeID))
                this.AddCriticalMessage("Name already exists");
            if (picklist.EnumTypeID == 0)
                this.AddCriticalMessage("Type Missing");
            if (picklist.EnumTypeID == 41 && picklist.PercentageRate < 0.0 | picklist.PercentageRate > 100.0)
                this.AddCriticalMessage("Rate must be between 0 and 100");
            if (this.ValidatorMessages.CriticalMessages.Count > 0)
                throw new ValidationException((BaseValidator)this);
        }
    }
}