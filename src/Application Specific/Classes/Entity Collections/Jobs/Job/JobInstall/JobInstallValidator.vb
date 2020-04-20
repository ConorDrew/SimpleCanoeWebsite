Namespace Entity

    Namespace JobInstalls

        Public Class JobInstallValidator
            'make sure that contact object is valid
            Inherits BaseValidator

            Public Sub Validate(ByVal oJobInstall As JobInstall)

                'make sure that contact object is valid
                If oJobInstall.Errors.Count > 0 Then
                    Dim de As DictionaryEntry
                    For Each de In oJobInstall.Errors
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
