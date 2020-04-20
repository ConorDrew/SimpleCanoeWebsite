Namespace Entity

    Namespace QuoteContractOriginalSites

        Public Class QuoteContractOriginalSiteValidator

            'make sure that contact object is valid
            Inherits BaseValidator


            Public Sub Validate(ByVal oQuoteContractSite As QuoteContractOriginalSite)

                'make sure that contact object is valid
                If oQuoteContractSite.Errors.Count > 0 Then
                    Dim de As DictionaryEntry
                    For Each de In oQuoteContractSite.Errors
                        Me.AddCriticalMessage(CStr(de.Value))
                    Next
                End If

                If oQuoteContractSite.VisitFrequencyID = 0 Then
                    AddCriticalMessage("Visit Frequency Missing")
                End If

                If Me.ValidatorMessages.CriticalMessages.Count > 0 Then
                    Throw New ValidationException(Me)
                End If

            End Sub

        End Class

    End Namespace

End Namespace
