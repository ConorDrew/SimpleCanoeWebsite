Namespace Entity


Namespace InvoiceToBeRaiseds

Public Class InvoiceToBeRaisedValidator
    'make sure that contact object is valid
    Inherits BaseValidator

    Public Sub Validate(ByVal oInvoiceToBeRaised As InvoiceToBeRaised)

        'make sure that contact object is valid
        If oInvoiceToBeRaised.Errors.Count > 0 Then
            Dim de As DictionaryEntry
            For Each de In oInvoiceToBeRaised.Errors
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
