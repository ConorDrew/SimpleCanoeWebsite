Namespace Entity

Namespace EngineerVisitCharges

Public Class EngineerVisitChargeValidator
    'make sure that contact object is valid
    Inherits BaseValidator

    Public Sub Validate(ByVal oEngineerVisitCharge As EngineerVisitCharge)

        'make sure that contact object is valid
        If oEngineerVisitCharge.Errors.Count > 0 Then
            Dim de As DictionaryEntry
            For Each de In oEngineerVisitCharge.Errors
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
