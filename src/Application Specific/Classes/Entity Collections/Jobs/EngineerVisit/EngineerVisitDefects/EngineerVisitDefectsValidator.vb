Namespace Entity

Namespace EngineerVisitDefectss

Public Class EngineerVisitDefectsValidator
    'make sure that contact object is valid
    Inherits BaseValidator

    Public Sub Validate(ByVal oEngineerVisitDefects As EngineerVisitDefects)

        'make sure that contact object is valid
        If oEngineerVisitDefects.Errors.Count > 0 Then
            Dim de As DictionaryEntry
            For Each de In oEngineerVisitDefects.Errors
                Me.AddCriticalMessage(CStr(de.Value))
            Next
        End If

                If oEngineerVisitDefects.CategoryID = 0 Then
                    Me.AddCriticalMessage("Category Missing")
                End If

                If Me.ValidatorMessages.CriticalMessages.Count > 0 Then
                    Throw New ValidationException(Me)
                End If

    End Sub

End Class

End Namespace

End Namespace
