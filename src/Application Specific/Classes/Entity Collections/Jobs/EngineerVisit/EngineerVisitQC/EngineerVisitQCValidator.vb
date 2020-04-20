Namespace Entity

Namespace EngineerVisitQCs

Public Class EngineerVisitQCValidator
    'make sure that contact object is valid
    Inherits BaseValidator

    Public Sub Validate(ByVal oEngineerVisitQC As EngineerVisitQC)

        'make sure that contact object is valid
        If oEngineerVisitQC.Errors.Count > 0 Then
            Dim de As DictionaryEntry
            For Each de In oEngineerVisitQC.Errors
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
