Namespace Entity

Namespace Locationss

Public Class LocationsValidator
    'make sure that contact object is valid
    Inherits BaseValidator

    Public Sub Validate(ByVal oLocations As Locations)

        'make sure that contact object is valid
        If oLocations.Errors.Count > 0 Then
            Dim de As DictionaryEntry
            For Each de In oLocations.Errors
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
