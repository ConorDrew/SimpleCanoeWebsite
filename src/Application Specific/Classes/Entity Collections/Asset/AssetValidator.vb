Namespace Entity

    Namespace Assets

        Public Class AssetValidator
            'make sure that contact object is valid
            Inherits BaseValidator

            Public Sub Validate(ByVal oAsset As Asset)

                'make sure that contact object is valid
                If oAsset.Errors.Count > 0 Then
                    Dim de As DictionaryEntry
                    For Each de In oAsset.Errors
                        Me.AddCriticalMessage(CStr(de.Value))
                    Next
                End If

                If oAsset.ProductID = 0 Then
                    Me.AddCriticalMessage("Product Missing")
                End If
                If oAsset.SerialNum.Trim.Length = 0 AndAlso oAsset.Active Then
                    Me.AddCriticalMessage("Serial Missing")
                End If
                If oAsset.Location.Trim.Length = 0 Then
                    Me.AddCriticalMessage("Location Missing")
                End If

                If Me.ValidatorMessages.CriticalMessages.Count > 0 Then
                    Throw New ValidationException(Me)
                End If

            End Sub

        End Class

    End Namespace

End Namespace