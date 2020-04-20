Namespace Entity

Namespace Warehouses

Public Class WarehouseValidator
    'make sure that contact object is valid
    Inherits BaseValidator

    Public Sub Validate(ByVal oWarehouse As Warehouse)

        'make sure that contact object is valid
        If oWarehouse.Errors.Count > 0 Then
            Dim de As DictionaryEntry
            For Each de In oWarehouse.Errors
                Me.AddCriticalMessage(CStr(de.Value))
            Next
                End If

                If oWarehouse.Name.Trim.Length = 0 Then
                    Me.AddCriticalMessage("Name Missing")
                End If
                If oWarehouse.Address1.Trim.Length = 0 Then
                    Me.AddCriticalMessage("Address1 Missing")
                End If
                If oWarehouse.Postcode.Trim.Length = 0 Then
                    Me.AddCriticalMessage("Postcode Missing")
                End If

                If Me.ValidatorMessages.CriticalMessages.Count > 0 Then
                    Throw New ValidationException(Me)
                End If

            End Sub

End Class

End Namespace

End Namespace
