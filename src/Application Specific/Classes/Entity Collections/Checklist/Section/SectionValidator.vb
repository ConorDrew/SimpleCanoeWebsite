Namespace Entity

Namespace Sections

Public Class SectionValidator
    'make sure that contact object is valid
    Inherits BaseValidator

    Public Sub Validate(ByVal oSection As Section)

        'make sure that contact object is valid
        If oSection.Errors.Count > 0 Then
            Dim de As DictionaryEntry
            For Each de In oSection.Errors
                Me.AddCriticalMessage(CStr(de.Value))
            Next
                End If

                If oSection.Description.Trim.Length = 0 Then
                    Me.AddCriticalMessage("Description Missing")
                End If

                If Me.ValidatorMessages.CriticalMessages.Count > 0 Then
                    Throw New ValidationException(Me)
                End If

    End Sub

End Class

End Namespace

End Namespace
