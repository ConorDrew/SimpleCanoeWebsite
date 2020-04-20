Namespace Entity

Namespace Orders

Public Class OrderValidator
    'make sure that contact object is valid
    Inherits BaseValidator

    Public Sub Validate(ByVal oOrder As Order)

        'make sure that contact object is valid
        If oOrder.Errors.Count > 0 Then
            Dim de As DictionaryEntry
            For Each de In oOrder.Errors
                Me.AddCriticalMessage(CStr(de.Value))
            Next
        End If

                If Not oOrder.OrderTypeID > 0 Then
                    Me.AddCriticalMessage("Order Type Missing")
                End If

                If Not oOrder.OrderReference.Trim.Length > 0 Then
                    Me.AddCriticalMessage("Order Reference Missing")
                End If

                If oOrder.OrderID = 0 Then
                    If DB.Order.Order_CheckReference(oOrder.OrderReference).Table.Rows.Count > 0 Then
                        Me.AddCriticalMessage("The Order Ref you have chosen has already been allocated to another Quote or Order in the system.  Please choose a unique Reference.")

                    End If
                End If

                If oOrder.OrderStatusID > Entity.Sys.Enums.OrderStatus.AwaitingConfirmation Then
                    If oOrder.DepartmentRef.Trim.Length = 0 Then
                        Me.AddCriticalMessage("Department Reference Missing")
                    End If
                End If

                If oOrder.ReadyToSendToSage Then
                    If oOrder.SupplierInvoiceReference.Trim.Length = 0 Then
                        Me.AddCriticalMessage("Supplier Invoice Reference Missing")
                    End If
                    If oOrder.SupplierInvoiceDate = Nothing Then
                        Me.AddCriticalMessage("Supplier Invoice Date Missing")
                    End If
                    If oOrder.NominalCode.Trim.Length = 0 Then
                        Me.AddCriticalMessage("Nominal Code Missing")
                    End If
                    If oOrder.DepartmentRef.Trim.Length = 0 Then
                        Me.AddCriticalMessage("Department Reference Missing")
                    End If
                    If oOrder.ExtraRef.Trim.Length = 0 Then
                        Me.AddCriticalMessage("Extra Reference Missing")
                    End If
                    If oOrder.TaxCodeID = 0 Then
                        Me.AddCriticalMessage("Tax Code Missing")
                    End If
                End If

                If Me.ValidatorMessages.CriticalMessages.Count > 0 Then
                    Throw New ValidationException(Me)
                End If


    End Sub

End Class

End Namespace

End Namespace
