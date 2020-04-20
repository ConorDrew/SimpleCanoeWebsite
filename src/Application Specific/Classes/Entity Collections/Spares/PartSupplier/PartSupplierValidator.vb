Namespace Entity

Namespace PartSuppliers

Public Class PartSupplierValidator
    'make sure that contact object is valid
    Inherits BaseValidator

    Public Sub Validate(ByVal oPartSupplier As PartSupplier)

                'make sure that contact object is valid
                If oPartSupplier.Errors.Count > 0 Then
                    Dim de As DictionaryEntry
                    For Each de In oPartSupplier.Errors
                        Me.AddCriticalMessage(CStr(de.Value))
                    Next
                End If

                'If oPartSupplier.PartCode.Trim.Length = 0 Then
                '    Me.AddCriticalMessage("Part Code Missing")
                'End If

                If oPartSupplier.SupplierID <= 0 Then
                    Me.AddCriticalMessage("Supplier Missing")
                End If

                If oPartSupplier.QuantityInPack < 1 Then
                    Me.AddCriticalMessage("Invalid Quantity In Pack")
                End If

                If oPartSupplier.Price <= 0 Then
                    Me.AddCriticalMessage("Invalid Price")
                End If

                If Me.ValidatorMessages.CriticalMessages.Count > 0 Then
                    Throw New ValidationException(Me)
                End If

            End Sub

End Class

End Namespace

End Namespace
