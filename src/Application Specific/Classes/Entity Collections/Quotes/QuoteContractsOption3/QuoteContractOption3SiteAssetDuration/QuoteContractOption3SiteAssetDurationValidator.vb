Namespace Entity

    Namespace QuoteContractOption3SiteAssetDurations

        Public Class QuoteContractOption3SiteAssetDurationValidator
            'make sure that contact object is valid
            Inherits BaseValidator

            Public Sub Validate(ByVal oQuoteContractOption3SiteAssetDuration As QuoteContractOption3SiteAssetDuration)

                'make sure that contact object is valid
                If oQuoteContractOption3SiteAssetDuration.Errors.Count > 0 Then
                    Dim de As DictionaryEntry
                    For Each de In oQuoteContractOption3SiteAssetDuration.Errors
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
