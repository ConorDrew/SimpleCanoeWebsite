Namespace Entity

    Namespace PickLists

        Public Class PickListValidator : Inherits BaseValidator

            Public Sub Validate(ByVal picklist As Entity.PickLists.PickList)
                If picklist.Errors.Count > 0 Then
                    Dim de As DictionaryEntry
                    For Each de In picklist.Errors
                        If picklist.EnumTypeID = CInt(Entity.Sys.Enums.PickListTypes.VATCodes) Then
                            If de.Key = "PercentageRate" Then
                                Me.AddCriticalMessage("Rate Invalid")
                            Else
                                Me.AddCriticalMessage(CStr(de.Value))
                            End If
                        Else
                            Me.AddCriticalMessage(CStr(de.Value))
                        End If
                    Next
                End If

                If picklist.Name.Trim.Length = 0 Then
                    Me.AddCriticalMessage("Name Missing")
                Else
                    If picklist.EnumTypeID = Entity.Sys.Enums.PickListTypes.PartBinReferences Then
                        If DB.Picklists.Check_Unique_Name(picklist.Name, picklist.ManagerID, picklist.EnumTypeID) = False Then
                            Me.AddCriticalMessage("Name already exists")
                        End If
                    End If
                End If
                If picklist.EnumTypeID = 0 Then
                    Me.AddCriticalMessage("Type Missing")
                End If
                If picklist.EnumTypeID = Entity.Sys.Enums.PickListTypes.VATCodes Then
                    If picklist.PercentageRate < 0 Or picklist.PercentageRate > 100 Then
                        Me.AddCriticalMessage("Rate must be between 0 and 100")
                    End If
                End If

                If Me.ValidatorMessages.CriticalMessages.Count > 0 Then
                    Throw New ValidationException(Me)
                End If
            End Sub

        End Class

    End Namespace

End Namespace