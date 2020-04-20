Namespace Entity

    Namespace OrderLocationPart

        Public Class OrderLocationPartValidator
            'make sure that contact object is valid
            Inherits BaseValidator

            Public Sub Validate(ByVal oOrderLocationPart As OrderLocationPart)

                'make sure that contact object is valid
                If oOrderLocationPart.Errors.Count > 0 Then
                    Dim de As DictionaryEntry
                    For Each de In oOrderLocationPart.Errors
                        Me.AddCriticalMessage(CStr(de.Value))
                    Next
                End If

                If Not oOrderLocationPart.Quantity > 0 Then
                    Me.AddCriticalMessage("Quantity must be greater than 0")
                Else
                    Dim amountInStock As Integer = DB.Part.Part_Check_Stock_Level(oOrderLocationPart.PartID, oOrderLocationPart.LocationID)
                    If amountInStock < oOrderLocationPart.Quantity Then
                        If ShowMessage("You have asked for a quantity of " & oOrderLocationPart.Quantity & ". Only " & amountInStock & " are available. Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                            Me.AddCriticalMessage("Not enough stock")
                        End If
                    End If
                End If

                If Me.ValidatorMessages.CriticalMessages.Count > 0 Then
                    Throw New ValidationException(Me)
                End If

            End Sub

            Public Sub Validate(ByVal oOrderLocationPart As OrderLocationPart, ByVal trans As SqlClient.SqlTransaction)

                'make sure that contact object is valid
                If oOrderLocationPart.Errors.Count > 0 Then
                    Dim de As DictionaryEntry
                    For Each de In oOrderLocationPart.Errors
                        Me.AddCriticalMessage(CStr(de.Value))
                    Next
                End If

                If Not oOrderLocationPart.Quantity > 0 Then
                    Me.AddCriticalMessage("Quantity must be greater than 0")
                Else
                    Dim amountInStock As Integer = DB.Part.Part_Check_Stock_Level(oOrderLocationPart.PartID, oOrderLocationPart.LocationID, trans)
                    If amountInStock < oOrderLocationPart.Quantity Then
                        If ShowMessage("You have asked for a quantity of " & oOrderLocationPart.Quantity & ". Only " & amountInStock & " are available. Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
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
