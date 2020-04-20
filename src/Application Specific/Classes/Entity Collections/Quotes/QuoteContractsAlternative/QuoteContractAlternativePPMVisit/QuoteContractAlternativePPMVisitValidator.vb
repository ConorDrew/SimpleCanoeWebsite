Namespace Entity

    Namespace QuoteContractAlternativePPMVisits

        Public Class QuoteContractAlternativePPMVisitValidator
            'make sure that contact object is valid
            Inherits BaseValidator

            Public Sub Validate(ByVal oQuoteContractPPMVisit As QuoteContractAlternativePPMVisit)

                'make sure that contact object is valid
                If oQuoteContractPPMVisit.Errors.Count > 0 Then
                    Dim de As DictionaryEntry
                    For Each de In oQuoteContractPPMVisit.Errors
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
