Namespace Entity

    Namespace StandardSentences

        Public Class StandardSentenceValidator
            'make sure that  object is valid
            Inherits BaseValidator

            Public Sub Validate(ByVal oStandardSentence As StandardSentence)

                'make sure that contact object is valid
                If oStandardSentence.Errors.Count > 0 Then
                    Dim de As DictionaryEntry
                    For Each de In oStandardSentence.Errors
                        Me.AddCriticalMessage(CStr(de.Value))
                    Next
                End If

                If oStandardSentence.Sentence.Trim.Length = 0 Then
                    Me.AddCriticalMessage("Sentence Missing")

                End If

                If Me.ValidatorMessages.CriticalMessages.Count > 0 Then
                    Throw New ValidationException(Me)
                End If

            End Sub

        End Class

    End Namespace

End Namespace
