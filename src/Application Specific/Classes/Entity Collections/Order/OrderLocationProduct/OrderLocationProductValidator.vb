Namespace Entity

    Namespace OrderLocationProduct

        Public Class OrderLocationProductValidator
            'make sure that contact object is valid
            Inherits BaseValidator

            Public Sub Validate(ByVal oOrderLocationProduct As OrderLocationProduct)

                'make sure that contact object is valid
                If oOrderLocationProduct.Errors.Count > 0 Then
                    Dim de As DictionaryEntry
                    For Each de In oOrderLocationProduct.Errors
                        Me.AddCriticalMessage(CStr(de.Value))
                    Next
                End If

                If Not oOrderLocationProduct.Quantity > 0 Then
                    Me.AddCriticalMessage("Quantity must be greater than 0")
                Else
                    Dim amountInStock As Integer = DB.Product.Product_Check_Stock_Level(oOrderLocationProduct.ProductID, oOrderLocationProduct.LocationID)
                    If amountInStock < oOrderLocationProduct.Quantity Then
                        If ShowMessage("You have asked for a quantity of " & oOrderLocationProduct.Quantity & ", " & amountInStock & " are available. Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                            Me.AddCriticalMessage("Not enough stock")
                        End If
                    End If
                End If

                If Me.ValidatorMessages.CriticalMessages.Count > 0 Then
                    Throw New ValidationException(Me)
                End If

            End Sub

            Public Sub Validate(ByVal oOrderLocationProduct As OrderLocationProduct, ByVal trans As SqlClient.SqlTransaction)

                'make sure that contact object is valid
                If oOrderLocationProduct.Errors.Count > 0 Then
                    Dim de As DictionaryEntry
                    For Each de In oOrderLocationProduct.Errors
                        Me.AddCriticalMessage(CStr(de.Value))
                    Next
                End If

                If Not oOrderLocationProduct.Quantity > 0 Then
                    Me.AddCriticalMessage("Quantity must be greater than 0")
                Else
                    Dim amountInStock As Integer = DB.Product.Product_Check_Stock_Level(oOrderLocationProduct.ProductID, oOrderLocationProduct.LocationID, trans)
                    If amountInStock < oOrderLocationProduct.Quantity Then
                        If ShowMessage("You have asked for a quantity of " & oOrderLocationProduct.Quantity & ", " & amountInStock & " are available. Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                            Me.AddCriticalMessage("Not enough stock")
                        End If
                    End If
                End If

                If Me.ValidatorMessages.CriticalMessages.Count > 0 Then
                    Throw New ValidationException(Me)
                End If

            End Sub

        End Class

    End Namespace

End Namespace
