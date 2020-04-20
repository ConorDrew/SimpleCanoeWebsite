Namespace Entity

Namespace Tasks

Public Class TaskValidator
    'make sure that contact object is valid
    Inherits BaseValidator

    Public Sub Validate(ByVal oTask As Task)

        'make sure that contact object is valid
        If oTask.Errors.Count > 0 Then
            Dim de As DictionaryEntry
            For Each de In oTask.Errors
                Me.AddCriticalMessage(CStr(de.Value))
            Next
        End If

                If oTask.Description.Trim.Length = 0 Then
                    Me.AddCriticalMessage("Description Missing")
                End If

                If Me.ValidatorMessages.CriticalMessages.Count > 0 Then
                    Throw New ValidationException(Me)
                End If

    End Sub

End Class

End Namespace

End Namespace
