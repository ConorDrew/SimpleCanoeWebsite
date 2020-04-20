Namespace Entity

    Namespace QuoteContractAlternativeSiteAssets

        Public Class QuoteContractAlternativeSiteAssetValidator
            'make sure that contact object is valid
            Inherits BaseValidator

            Public Sub Validate(ByVal oQuoteContractSiteAsset As QuoteContractAlternativeSiteAsset)

                'make sure that contact object is valid
                If oQuoteContractSiteAsset.Errors.Count > 0 Then
                    Dim de As DictionaryEntry
                    For Each de In oQuoteContractSiteAsset.Errors
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
