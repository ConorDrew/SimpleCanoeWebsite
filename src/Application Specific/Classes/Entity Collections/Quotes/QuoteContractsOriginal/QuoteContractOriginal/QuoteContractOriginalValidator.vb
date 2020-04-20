Namespace Entity

    Namespace QuoteContractOriginals

        Public Class QuoteContractOriginalValidator
            'make sure that contact object is valid
            Inherits BaseValidator

            Public Sub Validate(ByVal oQuoteContract As QuoteContractOriginal)
                'make sure that contact object is valid
                If oQuoteContract.Errors.Count > 0 Then
                    Dim de As DictionaryEntry
                    For Each de In oQuoteContract.Errors
                        Me.AddCriticalMessage(CStr(de.Value))
                    Next
                End If

                If oQuoteContract.QuoteContractReference.Trim.Length = 0 Then
                    AddCriticalMessage("Quote Contract Reference Missing")
                End If

                If oQuoteContract.QuoteContractStatusID = 0 Then
                    AddCriticalMessage("Quote Contract Status Missing")
                End If

                If oQuoteContract.ContractEnd <= oQuoteContract.ContractStart Then
                    AddCriticalMessage("Contract End Date must be greater than Contract Start Date")
                End If

                If Me.ValidatorMessages.CriticalMessages.Count > 0 Then
                    Throw New ValidationException(Me)
                End If

            End Sub

        End Class

    End Namespace

End Namespace
