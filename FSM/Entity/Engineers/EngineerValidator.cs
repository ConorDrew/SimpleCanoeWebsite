// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Engineers.EngineerValidator
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic.CompilerServices;
using System.Collections;

namespace FSM.Entity.Engineers
{
    public class EngineerValidator : BaseValidator
    {
        public void Validate(Engineer oEngineer)
        {
            if (oEngineer.Errors.Count > 0)
            {
                foreach (object error in oEngineer.Errors)
                    this.AddCriticalMessage(Conversions.ToString((error != null ? (DictionaryEntry)error : new DictionaryEntry()).Value));
            }
            if (oEngineer.EngineerGroupID <= 0)
                this.AddCriticalMessage("Engineer Group");
            if (oEngineer.Name.Trim().Length == 0)
                this.AddCriticalMessage("Name Missing");
            else if (!App.DB.Engineer.Check_Unique_Name(oEngineer.Name, oEngineer.EngineerID))
                this.AddCriticalMessage("Engineer name already exists");
            if (oEngineer.RegionID == 0)
                this.AddCriticalMessage("Region Missing");
            if (!this.CheckShortDateIsValid(oEngineer.HolidayYearStart))
                this.AddCriticalMessage("'Start Period' for holiday entitlement must be in the format of 'dd/mm'");
            if (!this.CheckShortDateIsValid(oEngineer.HolidayYearEnd))
                this.AddCriticalMessage("'End Period' for holiday entitlement must be in the format of 'dd/mm'");
            if (this.ValidatorMessages.CriticalMessages.Count > 0)
                throw new ValidationException((BaseValidator)this);
        }

        private bool CheckShortDateIsValid(string strDate)
        {
            if (strDate.Length == 0)
                return true;
            strDate = strDate.Trim();
            bool flag = true;
            if (strDate.Length != 5)
            {
                flag = false;
            }
            else
            {
                char[] charArray = strDate.ToCharArray();
                if (!Versioned.IsNumeric((object)charArray[0]))
                    flag = false;
                if (!Versioned.IsNumeric((object)charArray[1]))
                    flag = false;
                if ((uint)Operators.CompareString(Conversions.ToString(charArray[2]), "/", false) > 0U)
                    flag = false;
                if (!Versioned.IsNumeric((object)charArray[3]))
                    flag = false;
                if (!Versioned.IsNumeric((object)charArray[4]))
                    flag = false;
            }
            return flag;
        }
    }
}