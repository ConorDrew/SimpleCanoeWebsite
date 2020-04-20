Namespace Entity

Namespace Suppliers

Public Class SupplierValidator
    'make sure that contact object is valid
    Inherits BaseValidator

    Public Sub Validate(ByVal oSupplier As Supplier)

        'make sure that contact object is valid
        If oSupplier.Errors.Count > 0 Then
            Dim de As DictionaryEntry
            For Each de In oSupplier.Errors
                Me.AddCriticalMessage(CStr(de.Value))
            Next
        End If

                If oSupplier.AccountNumber.Trim.Length = 0 Then
                    Me.AddCriticalMessage("Account Number Missing")
                End If
                If oSupplier.Name.Trim.Length = 0 Then
                    Me.AddCriticalMessage("Name Missing")
                End If
                If oSupplier.Address1.Trim.Length = 0 Then
                    Me.AddCriticalMessage("Address 1 Missing")
                End If
                If oSupplier.Postcode.Trim.Length = 0 Then
                    Me.AddCriticalMessage("Postcode Missing")
                End If

                If Me.ValidatorMessages.CriticalMessages.Count > 0 Then
                    Throw New ValidationException(Me)
                End If

    End Sub

End Class

End Namespace

End Namespace
