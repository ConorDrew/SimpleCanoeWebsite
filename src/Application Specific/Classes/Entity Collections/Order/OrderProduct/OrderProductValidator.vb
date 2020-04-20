Namespace Entity

Namespace OrderProducts

Public Class OrderProductValidator
    'make sure that contact object is valid
    Inherits BaseValidator

    Public Sub Validate(ByVal oOrderProduct As OrderProduct)

        'make sure that contact object is valid
        If oOrderProduct.Errors.Count > 0 Then
            Dim de As DictionaryEntry
            For Each de In oOrderProduct.Errors
                Me.AddCriticalMessage(CStr(de.Value))
            Next
        End If

                If Not oOrderProduct.Quantity > 0 Then
                    Me.AddCriticalMessage("Quantity must be greater than 0")
                End If

                If Me.ValidatorMessages.CriticalMessages.Count > 0 Then
                    Throw New ValidationException(Me)
                End If

    End Sub

End Class

End Namespace

End Namespace
