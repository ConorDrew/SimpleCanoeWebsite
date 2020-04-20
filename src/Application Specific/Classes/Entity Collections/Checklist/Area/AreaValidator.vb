Namespace Entity

Namespace Areas

Public Class AreaValidator
    'make sure that contact object is valid
    Inherits BaseValidator

    Public Sub Validate(ByVal oArea As Area)

        'make sure that contact object is valid
        If oArea.Errors.Count > 0 Then
            Dim de As DictionaryEntry
            For Each de In oArea.Errors
                Me.AddCriticalMessage(CStr(de.Value))
            Next
                End If

                If oArea.Description.Trim.Length = 0 Then
                    Me.AddCriticalMessage("Description Missing")
                End If

                If Me.ValidatorMessages.CriticalMessages.Count > 0 Then
                    Throw New ValidationException(Me)
                End If

    End Sub

End Class

End Namespace

End Namespace
