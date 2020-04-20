Namespace Entity

    Namespace ProductAssociatedParts

        Public Class ProductAssociatedPartValidator
            'make sure that contact object is valid
            Inherits BaseValidator

            Public Sub Validate(ByVal oProductAssociatedPart As ProductAssociatedPart)

                'make sure that contact object is valid
                If oProductAssociatedPart.Errors.Count > 0 Then
                    Dim de As DictionaryEntry
                    For Each de In oProductAssociatedPart.Errors
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
