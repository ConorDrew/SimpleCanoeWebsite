Namespace Entity

Namespace Products

Public Class ProductValidator
    'make sure that contact object is valid
    Inherits BaseValidator

    Public Sub Validate(ByVal oProduct As Product)

        'make sure that contact object is valid
        If oProduct.Errors.Count > 0 Then
            Dim de As DictionaryEntry
            For Each de In oProduct.Errors
                        If de.Key = "RecommendedQuantity" Then
                            Me.AddCriticalMessage("Maximum Quantity Invalid")
                        ElseIf de.Key = "MinimumQuantity" Then
                            Me.AddCriticalMessage("Minimum Quantity Invalid")
                        Else
                            Me.AddCriticalMessage(CStr(de.Value))
                        End If
            Next
        End If

                If oProduct.Number.Trim.Length = 0 Then
                    Me.AddCriticalMessage("*GC Number Missing")
                Else
                    If DB.Product.Check_Unique_Number(oProduct.Number, oProduct.ProductID) = False Then
                        Me.AddCriticalMessage("GC Number already exists")
                    End If
                End If
                If oProduct.TypeID = 0 Then
                    Me.AddCriticalMessage("*Type Missing")
                End If
                If oProduct.MakeID = 0 Then
                    Me.AddCriticalMessage("*Make Missing")
                End If
                If oProduct.ModelID = 0 Then
                    Me.AddCriticalMessage("*Model Missing")
                End If
           
                If oProduct.RecommendedQuantity < oProduct.MinimumQuantity Then
                    Me.AddCriticalMessage("*Maximum Quantity cannot be less than the Minimum Quantity")
                End If

                If Me.ValidatorMessages.CriticalMessages.Count > 0 Then
                    Throw New ValidationException(Me)
                End If

    End Sub

End Class

End Namespace

End Namespace
