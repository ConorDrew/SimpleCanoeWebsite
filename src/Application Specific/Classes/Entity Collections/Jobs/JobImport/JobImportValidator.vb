Namespace Entity.JobImport
    Public Class JobImportTypeValidator
        Inherits BaseValidator

        Public Sub Validate(ByVal oJobImportType As JobImportType)

            'make sure that contact object is valid
            If oJobImportType.Errors.Count > 0 Then
                Dim de As DictionaryEntry
                For Each de In oJobImportType.Errors
                    Me.AddCriticalMessage(CStr(de.Value))
                Next
            End If

            With oJobImportType
                If .Name.Trim.Length = 0 Then
                    Me.AddCriticalMessage("Job Import Type missing name")
                End If
                If .JobTypeID = 0 Then
                    Me.AddCriticalMessage("Job Type missing")
                End If
                If .Cycle = 0 Then
                    Me.AddCriticalMessage("Cycle missing")
                End If
                If .Cycle < 0 Then
                    Me.AddCriticalMessage("Cycle incorrect")
                End If
                If .Cycle > 20 Then
                    Me.AddCriticalMessage("Cycle incorrect")
                End If
            End With

            If Me.ValidatorMessages.CriticalMessages.Count > 0 Then
                Throw New ValidationException(Me)
            End If

        End Sub

    End Class
End Namespace

