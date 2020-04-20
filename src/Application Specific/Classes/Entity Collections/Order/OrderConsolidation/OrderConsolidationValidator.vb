Namespace Entity

    Namespace OrderConsolidations

        Public Class OrderConsolidationValidator
            'make sure that contact object is valid
            Inherits BaseValidator

            Public Sub Validate(ByVal oOrderConsolidation As OrderConsolidation, ByVal ForLocation As Boolean)

                'make sure that contact object is valid
                If oOrderConsolidation.Errors.Count > 0 Then
                    Dim de As DictionaryEntry
                    For Each de In oOrderConsolidation.Errors
                        Me.AddCriticalMessage(CStr(de.Value))
                    Next
                End If

                If ForLocation Then
                    If oOrderConsolidation.LocationID = 0 Then
                        Me.AddCriticalMessage("Location Missing")
                    End If
                Else
                    If oOrderConsolidation.SupplierID = 0 Then
                        Me.AddCriticalMessage("Supplier Missing")
                    End If
                End If
                If oOrderConsolidation.ConsolidationRef.Trim.Length = 0 Then
                    Me.AddCriticalMessage("Reference Missing")
                Else
                    If Not oOrderConsolidation.Exists Then
                        If DB.Order.Order_CheckReference(oOrderConsolidation.ConsolidationRef).Table.Rows.Count > 0 Then
                            Me.AddCriticalMessage("The Order Ref you have chosen has already been allocated to another Quote or Order in the system. Please choose a unique Reference.")
                        End If
                    End If
                End If

                Dim orders As New ArrayList
                If oOrderConsolidation.HasSupplierPO Then
                    For Each row As DataRow In DB.Order.Order_GetAll("").Table.Rows
                        If row.Item("OrderConsolidationID") = oOrderConsolidation.OrderConsolidationID Then
                            If row.Item("ReadyToSendToSage") Then
                                orders.Add(row.Item("OrderReference"))
                            End If
                        End If
                    Next
                End If

                If Not orders.Count = 0 Then
                    Dim msg As String = "The following orders have been marked as ready to send to sage so this consolidation cannot be marked with a supplier PO:" & vbCrLf & vbCrLf

                    For Each Err As String In orders
                        msg += Err & vbCrLf
                    Next

                    Me.AddCriticalMessage(msg)
                End If

                If oOrderConsolidation.ReadyToSendToSage Then
                    If oOrderConsolidation.SupplierInvoiceReference.Trim.Length = 0 Then
                        Me.AddCriticalMessage("Supplier Invoice Reference Missing")
                    End If
                    If oOrderConsolidation.SupplierInvoiceDate = Nothing Then
                        Me.AddCriticalMessage("Supplier Invoice Date Missing")
                    End If
                    If oOrderConsolidation.NominalCode.Trim.Length = 0 Then
                        Me.AddCriticalMessage("Nominal Code Missing")
                    End If
                    If oOrderConsolidation.DepartmentRef.Trim.Length = 0 Then
                        Me.AddCriticalMessage("Department Reference Missing")
                    End If
                    If oOrderConsolidation.ExtraRef.Trim.Length = 0 Then
                        Me.AddCriticalMessage("Extra Reference Missing")
                    End If
                    If oOrderConsolidation.TaxCodeID = 0 Then
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
