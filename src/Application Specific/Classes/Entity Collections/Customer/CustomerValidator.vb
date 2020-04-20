Namespace Entity

Namespace Customers

Public Class CustomerValidator
    'make sure that contact object is valid
    Inherits BaseValidator

    Public Sub Validate(ByVal oCustomer As Customer)

        'make sure that contact object is valid
        If oCustomer.Errors.Count > 0 Then
            Dim de As DictionaryEntry
            For Each de In oCustomer.Errors
                Me.AddCriticalMessage(CStr(de.Value))
            Next
        End If

                If oCustomer.Name.Trim.Length = 0 Then
                    Me.AddCriticalMessage("Name Missing")
                End If
                If oCustomer.AccountNumber.Trim.Length = 0 Then
                    Me.AddCriticalMessage("Account Number Missing")
                End If
                If oCustomer.RegionID = 0 Then
                    Me.AddCriticalMessage("Region Missing")
                End If
                If oCustomer.CustomerTypeID = 0 Then
                    Me.AddCriticalMessage("Customer Type Missing")
                End If
                If oCustomer.Status = 0 Then
                    Me.AddCriticalMessage("Status Missing")
                End If

                If Me.ValidatorMessages.CriticalMessages.Count > 0 Then
                    Throw New ValidationException(Me)
                End If

            End Sub

End Class

End Namespace

End Namespace
