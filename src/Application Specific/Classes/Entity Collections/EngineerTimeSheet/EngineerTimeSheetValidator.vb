Namespace Entity

    Namespace EngineerTimeSheets

        Public Class EngineerTimeSheetValidator
            'make sure that contact object is valid
            Inherits BaseValidator

            Public Sub Validate(ByVal oEngineerTimeSheet As EngineerTimeSheet)

                'make sure that contact object is valid
                If oEngineerTimeSheet.Errors.Count > 0 Then
                    Dim de As DictionaryEntry
                    For Each de In oEngineerTimeSheet.Errors
                        Me.AddCriticalMessage(CStr(de.Value))
                    Next
                End If

                If oEngineerTimeSheet.EngineerID = 0 Then
                    AddCriticalMessage("Engineer Missing")
                End If

                If oEngineerTimeSheet.TimeSheetTypeID = 0 Then
                    AddCriticalMessage("Type Missing")
                End If

                If CDate(Format(oEngineerTimeSheet.StartDateTime, "dd/MM/yyyy HH:mm")) >= _
                                    CDate(Format(oEngineerTimeSheet.EndDateTime, "dd/MM/yyyy HH:mm")) Then
                    AddCriticalMessage("End Date/Time must be greater than Start Date/Time Missing")
                End If


                If Me.ValidatorMessages.CriticalMessages.Count > 0 Then
                    Throw New ValidationException(Me)
                End If

            End Sub

        End Class

    End Namespace

End Namespace
