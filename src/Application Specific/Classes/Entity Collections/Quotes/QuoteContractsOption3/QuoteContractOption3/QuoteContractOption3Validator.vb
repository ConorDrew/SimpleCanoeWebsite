Namespace Entity

Namespace QuoteContractOption3s

Public Class QuoteContractOption3Validator
    'make sure that contact object is valid
    Inherits BaseValidator

    Public Sub Validate(ByVal oQuoteContractOption3 As QuoteContractOption3)

        'make sure that contact object is valid
        If oQuoteContractOption3.Errors.Count > 0 Then
            Dim de As DictionaryEntry
            For Each de In oQuoteContractOption3.Errors
                Me.AddCriticalMessage(CStr(de.Value))
            Next
        End If

                If oQuoteContractOption3.QuoteContractReference.Trim.Length = 0 Then
                    AddCriticalMessage("* Quote Contract Referenece is required")
                End If

                If InStr(oQuoteContractOption3.QuoteContractReference, "-") > 0 Then
                    AddCriticalMessage("* Quote Contract Referenece cannot contain '-'.")
                End If

                If oQuoteContractOption3.QuoteContractStatusID = 0 Then
                    AddCriticalMessage("* Quote Status is required")
                End If


                If Me.ValidatorMessages.CriticalMessages.Count > 0 Then
                    Throw New ValidationException(Me)
                End If

    End Sub

End Class

End Namespace

End Namespace
