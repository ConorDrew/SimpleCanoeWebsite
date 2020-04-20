Namespace Entity

Namespace QuoteOrderProducts

Public Class QuoteOrderProductValidator
    'make sure that contact object is valid
    Inherits BaseValidator

    Public Sub Validate(ByVal oQuoteOrderProduct As QuoteOrderProduct)

        'make sure that contact object is valid
        If oQuoteOrderProduct.Errors.Count > 0 Then
            Dim de As DictionaryEntry
            For Each de In oQuoteOrderProduct.Errors
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
