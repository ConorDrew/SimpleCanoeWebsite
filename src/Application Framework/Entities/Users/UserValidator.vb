Namespace Entity

    Namespace Users

        Public Class UserValidator : Inherits BaseValidator

            Public Sub Validate(ByVal userAndEngineer As Entity.Users.User)
                If userAndEngineer.Errors.Count > 0 Then
                    Dim de As DictionaryEntry
                    For Each de In userAndEngineer.Errors
                        Me.AddCriticalMessage(CStr(de.Value))
                    Next
                End If

                If userAndEngineer.Fullname.Trim.Length = 0 Then
                    Me.AddCriticalMessage("Fullname Missing")
                End If
                If userAndEngineer.Username.Trim.Length = 0 Then
                    Me.AddCriticalMessage("Username Missing")
                End If
                If userAndEngineer.Password.Trim.Length = 0 Then
                    Me.AddCriticalMessage("Password Missing")
                End If
                If userAndEngineer.Password.Trim.Length < 8 Then
                    Me.AddCriticalMessage("Password too short (8 - 25 characters)")
                End If
                If userAndEngineer.EmailAddress.Trim.Length = 0 Then
                    Me.AddCriticalMessage("Email Address is required")
                End If
                If DB.User.Check_Unique_Username(userAndEngineer.Username, userAndEngineer.UserID) = False Then
                    Me.AddCriticalMessage("Username already exists")
                End If

                If Me.ValidatorMessages.CriticalMessages.Count > 0 Then
                    Throw New ValidationException(Me)
                End If
            End Sub

        End Class

    End Namespace

End Namespace
