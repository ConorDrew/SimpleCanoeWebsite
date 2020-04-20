Namespace Entity

    Namespace ContractOriginalPPMVisits

        Public Class ContractOriginalPPMVisitValidator
            'make sure that contact object is valid
            Inherits BaseValidator

            Public Sub Validate(ByVal oContractPPMVisit As ContractOriginalPPMVisit)

                'make sure that contact object is valid
                If oContractPPMVisit.Errors.Count > 0 Then
                    Dim de As DictionaryEntry
                    For Each de In oContractPPMVisit.Errors
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
