Namespace Entity

Namespace JobAssets

Public Class JobAssetValidator
    'make sure that contact object is valid
    Inherits BaseValidator

    Public Sub Validate(ByVal oJobAsset As JobAsset)

        'make sure that contact object is valid
        If oJobAsset.Errors.Count > 0 Then
            Dim de As DictionaryEntry
            For Each de In oJobAsset.Errors
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
