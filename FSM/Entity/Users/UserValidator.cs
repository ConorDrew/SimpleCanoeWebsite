// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Users.UserValidator
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic.CompilerServices;
using System.Collections;

namespace FSM.Entity.Users
{
    public class UserValidator : BaseValidator
    {
        public void Validate(User userAndEngineer)
        {
            if (userAndEngineer.Errors.Count > 0)
            {
                foreach (object error in userAndEngineer.Errors)
                    this.AddCriticalMessage(Conversions.ToString((error != null ? (DictionaryEntry)error : new DictionaryEntry()).Value));
            }
            if (userAndEngineer.Fullname.Trim().Length == 0)
                this.AddCriticalMessage("Fullname Missing");
            if (userAndEngineer.Username.Trim().Length == 0)
                this.AddCriticalMessage("Username Missing");
            if (userAndEngineer.Password.Trim().Length == 0)
                this.AddCriticalMessage("Password Missing");
            if (userAndEngineer.Password.Trim().Length < 8)
                this.AddCriticalMessage("Password too short (8 - 25 characters)");
            if (userAndEngineer.EmailAddress.Trim().Length == 0)
                this.AddCriticalMessage("Email Address is required");
            if (!App.DB.User.Check_Unique_Username(userAndEngineer.Username, userAndEngineer.UserID))
                this.AddCriticalMessage("Username already exists");
            if (this.ValidatorMessages.CriticalMessages.Count > 0)
                throw new ValidationException((BaseValidator)this);
        }
    }
}