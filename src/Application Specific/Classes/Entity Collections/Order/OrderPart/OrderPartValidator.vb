Namespace Entity

Namespace OrderParts

Public Class OrderPartValidator
    'make sure that contact object is valid
    Inherits BaseValidator

    Public Sub Validate(ByVal oOrderPart As OrderPart)

        'make sure that contact object is valid
        If oOrderPart.Errors.Count > 0 Then
            Dim de As DictionaryEntry
            For Each de In oOrderPart.Errors
                Me.AddCriticalMessage(CStr(de.Value))
            Next
        End If

                If Not oOrderPart.Quantity > 0 Then
                    Me.AddCriticalMessage("Quantity must be greater than 0")
                End If
                If IsDBNull(oOrderPart.BuyPrice) Then
                    Me.AddCriticalMessage("Buy Price not entered")
                End If
                If IsDBNull(oOrderPart.SellPrice) Then
                    Me.AddCriticalMessage("Sell Price not entered")
                End If

                If Me.ValidatorMessages.CriticalMessages.Count > 0 Then
                    Throw New ValidationException(Me)
                End If

    End Sub

End Class

End Namespace

End Namespace
