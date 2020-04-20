Namespace Entity

Namespace ProductSupplierPriceRequests

Public Class ProductSupplierPriceRequestValidator
    'make sure that contact object is valid
    Inherits BaseValidator

    Public Sub Validate(ByVal oProductSupplierPriceRequest As ProductSupplierPriceRequest)

        'make sure that contact object is valid
        If oProductSupplierPriceRequest.Errors.Count > 0 Then
            Dim de As DictionaryEntry
            For Each de In oProductSupplierPriceRequest.Errors
                Me.AddCriticalMessage(CStr(de.Value))
            Next
        End If

                If oProductSupplierPriceRequest.OrderID = 0 Then
                    Me.AddCriticalMessage("Order missing")
                End If
                If oProductSupplierPriceRequest.SupplierID = 0 Then
                    Me.AddCriticalMessage("Supplier missing")
                End If
                If oProductSupplierPriceRequest.ProductID = 0 Then
                    Me.AddCriticalMessage("Product missing")
                End If
                If Not oProductSupplierPriceRequest.QuantityInPack > 0 Then
                    Me.AddCriticalMessage("Quantity must be greater than 0")
                End If

                If Me.ValidatorMessages.CriticalMessages.Count > 0 Then
                    Throw New ValidationException(Me)
                End If

    End Sub

End Class

End Namespace

End Namespace
