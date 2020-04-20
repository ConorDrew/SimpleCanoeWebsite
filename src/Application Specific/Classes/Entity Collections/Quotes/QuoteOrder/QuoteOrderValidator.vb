Namespace Entity

Namespace QuoteOrders

Public Class QuoteOrderValidator
    'make sure that contact object is valid
    Inherits BaseValidator

    Public Sub Validate(ByVal oQuoteOrder As QuoteOrder)

        'make sure that contact object is valid
        If oQuoteOrder.Errors.Count > 0 Then
            Dim de As DictionaryEntry
            For Each de In oQuoteOrder.Errors
                Me.AddCriticalMessage(CStr(de.Value))
            Next
        End If

                If oQuoteOrder.CustomerRef.Trim.Length = 0 Then
                    Me.AddCriticalMessage("*Customer Ref Missing")
                Else
                    If oQuoteOrder.QuoteOrderID = 0 Then
                        If DB.Order.Order_CheckReference(oQuoteOrder.CustomerRef).Table.Rows.Count > 0 Then
                            Me.AddCriticalMessage("*The Customer Ref you have chosen has already been allocated to another Quote or Order in the system.  Please choose a unique Reference.")
                        End If
                    End If
                End If

                If oQuoteOrder.CustomerID = 0 Then
                    Me.AddCriticalMessage("*Customer Missing")
                End If

                If oQuoteOrder.PropertyID = 0 And oQuoteOrder.WarehouseID = 0 Then
                    Me.AddCriticalMessage("*Please select a Property or Warehouse")
                End If

                If oQuoteOrder.AllocatedToUser = 0 Then
                    Me.AddCriticalMessage("*Co-ordinator Missing")
                End If

                If Me.ValidatorMessages.CriticalMessages.Count > 0 Then
                    Throw New ValidationException(Me)
                End If

    End Sub

End Class

End Namespace

End Namespace
