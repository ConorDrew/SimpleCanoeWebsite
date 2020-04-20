Namespace Entity

Namespace JobOfWorks

Public Class JobOfWorkValidator
    'make sure that contact object is valid
    Inherits BaseValidator

    Public Sub Validate(ByVal oJobOfWork As JobOfWork)

        'make sure that contact object is valid
        If oJobOfWork.Errors.Count > 0 Then
            Dim de As DictionaryEntry
            For Each de In oJobOfWork.Errors
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
