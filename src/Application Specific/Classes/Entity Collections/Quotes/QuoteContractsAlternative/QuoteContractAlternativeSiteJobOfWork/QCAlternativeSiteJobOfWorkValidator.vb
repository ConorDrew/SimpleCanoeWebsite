Namespace Entity

    Namespace QuoteContractAlternativeSiteJobOfWorks

        Public Class QuoteContractAlternativeSiteJobOfWorkValidator
            'make sure that contact object is valid
            Inherits BaseValidator

            Public Sub Validate(ByVal oQuoteContractAlternativeSiteJobOfWork As QuoteContractAlternativeSiteJobOfWork)

                'make sure that contact object is valid
                If oQuoteContractAlternativeSiteJobOfWork.Errors.Count > 0 Then
                    Dim de As DictionaryEntry
                    For Each de In oQuoteContractAlternativeSiteJobOfWork.Errors
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
