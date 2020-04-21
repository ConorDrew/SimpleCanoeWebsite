using System.Collections;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace Subcontractors
    {
        // make sure that contact object is valid
        public class SubcontractorValidator : BaseValidator
        {
            public void Validate(Subcontractor oSubcontractor)
            {
                // make sure that contact object is valid
                if (oSubcontractor.Errors.Count > 0)
                {
                    foreach (DictionaryEntry de in oSubcontractor.Errors)
                        AddCriticalMessage(Conversions.ToString(de.Value));
                }

                if (oSubcontractor.Engineer.Errors.Count > 0)
                {
                    foreach (DictionaryEntry de in oSubcontractor.Engineer.Errors)
                        AddCriticalMessage(Conversions.ToString(de.Value));
                }

                if (oSubcontractor.Name.Trim().Length == 0)
                {
                    AddCriticalMessage("Subcontractor Name Missing");
                }
                else if (App.DB.Engineer.Check_Unique_Name(oSubcontractor.Name.Trim(), oSubcontractor.Engineer.EngineerID) == false)
                {
                    AddCriticalMessage("This Subcontractor Name already exists as an engineer");
                }

                if (oSubcontractor.Address1.Trim().Length == 0)
                {
                    AddCriticalMessage("Subcontractor Address 1 Missing");
                }

                if (oSubcontractor.Postcode.Trim().Length == 0)
                {
                    AddCriticalMessage("Subcontractor Postcode Missing");
                }

                if (oSubcontractor.TelephoneNum.Trim().Length == 0)
                {
                    AddCriticalMessage("Subcontractor Telephone Missing");
                }

                if (oSubcontractor.Engineer.RegionID == 0)
                {
                    AddCriticalMessage("Region Missing");
                }

                if (App.DB.Engineer.Check_Unique_PDAID(oSubcontractor.Engineer.PDAID, oSubcontractor.EngineerID) == false)
                {
                    AddCriticalMessage("PDA ID already exists");
                }

                if (!CheckShortDateIsValid(oSubcontractor.Engineer.HolidayYearStart))
                {
                    AddCriticalMessage("'Start Period' for holiday entitlement must be in the format of 'dd/mm'");
                }

                if (!CheckShortDateIsValid(oSubcontractor.Engineer.HolidayYearEnd))
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