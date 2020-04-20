Namespace Entity

    Namespace ContractAlternativeSites

        Public Class ContractAlternativeSiteValidator
            'make sure that contact object is valid
            Inherits BaseValidator

            Public Sub Validate(ByVal oContractSite As ContractAlternativeSite, ByVal contract As Entity.ContractsAlternative.ContractAlternative)

                'make sure that contact object is valid
                If oContractSite.Errors.Count > 0 Then
                    Dim de As DictionaryEntry
                    For Each de In oContractSite.Errors
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
