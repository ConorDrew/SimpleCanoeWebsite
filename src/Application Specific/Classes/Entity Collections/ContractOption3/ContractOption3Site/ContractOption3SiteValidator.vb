Namespace Entity

    Namespace ContractOption3Sites

        Public Class ContractOption3SiteValidator
            'make sure that contact object is valid
            Inherits BaseValidator

            Public Sub Validate(ByVal oContractOption3Site As ContractOption3Site, _
            ByVal assets As DataView)

                'make sure that contact object is valid
                If oContractOption3Site.Errors.Count > 0 Then
                    Dim de As DictionaryEntry
                    For Each de In oContractOption3Site.Errors
                        Me.AddCriticalMessage(CStr(de.Value))
                    Next
                End If

                If oContractOption3Site.ContractSiteReference.Trim.Length = 0 Then
                    Me.AddCriticalMessage("* Property Reference Required")
                End If

                If Not (oContractOption3Site.StartDate < oContractOption3Site.EndDate) Then
                    Me.AddCriticalMessage("* End Date must be greater than Start Date")
                End If

                If oContractOption3Site.FirstVisitDate() < oContractOption3Site.StartDate Or _
                     oContractOption3Site.FirstVisitDate > oContractOption3Site.EndDate Then
                    Me.AddCriticalMessage("* First Visit Date must be between Start Date and End Date")
                End If

                If oContractOption3Site.InvoiceFrequencyID = 0 Then
                    Me.AddCriticalMessage("* Invoice Frequency Required")
                End If

                If oContractOption3Site.VisitFrequencyID = 0 Then
                    Me.AddCriticalMessage("* Visit Frequency Required")
                End If

                If assets.Table.Columns.Count < 16 Then
                    Me.AddCriticalMessage("* Please load and fill in the assets schedule.")
                End If

                If oContractOption3Site.InvoiceAddressID = 0 Then
                    AddCriticalMessage("Invoice Address Missing")
                End If

                If Me.ValidatorMessages.CriticalMessages.Count > 0 Then
                    Throw New ValidationException(Me)
                End If


            End Sub

        End Class

    End Namespace

End Namespace
