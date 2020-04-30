﻿ 
 

using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    // make sure that contact object is valid
    public class UserAbsenceValidator : BaseValidator
    {
        public void Validate(Entity.UserAbsence.UserAbsence oEA)
        {
            // make sure that contact object is valid
            if (oEA.Errors.Count > 0)
            {
                foreach (DictionaryEntry de in oEA.Errors)
                    AddCriticalMessage(Conversions.ToString(de.Value));
            }

            // If oUserAbsence.Exists = False Then
            // If Not Database.Utilities.IsPrimaryKeyUnique("UserAbsenceID", oUserAbsence.UserAbsenceID, "tblUserAbsence") Then
            // Me.AddCriticalMessage(ErrorMsg.AlreadyExists("UserAbsenceID"))
            // End If
            // End If

            // ok now check business logic of contact

            // TO-DO: Work for developer ... add validation code for the entity here

            if ((oEA.UserID ?? "") == "-1")
            {
                AddCriticalMessage(ErrorMsg.FieldRequired("User"));
            }

            if (oEA.AbsenceTypeID == -1)
            {
                AddCriticalMessage(ErrorMsg.FieldRequired("Absence Type"));
            }

            if (ValidatorMessages.CriticalMessages.Count > 0)
            {
                throw new ValidationException(this);
            }
        }
    }
}