Namespace Entity

    Namespace ContractOriginalSiteAssets

        Public Class ContractOriginalSiteAssetValidator
            'make sure that contact object is valid
            Inherits BaseValidator

            Public Sub Validate(ByVal oContractSiteAsset As ContractOriginalSiteAsset)

                'make sure that contact object is valid
                If oContractSiteAsset.Errors.Count > 0 Then
                    Dim de As DictionaryEntry
                    For Each de In oContractSiteAsset.Errors
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
