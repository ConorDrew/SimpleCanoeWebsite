Namespace Entity

Namespace CustomerScheduleOfRates

Public Class CustomerScheduleOfRateValidator
    'make sure that contact object is valid
    Inherits BaseValidator

    Public Sub Validate(ByVal oCustomerScheduleOfRate As CustomerScheduleOfRate)

        'make sure that contact object is valid
        If oCustomerScheduleOfRate.Errors.Count > 0 Then
            Dim de As DictionaryEntry
            For Each de In oCustomerScheduleOfRate.Errors
                Me.AddCriticalMessage(CStr(de.Value))
            Next
        End If

                If oCustomerScheduleOfRate.ScheduleOfRatesCategoryID = 0 Then
                    Me.AddCriticalMessage("* Category is missing")
                End If

                If oCustomerScheduleOfRate.Description.Trim.Length = 0 Then
                    Me.AddCriticalMessage("* Description is missing")
                End If

                If Not IsNumeric(oCustomerScheduleOfRate.Price) Then
                    Me.AddCriticalMessage("* Price must be numeric")
                End If

                If Not IsNumeric(oCustomerScheduleOfRate.TimeInMins) Then
                    Me.AddCriticalMessage("* Time must be numeric")
                End If

                If Me.ValidatorMessages.CriticalMessages.Count > 0 Then
                    Throw New ValidationException(Me)
                End If

    End Sub

End Class

End Namespace

End Namespace
