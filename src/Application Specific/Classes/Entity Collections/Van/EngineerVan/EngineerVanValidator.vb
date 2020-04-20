Namespace Entity

    Namespace EngineerVans

        Public Class EngineerVanValidator
            'make sure that contact object is valid
            Inherits BaseValidator

            Public Sub Validate(ByVal oEngineerVan As EngineerVan)

                'make sure that contact object is valid
                If oEngineerVan.Errors.Count > 0 Then
                    Dim de As DictionaryEntry
                    For Each de In oEngineerVan.Errors
                        Me.AddCriticalMessage(CStr(de.Value))
                    Next
                End If

                If oEngineerVan.VanID = 0 Then
                    Me.AddCriticalMessage("Van Missing")
                End If
                If oEngineerVan.EngineerID = 0 Then
                    Me.AddCriticalMessage("Engineer Missing")
                End If
                If Not oEngineerVan.EndDateTime = Nothing Then
                    If Not oEngineerVan.StartDateTime < oEngineerVan.EndDateTime Then
                        Me.AddCriticalMessage("Start Date Time Must Be Before End Date Time")
                    End If
                End If

                If Me.ValidatorMessages.CriticalMessages.Count > 0 Then
                    Throw New ValidationException(Me)
                End If

            End Sub

        End Class

    End Namespace

End Namespace
