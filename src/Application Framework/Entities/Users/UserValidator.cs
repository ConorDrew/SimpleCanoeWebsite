using Microsoft.VisualBasic.CompilerServices;
using System.Collections;

namespace FSM.Entity
{
    namespace Users
    {
        public class UserValidator : BaseValidator
        {
            public void Validate(User userAndEngineer)
            {
                if (userAndEngineer.Errors.Count > 0)
                {
                    foreach (DictionaryEntry de in userAndEngineer.Errors)
                        AddCriticalMessage(Conversions.ToString(de.Value));
                }

                if (userAndEngineer.Fullname.Trim().Length == 0)
                {
                    AddCriticalMessage("Fullname Missing");
                }

                if (userAndEngineer.Username.Trim().Length == 0)
                {
                    AddCriticalMessage("Username Missing");
                }

                if (userAndEngineer.Password.Trim().Length == 0)
                {
                    AddCriticalMessage("Password Missing");
                }

                if (userAndEngineer.Password.Trim().Length < 8)
                {
                    AddCriticalMessage("Password too short (8 - 25 characters)");
                }

                if (userAndEngineer.EmailAddress.Trim().Length == 0)
                {
                    AddCriticalMessage("Email Address is required");
                }

                if (App.DB.User.Check_Unique_Username(userAndEngineer.Username, userAndEngineer.UserID) == false)
                {
                    AddCriticalMessage("Username already exists");
                }

                if (ValidatorMessages.CriticalMessages.Count > 0)
                {
                    throw new ValidationException(this);
                }
            }
        }
    }
}