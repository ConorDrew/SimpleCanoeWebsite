Namespace Entity

Namespace ProductSuppliers

Public Class ProductSupplierValidator
    'make sure that contact object is valid
    Inherits BaseValidator

    Public Sub Validate(ByVal oProductSupplier As ProductSupplier)

        'make sure that contact object is valid
        If oProductSupplier.Errors.Count > 0 Then
            Dim de As DictionaryEntry
            For Each de In oProductSupplier.Errors
                Me.AddCriticalMessage(CStr(de.Value))
            Next
        End If

                'If oProductSupplier.ProductCode.Trim.Length = 0 Then
                '    Me.AddCriticalMessage("*Product Code Missing")
                'End If

                If oProductSupplier.SupplierID <= 0 Then
                    Me.AddCriticalMessage("*Supplier Missing")
                End If

                If oProductSupplier.QuantityInPack < 1 Then
                    Me.AddCriticalMessage("*Invalid Quantity In Pack")
                End If

                If oProductSupplier.Price <= 0 Then
                    Me.AddCriticalMessage("*Invalid Price")
                End If

                If Me.ValidatorMessages.CriticalMessages.Count > 0 Then
                    Throw New ValidationException(Me)
                End If

    End Sub

End Class

End Namespace

End Namespace
