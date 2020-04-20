Namespace Entity

Namespace ProductTransactions

Public Class ProductTransactionValidator
    'make sure that contact object is valid
    Inherits BaseValidator

    Public Sub Validate(ByVal oProductTransaction As ProductTransaction)

        'make sure that contact object is valid
        If oProductTransaction.Errors.Count > 0 Then
            Dim de As DictionaryEntry
            For Each de In oProductTransaction.Errors
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
