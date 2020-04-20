Namespace Entity

Namespace ContractOriginalSiteRatess

Public Class ContractOriginalSiteRatesValidator
    'make sure that contact object is valid
    Inherits BaseValidator

    Public Sub Validate(ByVal oContractOriginalSiteRates As ContractOriginalSiteRates)

        'make sure that contact object is valid
        If oContractOriginalSiteRates.Errors.Count > 0 Then
            Dim de As DictionaryEntry
            For Each de In oContractOriginalSiteRates.Errors
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
