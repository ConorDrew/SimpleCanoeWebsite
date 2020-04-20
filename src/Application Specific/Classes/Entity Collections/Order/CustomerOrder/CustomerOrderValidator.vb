Namespace Entity

Namespace CustomerOrders

Public Class CustomerOrderValidator
    'make sure that contact object is valid
    Inherits BaseValidator

    Public Sub Validate(ByVal oCustomerOrder As CustomerOrder)

        'make sure that contact object is valid
        If oCustomerOrder.Errors.Count > 0 Then
            Dim de As DictionaryEntry
            For Each de In oCustomerOrder.Errors
                Me.AddCriticalMessage(CStr(de.Value))
            Next
        End If

        
	
        If Me.ValidatorMessages.CriticalMessages.Count > 0 Then
            Throw New ValidationException(Me)
        End If

    End Sub

End Class

End Namespace

End Namespace
