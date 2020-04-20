Namespace Entity

    Namespace QuoteContractAlternativeSiteJobItems

        Public Class QuoteContractAlternativeSiteJobItemsValidator
            'make sure that contact object is valid
            Inherits BaseValidator

            Public Sub Validate(ByVal oQuoteContractAlternativeSiteJobItems As QuoteContractAlternativeSiteJobItems)

                'make sure that contact object is valid
                If oQuoteContractAlternativeSiteJobItems.Errors.Count > 0 Then
                    Dim de As DictionaryEntry
                    For Each de In oQuoteContractAlternativeSiteJobItems.Errors
                        Me.AddCriticalMessage(CStr(de.Value))
                    Next
                End If

                If oQuoteContractAlternativeSiteJobItems.VisitFrequencyID = 0 Then
                    AddCriticalMessage("Visit Frequency Missing")
                End If


                If Me.ValidatorMessages.CriticalMessages.Count > 0 Then
                    Throw New ValidationException(Me)
                End If

            End Sub

        End Class

    End Namespace

End Namespace
