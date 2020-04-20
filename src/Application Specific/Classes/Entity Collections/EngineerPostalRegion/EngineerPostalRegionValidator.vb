Namespace Entity

    Namespace EngineerPostalRegions

        Public Class EngineerPostalRegionValidator
            'make sure that contact object is valid
            Inherits BaseValidator

            Public Sub Validate(ByVal oEngineerPostalRegion As EngineerPostalRegion)

                'make sure that contact object is valid
                If oEngineerPostalRegion.Errors.Count > 0 Then
                    Dim de As DictionaryEntry
                    For Each de In oEngineerPostalRegion.Errors
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
