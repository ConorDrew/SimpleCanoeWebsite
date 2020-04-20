Namespace Entity

    Namespace Notes

        Public Class NotesValidator
            'make sure that contact object is valid
            Inherits BaseValidator

            Public Sub Validate(ByVal oNotes As Notes)

                'make sure that contact object is valid
                If oNotes.Errors.Count > 0 Then
                    Dim de As DictionaryEntry
                    For Each de In oNotes.Errors
                        Me.AddCriticalMessage(CStr(de.Value))
                    Next
                End If

                If Not oNotes.CategoryID > 0 Then
                    Me.AddCriticalMessage("* Category Missing")
                End If
                If oNotes.Note.Trim.Length = 0 Then
                    Me.AddCriticalMessage("* Note Missing")
                End If
                If oNotes.UserIDFor = 0 Then
                    Me.AddCriticalMessage("* User For Missing")
                End If

                If Me.ValidatorMessages.CriticalMessages.Count > 0 Then
                    Throw New ValidationException(Me)
                End If

            End Sub

        End Class

    End Namespace

End Namespace
