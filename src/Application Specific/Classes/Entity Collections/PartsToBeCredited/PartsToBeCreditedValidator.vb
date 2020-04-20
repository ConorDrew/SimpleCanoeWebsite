Namespace Entity

Namespace PartsToBeCrediteds

Public Class PartsToBeCreditedValidator
    'make sure that contact object is valid
    Inherits BaseValidator

    Public Sub Validate(ByVal oPartsToBeCredited As PartsToBeCredited)

        'make sure that contact object is valid
        If oPartsToBeCredited.Errors.Count > 0 Then
            Dim de As DictionaryEntry
            For Each de In oPartsToBeCredited.Errors
                Me.AddCriticalMessage(CStr(de.Value))
            Next
        End If

                If oPartsToBeCredited.PartID = 0 Then
                    Me.AddCriticalMessage("Part Missing")
                Else
                    If oPartsToBeCredited.OrderID > 0 Then
                        Dim dvItems As DataView = DB.Order.OrderPart_GetForOrder(oPartsToBeCredited.OrderID)
                        Dim r() As DataRow = dvItems.Table.Select("PartID=" & oPartsToBeCredited.PartID)
                        If r.Length > 0 Then
                            If oPartsToBeCredited.Qty > r(0).Item("Qty") Then
                                Me.AddCriticalMessage("Qty cannot be higher than quantity ordered.")
                            End If
                        End If
                    End If
                End If
                If oPartsToBeCredited.SupplierID = 0 Then
                    Me.AddCriticalMessage("Supplier Missing")
                End If

                If oPartsToBeCredited.OrderReference.Length = 0 Then
                    Me.AddCriticalMessage("Select an order or enter a reference ")
                End If


                If Me.ValidatorMessages.CriticalMessages.Count > 0 Then
                    Throw New ValidationException(Me)
                End If

    End Sub

End Class

End Namespace

End Namespace
