Namespace Entity

Namespace JobItems

Public Class JobItemValidator
    'make sure that contact object is valid
    Inherits BaseValidator

    Public Sub Validate(ByVal oJobItem As JobItem)

        'make sure that contact object is valid
        If oJobItem.Errors.Count > 0 Then
            Dim de As DictionaryEntry
            For Each de In oJobItem.Errors
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
