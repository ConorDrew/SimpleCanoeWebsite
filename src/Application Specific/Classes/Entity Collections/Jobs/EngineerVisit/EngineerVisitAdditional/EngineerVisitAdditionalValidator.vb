Namespace Entity

    Namespace EngineerVisitAdditionals

        Public Class EngineerVisitAdditionalValidator
            'make sure that contact object is valid
            Inherits BaseValidator

            Public Sub Validate(ByVal oEngineerVisitAdditional As EngineerVisitAdditional)

                'make sure that contact object is valid
                If oEngineerVisitAdditional.Errors.Count > 0 Then
                    Dim de As DictionaryEntry
                    For Each de In oEngineerVisitAdditional.Errors
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
