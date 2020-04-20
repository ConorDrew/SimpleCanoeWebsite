Namespace Entity

    Namespace Contacts

        Public Class ContactValidator
            'make sure that contact object is valid
            Inherits BaseValidator

            Public Sub Validate(ByVal oContact As Contact)

                'make sure that contact object is valid
                If oContact.Errors.Count > 0 Then
                    Dim de As DictionaryEntry
                    For Each de In oContact.Errors
                        Me.AddCriticalMessage(CStr(de.Value))
                    Next
                End If

                If oContact.Salutation.Trim.Length = 0 Then
                    Me.AddCriticalMessage("Title Missing")
                End If

                If oContact.FirstName.Trim.Length = 0 Then
                    Me.AddCriticalMessage("First Name Missing")
                End If

                If oContact.Surname.Trim.Length = 0 Then
                    Me.AddCriticalMessage("Last Name Missing")
                End If

                If oContact.MobileNo.Trim.Length = 0 Then
                    Me.AddCriticalMessage("Mobile Number Missing")
                End If

                If oContact.EmailAddress.Trim.Length = 0 Then
                    Me.AddCriticalMessage("Email Address Missing")
                End If

                If oContact.RelationshipID = 0 Then
                    Me.AddCriticalMessage("Relationship To Tennet Missing")
                End If

                If Entity.Sys.Helper.ValidatePhoneNumber(oContact.MobileNo) = False Then
                    Me.AddCriticalMessage("Phone Number Not a Valid Format (07xxxxxxxxx)")
                End If

                If Entity.Sys.Helper.IsEmailValid(oContact.EmailAddress) = False Then
                    Me.AddCriticalMessage("Email Not a Valid Format (email@email.co.uk)")
                End If

                If oContact.Address1.Trim.Length = 0 Then
                    Me.AddCriticalMessage("Address 1 Missing")
                End If

                If oContact.Address2.Trim.Length = 0 Then
                    Me.AddCriticalMessage("Address 2 Missing")
                End If

                If oContact.Address3.Trim.Length = 0 Then
                    Me.AddCriticalMessage("Address 3 Missing")
                End If

                If oContact.Postcode.Trim.Length = 0 Then
                    Me.AddCriticalMessage("Postcode Missing")
                End If

                If Me.ValidatorMessages.CriticalMessages.Count > 0 Then
                    Throw New ValidationException(Me)
                End If

            End Sub

        End Class

    End Namespace

End Namespace