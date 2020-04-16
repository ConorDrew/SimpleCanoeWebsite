// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Contacts.ContactValidator
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System.Collections;

namespace FSM.Entity.Contacts
{
    public class ContactValidator : BaseValidator
    {
        public void Validate(Contact oContact)
        {
            if (oContact.Errors.Count > 0)
            {
                foreach (object error in oContact.Errors)
                    this.AddCriticalMessage(Conversions.ToString((error != null ? (DictionaryEntry)error : new DictionaryEntry()).Value));
            }
            if (oContact.Salutation.Trim().Length == 0)
                this.AddCriticalMessage("Title Missing");
            if (oContact.FirstName.Trim().Length == 0)
                this.AddCriticalMessage("First Name Missing");
            if (oContact.Surname.Trim().Length == 0)
                this.AddCriticalMessage("Last Name Missing");
            if (oContact.MobileNo.Trim().Length == 0)
                this.AddCriticalMessage("Mobile Number Missing");
            if (oContact.EmailAddress.Trim().Length == 0)
                this.AddCriticalMessage("Email Address Missing");
            if (oContact.RelationshipID == 0)
                this.AddCriticalMessage("Relationship To Tennet Missing");
            if (!Helper.ValidatePhoneNumber(oContact.MobileNo))
                this.AddCriticalMessage("Phone Number Not a Valid Format (07xxxxxxxxx)");
            if (!Helper.IsEmailValid(oContact.EmailAddress))
                this.AddCriticalMessage("Email Not a Valid Format (email@email.co.uk)");
            if (oContact.Address1.Trim().Length == 0)
                this.AddCriticalMessage("Address 1 Missing");
            if (oContact.Address2.Trim().Length == 0)
                this.AddCriticalMessage("Address 2 Missing");
            if (oContact.Address3.Trim().Length == 0)
                this.AddCriticalMessage("Address 3 Missing");
            if (oContact.Postcode.Trim().Length == 0)
                this.AddCriticalMessage("Postcode Missing");
            if (this.ValidatorMessages.CriticalMessages.Count > 0)
                throw new ValidationException((BaseValidator)this);
        }
    }
}