Namespace Entity

    Namespace ContractOriginalSites

        Public Class ContractOriginalSiteValidator
            'make sure that contact object is valid
            Inherits BaseValidator

            Public Sub Validate(ByVal oContractSite As ContractOriginalSite, ByVal contract As Entity.ContractsOriginal.ContractOriginal)

                'make sure that contact object is valid
                If oContractSite.Errors.Count > 0 Then
                    Dim de As DictionaryEntry
                    For Each de In oContractSite.Errors
                        Me.AddCriticalMessage(CStr(de.Value))
                    Next
                End If

                If oContractSite.VisitFrequencyID = 0 Then
                    AddCriticalMessage("Visit Frequency Missing")
                End If

                If oContractSite.VisitDuration < 1 Then
                    AddCriticalMessage("Visit Duration must be great than 0")
                End If

                If oContractSite.FirstVisitDate.Date < contract.ContractStartDate.Date _
                    Or oContractSite.FirstVisitDate.Date >= contract.ContractEndDate.Date Then
                    AddCriticalMessage("First Visit Date must be between Contract Start and End Date")
                End If

                If Me.ValidatorMessages.CriticalMessages.Count > 0 Then
                    Throw New ValidationException(Me)
                End If

            End Sub

        End Class

    End Namespace

End Namespace
