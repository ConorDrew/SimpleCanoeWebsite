using System.Collections;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace Engineers
    {
        // make sure that contact object is valid
        public class EngineerValidator : BaseValidator
        {
            public void Validate(Engineer oEngineer)
            {
                // make sure that contact object is valid
                if (oEngineer.Errors.Count > 0)
                {
                    foreach (DictionaryEntry de in oEngineer.Errors)
                        AddCriticalMessage(Conversions.ToString(de.Value));
                }

                if (oEngineer.EngineerGroupID <= 0)
                {
                    AddCriticalMessage("Engineer Group");
                }

                if (oEngineer.Name.Trim().Length == 0)
                {
                    AddCriticalMessage("Name Missing");
                }
                else if (App.DB.Engineer.Check_Unique_Name(oEngineer.Name, oEngineer.EngineerID) == false)
                {
                    AddCriticalMessage("Engineer name already exists");
                }

                if (oEngineer.RegionID == 0)
                {
                    AddCriticalMessage("Region Missing");
                }
                // If oEngineer.PDAID = 0 Then
                // Me.AddCriticalMessage("PDA ID Missing")
                // Else
                // If DB.Engineer.Check_Unique_PDAID(oEngineer.PDAID, oEngineer.EngineerID) = False Then
                // Me.AddCriticalMessage("PDA ID already exists")
                // End If
                // End If
                // If oEngineer.WebAppPassword.Trim.Length = 0 Then
                // Me.AddCriticalMessage("WebApp Password Missing")
                // End If

                if (!CheckShortDateIsValid(oEngineer.HolidayYearStart))
                {
                    AddCriticalMessage("'Start Period' for holiday entitlement must be in the format of 'dd/mm'");
                }

                if (!CheckShortDateIsValid(oEngineer.HolidayYearEnd))
                {
                    AddCriticalMessage("'End Period' for holiday entitlement must be in the format of 'dd/mm'");
                }

                if (ValidatorMessages.CriticalMessages.Count > 0)
                {
                    throw new ValidationException(this);
                }
            }

            // This function checks if a string is in a particular format 'dd/mm'.
            // Note: If the string has a length equal to zero then the string is considered
            // valid.
            private bool CheckShortDateIsValid(string strDate)
            {
                if (strDate.Length == 0)
                {
                    return true;
                }

                strDate = strDate.Trim();
                bool valid = true;
                if (strDate.Length != 5)
                {
                    valid = false;
                }
                else
                {
                    var strChars = strDate.ToCharArray();
                    if (!Information.IsNumeric(strChars[0]))
                    {
                        valid = false;
                    }

                    if (!Information.IsNumeric(strChars[1]))
                    {
                        valid = false;
                    }

                    if (Conversions.ToString(strChars[2]) != "/")
                    {
                        valid = false;
                    }

                    if (!Information.IsNumeric(strChars[3]))
                    {
                        valid = false;
                    }

                    if (!Information.IsNumeric(strChars[4]))
                    {
                        valid = false;
                    }
                }

                return valid;
            }
        }
    }
}