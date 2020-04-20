Namespace Entity

Namespace PartTransactions

Public Class PartTransactionValidator
    'make sure that contact object is valid
    Inherits BaseValidator

    Public Sub Validate(ByVal oPartTransaction As PartTransaction)

        'make sure that contact object is valid
        If oPartTransaction.Errors.Count > 0 Then
            Dim de As DictionaryEntry
            For Each de In oPartTransaction.Errors
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
