Namespace Entity

    Namespace CustomerCharges

        Public Class CustomerChargeValidator
            'make sure that contact object is valid
            Inherits BaseValidator

            Public Sub Validate(ByVal oCustomerCharge As CustomerCharge)

                'make sure that contact object is valid
                If oCustomerCharge.Errors.Count > 0 Then
                    Dim de As DictionaryEntry
                    For Each de In oCustomerCharge.Errors
                        Me.AddCriticalMessage(CStr(de.Value))
                    Next
                End If

                If oCustomerCharge.MileageRate = 0 Then
                    Me.AddCriticalMessage("Mileage Rate Missing")
                End If

                If Not IsNumeric(oCustomerCharge.MileageRate) Then
                    Me.AddCriticalMessage("Mileage Rate Invalid")
                End If

                If Not IsNumeric(oCustomerCharge.PartsMarkup) Then
                    Me.AddCriticalMessage("Parts Markup Invalid")
                End If

                If Not IsNumeric(oCustomerCharge.RatesMarkup) Then
                    Me.AddCriticalMessage("Rates Markup Invalid")
                End If

                If Me.ValidatorMessages.CriticalMessages.Count > 0 Then
                    Throw New ValidationException(Me)
                End If

            End Sub

        End Class

    End Namespace

End Namespace
