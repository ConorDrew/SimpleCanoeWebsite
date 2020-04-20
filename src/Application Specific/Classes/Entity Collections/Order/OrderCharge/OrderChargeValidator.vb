Namespace Entity

Namespace OrderCharges

Public Class OrderChargeValidator
    'make sure that contact object is valid
    Inherits BaseValidator

    Public Sub Validate(ByVal oOrderCharge As OrderCharge)

        'make sure that contact object is valid
        If oOrderCharge.Errors.Count > 0 Then
            Dim de As DictionaryEntry
            For Each de In oOrderCharge.Errors
                Me.AddCriticalMessage(CStr(de.Value))
            Next
                End If

                'If oOrderCharge.OrderID = 0 Then
                '    Me.AddCriticalMessage("Order Missing")
                'End If
                If oOrderCharge.OrderChargeTypeID = 0 Then
                    Me.AddCriticalMessage("Charge Type Missing")
                End If
                If Not oOrderCharge.Amount > 0 Then
                    Me.AddCriticalMessage("Amount Missing")
                End If



                If Me.ValidatorMessages.CriticalMessages.Count > 0 Then
                    Throw New ValidationException(Me)
                End If
    End Sub

End Class

End Namespace

End Namespace
