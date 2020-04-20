Namespace Entity

    Namespace ContractAlternativeSiteJobItems

        Public Class ContractAlternativeSiteJobItemsValidator
            'make sure that contact object is valid
            Inherits BaseValidator

            Public Sub Validate(ByVal oContractAlternativeSiteJobItems As ContractAlternativeSiteJobItems)

                'make sure that contact object is valid
                If oContractAlternativeSiteJobItems.Errors.Count > 0 Then
                    Dim de As DictionaryEntry
                    For Each de In oContractAlternativeSiteJobItems.Errors
                        Me.AddCriticalMessage(CStr(de.Value))
                    Next
                End If

                If oContractAlternativeSiteJobItems.VisitFrequencyID = 0 Then
                    AddCriticalMessage("Visit Frequency Missing")
                End If


                If Me.ValidatorMessages.CriticalMessages.Count > 0 Then
                    Throw New ValidationException(Me)
                End If

            End Sub

        End Class

    End Namespace

End Namespace
