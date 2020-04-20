Namespace Entity

Namespace SubTasks

Public Class SubTaskValidator
    'make sure that contact object is valid
    Inherits BaseValidator

    Public Sub Validate(ByVal oSubTask As SubTask)

        'make sure that contact object is valid
        If oSubTask.Errors.Count > 0 Then
            Dim de As DictionaryEntry
            For Each de In oSubTask.Errors
                Me.AddCriticalMessage(CStr(de.Value))
            Next
                End If

                If oSubTask.Description.Trim.Length = 0 Then
                    Me.AddCriticalMessage("Description Missing")
                End If

                If Me.ValidatorMessages.CriticalMessages.Count > 0 Then
                    Throw New ValidationException(Me)
                End If

    End Sub

End Class

End Namespace

End Namespace
