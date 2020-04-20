Namespace Entity

    Namespace ContractOption3SitePPMVisits

        Public Class ContractOption3SitePPMVisitValidator
            'make sure that contact object is valid
            Inherits BaseValidator

            Public Sub Validate(ByVal oContractOption3SitePPMVisit As ContractOption3SitePPMVisit)

                'make sure that contact object is valid
                If oContractOption3SitePPMVisit.Errors.Count > 0 Then
                    Dim de As DictionaryEntry
                    For Each de In oContractOption3SitePPMVisit.Errors
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
