Namespace Entity

Namespace PartSupplierPriceRequests

Public Class PartSupplierPriceRequestValidator
    'make sure that contact object is valid
    Inherits BaseValidator

    Public Sub Validate(ByVal oPartSupplierPriceRequest As PartSupplierPriceRequest)

        'make sure that contact object is valid
        If oPartSupplierPriceRequest.Errors.Count > 0 Then
            Dim de As DictionaryEntry
            For Each de In oPartSupplierPriceRequest.Errors
                Me.AddCriticalMessage(CStr(de.Value))
            Next
        End If

                If oPartSupplierPriceRequest.OrderID = 0 Then
                    Me.AddCriticalMessage("Order missing")
                End If
                If oPartSupplierPriceRequest.SupplierID = 0 Then
                    Me.AddCriticalMessage("Supplier missing")
                End If
                If oPartSupplierPriceRequest.PartID = 0 Then
                    Me.AddCriticalMessage("Part missing")
                End If
                If Not oPartSupplierPriceRequest.QuantityInPack > 0 Then
                    Me.AddCriticalMessage("Quantity must be greater than 0")
                End If

                If Me.ValidatorMessages.CriticalMessages.Count > 0 Then
                    Throw New ValidationException(Me)
                End If

    End Sub

End Class

End Namespace

End Namespace
