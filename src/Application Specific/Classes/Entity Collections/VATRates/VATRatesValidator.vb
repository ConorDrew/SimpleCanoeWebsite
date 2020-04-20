Namespace Entity

Namespace VATRatess

Public Class VATRatesValidator
    'make sure that contact object is valid
    Inherits BaseValidator

    Public Sub Validate(ByVal oVATRates As VATRates)

        'make sure that contact object is valid
        If oVATRates.Errors.Count > 0 Then
            Dim de As DictionaryEntry
            For Each de In oVATRates.Errors
                Me.AddCriticalMessage(CStr(de.Value))
            Next
        End If

                If oVATRates.VATRateCode.Trim.Length = 0 Then
                    Me.AddCriticalMessage("Code Missing")
                End If
	
        If Me.ValidatorMessages.CriticalMessages.Count > 0 Then
            Throw New ValidationException(Me)
        End If

    End Sub

End Class

End Namespace

End Namespace
