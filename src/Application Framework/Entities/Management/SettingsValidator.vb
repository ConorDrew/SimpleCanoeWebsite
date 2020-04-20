Namespace Entity

    Namespace Management

        Public Class SettingsValidator : Inherits BaseValidator

            Public Sub Validate(ByVal settings As Entity.Management.Settings)
                If settings.Errors.Count > 0 Then
                    Dim de As DictionaryEntry
                    For Each de In settings.Errors
                        Me.AddCriticalMessage(CStr(de.Value))
                    Next
                End If

                Dim checkDay As Boolean = True
                If settings.WorkingHoursStart.Trim.Length = 0 Then
                    Me.AddCriticalMessage("Working Hours Start Missing")
                    checkDay = True
                End If
                If settings.WorkingHoursEnd.Trim.Length = 0 Then
                    Me.AddCriticalMessage("Working Hours End Missing")
                    checkDay = True
                End If
                If checkDay Then
                    Dim sd As DateTime = New DateTime(Now.Year, Now.Month, Now.Day, settings.WorkingHoursStart.Trim.Substring(0, 2), settings.WorkingHoursStart.Trim.Substring(3, 2), 0)
                    Dim ed As DateTime = New DateTime(Now.Year, Now.Month, Now.Day, settings.WorkingHoursEnd.Trim.Substring(0, 2), settings.WorkingHoursEnd.Trim.Substring(3, 2), 0)

                    If sd >= ed Then
                        Me.AddCriticalMessage("Working Hours End must be after the Start")
                    End If
                End If

                If settings.MileageRate = 0 Then
                    Me.AddCriticalMessage("Mileage Rate Missing")
                End If
                If Not IsNumeric(settings.MileageRate) Then
                    Me.AddCriticalMessage("Mileage Rate Invalid")
                End If
                If settings.PartsMarkup = 0 Then
                    Me.AddCriticalMessage("Parts Markup Missing")
                End If
                If Not IsNumeric(settings.PartsMarkup) Then
                    Me.AddCriticalMessage("Parts Markup Invalid")
                End If
                If settings.RatesMarkup = 0 Then
                    Me.AddCriticalMessage("Rates Markup Missing")
                End If
                If Not IsNumeric(settings.RatesMarkup) Then
                    Me.AddCriticalMessage("Rates Markup Invalid")
                End If

                If settings.CalloutPrefix.Trim.Length = 0 Then
                    Me.AddCriticalMessage("Callout Prefix Missing")
                End If
                If settings.MiscPrefix.Trim.Length = 0 Then
                    Me.AddCriticalMessage("Miscellaneous Prefix Missing")
                End If
                If settings.PPMPrefix.Trim.Length = 0 Then
                    Me.AddCriticalMessage("PPM Prefix Missing")
                End If
                If settings.QuotePrefix.Trim.Length = 0 Then
                    Me.AddCriticalMessage("Quote Prefix Missing")
                End If

                If settings.ServiceFromLetterPrefix.Trim.Length = 0 Then
                    Me.AddCriticalMessage("Service From Letter Prefix Missing")
                End If

                If Me.ValidatorMessages.CriticalMessages.Count > 0 Then
                    Throw New ValidationException(Me)
                End If
            End Sub

        End Class

    End Namespace

End Namespace