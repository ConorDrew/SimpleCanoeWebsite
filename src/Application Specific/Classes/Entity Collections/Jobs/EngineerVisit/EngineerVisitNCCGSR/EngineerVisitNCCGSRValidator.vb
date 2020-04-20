Namespace Entity

Namespace EngineerVisitNCCGSRs

Public Class EngineerVisitNCCGSRValidator
    'make sure that contact object is valid
    Inherits BaseValidator

    Public Sub Validate(ByVal oEngineerVisitNCCGSR As EngineerVisitNCCGSR)

        'make sure that contact object is valid
        If oEngineerVisitNCCGSR.Errors.Count > 0 Then
            Dim de As DictionaryEntry
            For Each de In oEngineerVisitNCCGSR.Errors
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
