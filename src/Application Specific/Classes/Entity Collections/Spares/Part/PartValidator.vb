Namespace Entity

Namespace Parts

Public Class PartValidator
    'make sure that contact object is valid
    Inherits BaseValidator

    Public Sub Validate(ByVal oPart As Part)

        'make sure that contact object is valid
        If oPart.Errors.Count > 0 Then
            Dim de As DictionaryEntry
                    For Each de In oPart.Errors

                        If de.Key = "RecommendedQuantity" Then
                            Me.AddCriticalMessage("Maximum Quantity Invalid")
                        ElseIf de.Key = "MinimumQuantity" Then
                            Me.AddCriticalMessage("Minimum Quantity Invalid")
                        Else
                            Me.AddCriticalMessage(CStr(de.Value))
                        End If

                    Next
        End If
                If oPart.Name.Trim.Length = 0 Then
                    Me.AddCriticalMessage("*Name Missing")
                End If
                If oPart.Number.Trim.Length = 0 Then
                    Me.AddCriticalMessage("*Number Missing")
                Else
                    If DB.Part.Check_Unique_Number(oPart.Number, oPart.PartID) = False Then
                        Me.AddCriticalMessage("*Number already exists")
                    End If
                End If
                If Not oPart.UnitTypeID > 0 Then
                    Me.AddCriticalMessage("*Unit Type Missing")
                End If
                If Not oPart.CategoryID > 0 Then
                    Me.AddCriticalMessage("*Category Missing")
                End If
                If oPart.RecommendedQuantity < oPart.MinimumQuantity Then
                    Me.AddCriticalMessage("*Maximum Quantity cannot be less than the Minimum Quantity")
                End If
                If Not oPart.BinID = 0 Then
                    If DB.Part.Check_Unique_Bin(oPart.BinID, oPart.PartID, "BinID") = False Then
                        Me.AddCriticalMessage("*BIN reference already used")
                    End If
                End If
                If Not oPart.BinIDAlternative = 0 Then
                    If DB.Part.Check_Unique_Bin(oPart.BinIDAlternative, oPart.PartID, "BinIDAlternative") = False Then
                        Me.AddCriticalMessage("*Alternative BIN reference already used")
                    End If
                End If


                If Me.ValidatorMessages.CriticalMessages.Count > 0 Then
                    Throw New ValidationException(Me)
                End If
            End Sub

End Class

End Namespace

End Namespace
