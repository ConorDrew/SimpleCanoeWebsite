Namespace Entity

    Namespace SystemScheduleOfRates

        Public Class SystemScheduleOfRateValidator
            'make sure that contact object is valid
            Inherits BaseValidator

            Public Sub Validate(ByVal oSystemScheduleOfRate As SystemScheduleOfRate)

                'make sure that contact object is valid
                If oSystemScheduleOfRate.Errors.Count > 0 Then
                    Dim de As DictionaryEntry
                    For Each de In oSystemScheduleOfRate.Errors
                        Me.AddCriticalMessage(CStr(de.Value))
                    Next
                End If

                If oSystemScheduleOfRate.Description.Length = 0 Then
                    Me.AddCriticalMessage("* Description is missing")
                End If

                If oSystemScheduleOfRate.ScheduleOfRatesCategoryID = 0 Then
                    Me.AddCriticalMessage("* Category is missing")
                End If

                If Not IsNumeric(oSystemScheduleOfRate.Price) Then
                    Me.AddCriticalMessage("* Price must be numeric")
                End If

                If Not IsNumeric(oSystemScheduleOfRate.TimeInMins) Then
                    Me.AddCriticalMessage("* Time must be numeric")
                End If

                If Me.ValidatorMessages.CriticalMessages.Count > 0 Then
                    Throw New ValidationException(Me)
                End If

            End Sub

        End Class

    End Namespace

End Namespace
