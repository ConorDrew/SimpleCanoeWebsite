using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace Contacts
    {
        // make sure that contact object is valid
        public class ContactValidator : BaseValidator
        {
            public void Validate(Contact oContact)
            {

                // make sure that contact object is valid
                if (oContact.Errors.Count > 0)
                {
                    DictionaryEntry de;
                    foreach (var de in oContact.Errors)
                        AddCriticalMessage(Conversions.ToString(de.Value));
                }

                if (oContact.Salutation.Trim().Length == 0)
                {
                    AddCriticalMessage("Title Missing");
                }

                if (oContact.FirstName.Trim().Length == 0)
                {
                    AddCriticalMessage("First Name Missing");
                }

                if (oContact.Surname.Trim().Length == 0)
                {
                    AddCriticalMessage("Last Name Missing");
                }

                if (oContact.MobileNo.Trim().Length == 0)
                {
                    AddCriticalMessage("Mobile Number Missing");
                }

                if (oContact.EmailAddress.Trim().Length == 0)
                {
                    AddCriticalMessage("Email Address Missing");
                }

                if (oContact.RelationshipID == 0)
                {
                    AddCriticalMessage("Relationship To Tennet Missing");
                }

                if (Sys.Helper.ValidatePhoneNumber(oContact.MobileNo) == false)
                {
                    AddCriticalMessage("Phone Number Not a Valid Format (07xxxxxxxxx)");
                }

                if (Sys.Helper.IsEmailValid(oContact.EmailAddress) == false)
                {
                    AddCriticalMessage("Email Not a Valid Format (email@email.co.uk)");
                }

                if (oContact.Address1.Trim().Length == 0)
                {
                    AddCriticalMessage("Address 1 Missing");
                }

                if (oContact.Address2.Trim().Length == 0)
                {
                    AddCriticalMessage("Address 2 Missing");
                }

                if (oContact.Address3.Trim().Length == 0)
                {
                    AddCriticalMessage("Address 3 Missing");
                }

                if (oContact.Postcode.Trim().Length == 0)
                {
                    AddCriticalMessage("Postcode Missing");
                }

                if (ValidatorMessages.CriticalMessages.Count > 0)
                {
                    throw new ValidationException(this);
                }
            }
        }
    }
}