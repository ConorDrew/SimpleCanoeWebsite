Namespace Entity

    Namespace ContractOption3SiteAsset

        Public Class ContractOption3SiteAssetValidator
            'make sure that contact object is valid
            Inherits BaseValidator

            Public Sub Validate(ByVal oContractOption3SiteAsset As ContractOption3SiteAsset)

                'make sure that contact object is valid
                If oContractOption3SiteAsset.Errors.Count > 0 Then
                    Dim de As DictionaryEntry
                    For Each de In oContractOption3SiteAsset.Errors
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
