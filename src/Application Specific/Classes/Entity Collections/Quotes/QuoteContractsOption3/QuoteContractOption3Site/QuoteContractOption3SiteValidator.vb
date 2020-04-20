Namespace Entity

    Namespace QuoteContractOption3Sites

        Public Class QuoteContractOption3SiteValidator
            'make sure that contact object is valid
            Inherits BaseValidator

            Public Sub Validate(ByVal oQuoteContractOption3Site As QuoteContractOption3Site, _
            ByVal assets As DataView)

                'make sure that contact object is valid
                If oQuoteContractOption3Site.Errors.Count > 0 Then
                    Dim de As DictionaryEntry
                    For Each de In oQuoteContractOption3Site.Errors
                        Me.AddCriticalMessage(CStr(de.Value))
                    Next
                End If

                If oQuoteContractOption3Site.QuoteContractSiteReference.Trim.Length = 0 Then
                    Me.AddCriticalMessage("* Site Reference Required")
                End If

                If Not (oQuoteContractOption3Site.StartDate < oQuoteContractOption3Site.EndDate) Then
                    Me.AddCriticalMessage("* End Date must be greater than Start Date")
                End If

                If oQuoteContractOption3Site.FirstVisitDate() < oQuoteContractOption3Site.StartDate Or _
                     oQuoteContractOption3Site.FirstVisitDate > oQuoteContractOption3Site.EndDate Then
                    Me.AddCriticalMessage("* First Visit Date must be between Start Date and End Date")
                End If

                If oQuoteContractOption3Site.VisitFrequencyID = 0 Then
                    Me.AddCriticalMessage("* Visit Frequency Required")
                End If

                If assets.Table.Columns.Count < 16 Then
                    Me.AddCriticalMessage("* Please load and fill in the assets schedule.")
                End If

                If Me.ValidatorMessages.CriticalMessages.Count > 0 Then
                    Throw New ValidationException(Me)
                End If


            End Sub

        End Class

    End Namespace

End Namespace
