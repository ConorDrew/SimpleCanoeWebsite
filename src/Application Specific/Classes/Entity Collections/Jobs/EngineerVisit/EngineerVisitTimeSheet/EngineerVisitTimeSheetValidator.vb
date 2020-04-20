Namespace Entity

Namespace EngineerVisitTimeSheets

Public Class EngineerVisitTimeSheetValidator
    'make sure that contact object is valid
    Inherits BaseValidator

    Public Sub Validate(ByVal oEngineerVisitTimeSheet As EngineerVisitTimeSheet)

        'make sure that contact object is valid
        If oEngineerVisitTimeSheet.Errors.Count > 0 Then
            Dim de As DictionaryEntry
            For Each de In oEngineerVisitTimeSheet.Errors
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
