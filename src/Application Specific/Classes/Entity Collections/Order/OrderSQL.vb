Imports System.Data.SqlClient

Namespace Entity

    Namespace Orders

        Public Class OrderSQL
            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

#Region "Functions"

            Public Function Order_CheckReference(ByVal OrderRef As String) As DataView
                _database.ClearParameter()
                _database.AddParameter("@OrderReference", OrderRef, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("Order_CheckReference")
                dt.TableName = Entity.Sys.Enums.TableNames.tblOrder.ToString
                Return New DataView(dt)
            End Function

            Public Function Order_ItemsGetAll(ByVal OrderID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@OrderID", OrderID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("Order_ItemsGetAll")
                dt.TableName = Entity.Sys.Enums.TableNames.tblOrder.ToString
                Return New DataView(dt)
            End Function

            Public Function OrderSupplierItemsForPrint_Get(ByVal OrderID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@OrderID", OrderID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("OrderSupplierItemsForPrint_Get")
                dt.TableName = Entity.Sys.Enums.TableNames.tblOrder.ToString
                Return New DataView(dt)
            End Function

            Public Function OrderItemsForPrint_Get(ByVal OrderID As Integer) As DataTable
                _database.ClearParameter()
                _database.AddParameter("@OrderID", OrderID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("OrderItemsForPrint_Get")
                dt.TableName = Entity.Sys.Enums.TableNames.tblOrder.ToString
                Return (dt)
            End Function

            Public Sub Delete(ByVal OrderID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@OrderID", OrderID, True)
                _database.ExecuteSP_NO_Return("Order_Delete")
            End Sub

            Public Sub Delete(ByVal OrderID As Integer, ByVal trans As SqlClient.SqlTransaction)

                Dim Command As SqlClient.SqlCommand = New SqlClient.SqlCommand

                Command.CommandText = "Order_Delete"
                Command.CommandType = CommandType.StoredProcedure
                Command.Transaction = trans
                Command.Connection = trans.Connection

                Command.Parameters.Add(New System.Data.SqlClient.SqlParameter("@OrderID", OrderID))
                Command.ExecuteNonQuery()

            End Sub

            Public Sub PermanentDelete(ByVal OrderID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@OrderID", OrderID, True)
                _database.ExecuteSP_NO_Return("Order_PermanentDelete")
            End Sub

            Public Function [Order_Get](ByVal OrderID As Integer) As Order
                _database.ClearParameter()
                _database.AddParameter("@OrderID", OrderID)
                _database.AddParameter("@OrderInvoiceTypeID", CInt(Entity.Sys.Enums.InvoiceType.Order))
                _database.AddParameter("@VisitInvoiceTypeID", CInt(Entity.Sys.Enums.InvoiceType.Visit))

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("Order_Get")

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oOrder As New Order
                        With oOrder
                            .IgnoreExceptionsOnSetMethods = True
                            .SetOrderID = dt.Rows(0).Item("OrderID")
                            .DatePlaced = CDate(dt.Rows(0).Item("DatePlaced"))
                            .SetOrderTypeID = dt.Rows(0).Item("OrderTypeID")
                            .SetOrderReference = dt.Rows(0).Item("OrderReference")
                            .SetUserID = dt.Rows(0).Item("UserID")
                            .SetOrderStatusID = dt.Rows(0).Item("OrderStatusID")
                            .SetReasonForReject = dt.Rows(0).Item("ReasonForReject")

                            If Not IsDBNull(dt.Rows(0).Item("DeliveryDeadline")) Then
                                .DeliveryDeadline = dt.Rows(0).Item("DeliveryDeadline")
                            Else
                                .DeliveryDeadline = Nothing
                            End If

                            .SetSentToSage = Entity.Sys.Helper.MakeBooleanValid(dt.Rows(0).Item("SentToSage"))
                            .SetSupplierInvoiceAmount = Entity.Sys.Helper.MakeDoubleValid(dt.Rows(0).Item("SupplierInvoiceAmount"))
                            .SetSupplierInvoiceReference = Entity.Sys.Helper.MakeStringValid(dt.Rows(0).Item("SupplierInvoiceReference"))
                            If Not IsDBNull(dt.Rows(0).Item("SupplierInvoiceDate")) Then
                                .SupplierInvoiceDate = Entity.Sys.Helper.MakeDateTimeValid(dt.Rows(0).Item("SupplierInvoiceDate"))
                            Else
                                .SupplierInvoiceDate = Nothing
                            End If

                            .SetSpecialInstructions = Entity.Sys.Helper.MakeStringValid(dt.Rows(0).Item("SpecialInstructions"))
                            .SetContactID = Entity.Sys.Helper.MakeIntegerValid(dt.Rows(0).Item("ContactID"))
                            .SetInvoiceAddressID = Entity.Sys.Helper.MakeIntegerValid(dt.Rows(0).Item("InvoiceAddressID"))
                            .SetAllocatedToUser = Entity.Sys.Helper.MakeIntegerValid(dt.Rows(0).Item("AllocatedToUser"))

                            .SetDeleted = dt.Rows(0).Item("Deleted")

                            .SetInvoiced = dt.Rows(0).Item("Invoiced")
                            .SetExportedToSage = dt.Rows(0).Item("ExportedToSage")

                            .SetNominalCode = Entity.Sys.Helper.MakeStringValid(dt.Rows(0).Item("NominalCode"))
                            .SetDepartmentRef = Entity.Sys.Helper.MakeStringValid(dt.Rows(0).Item("DepartmentRef"))
                            .SetExtraRef = Entity.Sys.Helper.MakeStringValid(dt.Rows(0).Item("ExtraRef"))
                            .SetTaxCodeID = Entity.Sys.Helper.MakeIntegerValid(dt.Rows(0).Item("TaxCodeID"))
                            .SetReadyToSendToSage = Entity.Sys.Helper.MakeBooleanValid(dt.Rows(0).Item("ReadyToSendToSage"))
                            .SetOrderConsolidationID = Entity.Sys.Helper.MakeIntegerValid(dt.Rows(0).Item("OrderConsolidationID"))
                            .SetVATAmount = Entity.Sys.Helper.MakeDoubleValid(dt.Rows(0).Item("VATAmount"))
                            .SetDoNotConsolidated = Entity.Sys.Helper.MakeBooleanValid(dt.Rows(0).Item("DoNotConsolidated"))
                        End With
                        oOrder.Exists = True
                        Return oOrder
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function [Order_Get](ByVal OrderID As Integer, ByVal trans As SqlClient.SqlTransaction) As Order

                Dim Command As SqlClient.SqlCommand = New SqlClient.SqlCommand

                Command.CommandText = "Order_Get"
                Command.CommandType = CommandType.StoredProcedure
                Command.Transaction = trans
                Command.Connection = trans.Connection

                Command.Parameters.AddWithValue("@OrderID", OrderID)
                Command.Parameters.AddWithValue("@OrderInvoiceTypeID", CInt(Entity.Sys.Enums.InvoiceType.Order))
                Command.Parameters.AddWithValue("@VisitInvoiceTypeID", CInt(Entity.Sys.Enums.InvoiceType.Visit))

                Dim Adapter As New SqlClient.SqlDataAdapter(Command)
                Dim returnDS As New DataSet
                Adapter.Fill(returnDS)

                Dim dt As DataTable = returnDS.Tables(0)

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oOrder As New Order
                        With oOrder
                            .IgnoreExceptionsOnSetMethods = True
                            .SetOrderID = dt.Rows(0).Item("OrderID")
                            .DatePlaced = CDate(dt.Rows(0).Item("DatePlaced"))
                            .SetOrderTypeID = dt.Rows(0).Item("OrderTypeID")
                            .SetOrderReference = dt.Rows(0).Item("OrderReference")
                            .SetUserID = dt.Rows(0).Item("UserID")
                            .SetOrderStatusID = dt.Rows(0).Item("OrderStatusID")
                            .SetReasonForReject = dt.Rows(0).Item("ReasonForReject")

                            If Not IsDBNull(dt.Rows(0).Item("DeliveryDeadline")) Then
                                .DeliveryDeadline = dt.Rows(0).Item("DeliveryDeadline")
                            Else
                                .DeliveryDeadline = Nothing
                            End If

                            .SetSentToSage = Entity.Sys.Helper.MakeBooleanValid(dt.Rows(0).Item("SentToSage"))
                            .SetSupplierInvoiceAmount = Entity.Sys.Helper.MakeDoubleValid(dt.Rows(0).Item("SupplierInvoiceAmount"))
                            .SetSupplierInvoiceReference = Entity.Sys.Helper.MakeStringValid(dt.Rows(0).Item("SupplierInvoiceReference"))
                            If Not IsDBNull(dt.Rows(0).Item("SupplierInvoiceDate")) Then
                                .SupplierInvoiceDate = Entity.Sys.Helper.MakeDateTimeValid(dt.Rows(0).Item("SupplierInvoiceDate"))
                            Else
                                .SupplierInvoiceDate = Nothing
                            End If

                            .SetSpecialInstructions = Entity.Sys.Helper.MakeStringValid(dt.Rows(0).Item("SpecialInstructions"))
                            .SetContactID = Entity.Sys.Helper.MakeIntegerValid(dt.Rows(0).Item("ContactID"))
                            .SetInvoiceAddressID = Entity.Sys.Helper.MakeIntegerValid(dt.Rows(0).Item("InvoiceAddressID"))
                            .SetAllocatedToUser = Entity.Sys.Helper.MakeIntegerValid(dt.Rows(0).Item("AllocatedToUser"))

                            .SetDeleted = dt.Rows(0).Item("Deleted")

                            .SetInvoiced = dt.Rows(0).Item("Invoiced")
                            .SetExportedToSage = dt.Rows(0).Item("ExportedToSage")

                            .SetNominalCode = Entity.Sys.Helper.MakeStringValid(dt.Rows(0).Item("NominalCode"))
                            .SetDepartmentRef = Entity.Sys.Helper.MakeStringValid(dt.Rows(0).Item("DepartmentRef"))
                            .SetExtraRef = Entity.Sys.Helper.MakeStringValid(dt.Rows(0).Item("ExtraRef"))
                            .SetTaxCodeID = Entity.Sys.Helper.MakeIntegerValid(dt.Rows(0).Item("TaxCodeID"))
                            .SetReadyToSendToSage = Entity.Sys.Helper.MakeBooleanValid(dt.Rows(0).Item("ReadyToSendToSage"))
                            .SetOrderConsolidationID = Entity.Sys.Helper.MakeIntegerValid(dt.Rows(0).Item("OrderConsolidationID"))
                            .SetVATAmount = Entity.Sys.Helper.MakeDoubleValid(dt.Rows(0).Item("VATAmount"))
                            .SetDoNotConsolidated = Entity.Sys.Helper.MakeBooleanValid(dt.Rows(0).Item("DoNotConsolidated"))
                        End With
                        oOrder.Exists = True
                        Return oOrder
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function Order_Get_ByRef(ByVal OrderReference As String) As DataView
                _database.ClearParameter()
                _database.AddParameter("@OrderReference", OrderReference, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("Order_Get_ByRef")
                dt.TableName = Entity.Sys.Enums.TableNames.tblOrder.ToString
                Return New DataView(dt)
            End Function

            Public Function Order_Get_ByRef(ByVal OrderReference As String, ByVal trans As SqlClient.SqlTransaction) As DataView

                Dim Command As SqlClient.SqlCommand = New SqlClient.SqlCommand

                Command.CommandText = "Order_Get_ByRef"
                Command.CommandType = CommandType.StoredProcedure
                Command.Transaction = trans
                Command.Connection = trans.Connection

                Command.Parameters.AddWithValue("@OrderReference", OrderReference)

                Dim Adapter As New SqlClient.SqlDataAdapter(Command)
                Dim returnDS As New DataSet
                Adapter.Fill(returnDS)

                Dim dt As DataTable = returnDS.Tables(0)
                dt.TableName = Entity.Sys.Enums.TableNames.tblOrder.ToString
                Return New DataView(dt)
            End Function

            Public Function OrderPart_GetForOrder(ByVal OrderID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@OrderID", OrderID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("OrderPart_GetForOrder")
                dt.TableName = Entity.Sys.Enums.TableNames.tblPartSupplier.ToString
                Return New DataView(dt)
            End Function

            Public Function OrderPart_GetForOrder(ByVal OrderID As Integer, ByVal trans As SqlClient.SqlTransaction) As DataView

                Dim Command As SqlClient.SqlCommand = New SqlClient.SqlCommand

                Command.CommandText = "OrderPart_GetForOrder"
                Command.CommandType = CommandType.StoredProcedure
                Command.Transaction = trans
                Command.Connection = trans.Connection

                Command.Parameters.AddWithValue("@OrderID", OrderID)

                Dim Adapter As New SqlClient.SqlDataAdapter(Command)
                Dim returnDS As New DataSet
                Adapter.Fill(returnDS)

                Dim dt As DataTable = returnDS.Tables(0)

                dt.TableName = Entity.Sys.Enums.TableNames.tblPartSupplier.ToString
                Return New DataView(dt)
            End Function

            Public Function OrderProduct_GetForOrder(ByVal OrderID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@OrderID", OrderID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("OrderProduct_GetForOrder")
                dt.TableName = Entity.Sys.Enums.TableNames.tblProductSupplier.ToString
                Return New DataView(dt)
            End Function

            Public Function [Order_GetAll](ByVal SearchCriteria As String) As DataView
                _database.ClearParameter()
                _database.AddParameter("@OrderInvoiceTypeID", CInt(Entity.Sys.Enums.InvoiceType.Order))
                _database.AddParameter("@VisitInvoiceTypeID", CInt(Entity.Sys.Enums.InvoiceType.Visit))
                _database.AddParameter("@SearchCriteria", SearchCriteria, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("Order_GetAll")
                dt.TableName = Entity.Sys.Enums.TableNames.tblOrder.ToString
                Return New DataView(dt)
            End Function

            Public Function [Order_GetAll_NEW](ByVal SearchCriteria As String, ByVal OrderSiteID As Integer, ByVal OrderVanID As Integer, ByVal OrderWarehouseID As Integer, ByVal OrderJobID As Integer, ByVal OrderTypeID As Integer, ByVal OrderReference As String, ByVal OrderConsolidationRef As String, ByVal OrderStatus As Integer, ByVal PartsNotReceived As Integer, ByVal OrderSupplierExported As Integer, ByVal OrderSupplierID As Integer, ByVal OrderDatePlacedFrom As DateTime?, ByVal OrderDatePlacedTo As DateTime?, ByVal OrderDeliveryDeadlineFrom As DateTime?, ByVal OrderDeliveryDeadlineTo As DateTime?, ByVal OrderDepartment As String) As DataView
                _database.ClearParameter()
                _database.AddParameter("@OrderInvoiceTypeID", CInt(Entity.Sys.Enums.InvoiceType.Order))
                _database.AddParameter("@VisitInvoiceTypeID", CInt(Entity.Sys.Enums.InvoiceType.Visit))
                _database.AddParameter("@SearchCriteria", SearchCriteria, True)
                _database.AddParameter("@OrderSiteID", OrderSiteID, True)
                _database.AddParameter("@OrderVanID", OrderVanID, True)
                _database.AddParameter("@OrderWarehouseID", OrderWarehouseID, True)
                _database.AddParameter("@OrderJobID", OrderJobID, True)
                _database.AddParameter("@PartsNotReceived", PartsNotReceived, True)
                _database.AddParameter("@OrderTypeID", OrderTypeID, True)
                '_database.AddParameter("@OrderDisplayStatusID", OrderDisplayStatusID, True)
                _database.AddParameter("@OrderSupplierID", OrderSupplierID, True)
                _database.AddParameter("@OrderSupplierExported", OrderSupplierExported, True)
                _database.AddParameter("@OrderReference", OrderReference, True)
                _database.AddParameter("@OrderConsolidationRef", OrderConsolidationRef, True)
                _database.AddParameter("@OrderDatePlacedFrom", OrderDatePlacedFrom, True)
                _database.AddParameter("@OrderDatePlacedTo", OrderDatePlacedTo, True)
                _database.AddParameter("@OrderDeliveryDeadlineFrom", OrderDeliveryDeadlineFrom, True)
                _database.AddParameter("@OrderDeliveryDeadlineTo", OrderDeliveryDeadlineTo, True)
                _database.AddParameter("@OrderStatus", OrderStatus, True)
                _database.AddParameter("@OrderDepartment", OrderDepartment, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("Order_GetAll_NEW")
                'Dim dt As DataTable = _database.ExecuteSP_DataTable("Order_GetAll")
                dt.TableName = Entity.Sys.Enums.TableNames.tblOrder.ToString
                Return New DataView(dt)
            End Function

            Public Function Orders_GetForJob(ByVal jobID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@jobID", jobID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("Orders_GetForJob")
                dt.TableName = Entity.Sys.Enums.TableNames.tblOrder.ToString
                Return New DataView(dt)
            End Function

            Public Function Orders_GetJob(ByVal orderID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@OrderID", orderID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("Order_GetJob_OrderID")
                dt.TableName = Entity.Sys.Enums.TableNames.tblOrder.ToString
                Return New DataView(dt)
            End Function

            Public Function Orders_GetForItem(ByVal Type As String, ByVal ID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@Type", Type, True)
                _database.AddParameter("@ID", ID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("Orders_GetForItem")
                dt.TableName = Entity.Sys.Enums.TableNames.tblOrder.ToString
                Return New DataView(dt)
            End Function

            Public Function Orders_GetForEngineerVisit(ByVal EngineerVisitID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@EngineerVisitID", EngineerVisitID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("Orders_GetForEngineerVisit")
                dt.TableName = Entity.Sys.Enums.TableNames.tblOrder.ToString
                Return New DataView(dt)
            End Function

            Public Function VanParts_GetForOrder(ByVal OrderID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@OrderID", OrderID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("VanParts_GetForOrder")
                dt.TableName = Entity.Sys.Enums.TableNames.tblPart.ToString
                Return New DataView(dt)
            End Function

            Public Function VanProducts_GetForOrder(ByVal OrderID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@OrderID", OrderID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("VanProducts_GetForOrder")
                dt.TableName = Entity.Sys.Enums.TableNames.tblProduct.ToString
                Return New DataView(dt)
            End Function

            Public Function WarehouseParts_GetForOrder(ByVal OrderID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@OrderID", OrderID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("WarehouseParts_GetForOrder")
                dt.TableName = Entity.Sys.Enums.TableNames.tblPart.ToString
                Return New DataView(dt)
            End Function

            Public Function WarehouseProducts_GetForOrder(ByVal OrderID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@OrderID", OrderID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("WarehouseProducts_GetForOrder")
                dt.TableName = Entity.Sys.Enums.TableNames.tblProduct.ToString
                Return New DataView(dt)
            End Function

            Public Function [Insert](ByVal oOrder As Order) As Order
                _database.ClearParameter()
                AddOrderParametersToCommand(oOrder)

                oOrder.SetOrderID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("Order_Insert"))
                oOrder.Exists = True
                Return oOrder
            End Function

            Public Function [Insert](ByVal oOrder As Order, ByVal trans As SqlClient.SqlTransaction) As Order

                Dim Command As SqlClient.SqlCommand = New SqlClient.SqlCommand

                Command.CommandText = "Order_Insert"
                Command.CommandType = CommandType.StoredProcedure
                Command.Transaction = trans
                Command.Connection = trans.Connection

                Command.Parameters.AddWithValue("@DatePlaced", oOrder.DatePlaced)
                Command.Parameters.AddWithValue("@OrderTypeID", oOrder.OrderTypeID)
                Command.Parameters.AddWithValue("@OrderReference", oOrder.OrderReference)
                Command.Parameters.AddWithValue("@UserID", oOrder.UserID)
                Command.Parameters.AddWithValue("@OrderStatusID", oOrder.OrderStatusID)
                Command.Parameters.AddWithValue("@ReasonForReject", oOrder.ReasonForReject)

                If oOrder.DeliveryDeadline = Nothing Then
                    Command.Parameters.AddWithValue("@DeliveryDeadline", DBNull.Value)
                Else
                    Command.Parameters.AddWithValue("@DeliveryDeadline", oOrder.DeliveryDeadline)
                End If

                Command.Parameters.AddWithValue("@SpecialInstructions", oOrder.SpecialInstructions)
                Command.Parameters.AddWithValue("@ContactID", oOrder.ContactID)
                Command.Parameters.AddWithValue("@InvoiceAddressID", oOrder.InvoiceAddressID)
                Command.Parameters.AddWithValue("@AllocatedToUser", oOrder.AllocatedToUser)
                Command.Parameters.AddWithValue("@DepartmentRef", oOrder.DepartmentRef)
                Command.Parameters.AddWithValue("@DoNotConsolidated", oOrder.DoNotConsolidated)

                oOrder.SetOrderID = Entity.Sys.Helper.MakeIntegerValid(Command.ExecuteScalar)
                oOrder.Exists = True
                Return oOrder
            End Function

            Public Function Order_GetPartsSummaryForVan(ByVal OrderID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@OrderID", OrderID, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("Order_GetPartsSummaryForVan")
                dt.TableName = Entity.Sys.Enums.TableNames.tblOrder.ToString
                Return New DataView(dt)
            End Function

            Public Function Order_GetProductsSummaryForVan(ByVal OrderID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@OrderID", OrderID, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("Order_GetProductsSummaryForVan")
                dt.TableName = Entity.Sys.Enums.TableNames.tblOrder.ToString
                Return New DataView(dt)
            End Function

            Public Function Order_GetPartsSummaryForWarehouse(ByVal OrderID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@OrderID", OrderID, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("Order_GetPartsSummaryForWarehouse")
                dt.TableName = Entity.Sys.Enums.TableNames.tblOrder.ToString
                Return New DataView(dt)
            End Function

            Public Function Order_GetProductsSummaryForWarehouse(ByVal OrderID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@OrderID", OrderID, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("Order_GetProductsSummaryForWarehouse")
                dt.TableName = Entity.Sys.Enums.TableNames.tblOrder.ToString
                Return New DataView(dt)
            End Function

            Public Function [Order_SearchList](ByVal criteria As String) As DataView
                _database.ClearParameter()
                _database.AddParameter("@Criteria", criteria, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("Order_SearchList")
                dt.TableName = Entity.Sys.Enums.TableNames.tblOrder.ToString
                Return New DataView(dt)
            End Function

            Public Function Order_PriceRequests_GetAll(ByVal OrderID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@OrderID", OrderID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("Order_PriceRequests_GetAll")
                dt.TableName = Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_PriceRequests.ToString
                Return New DataView(dt)
            End Function

            Public Sub [Update](ByVal oOrder As Order)
                _database.ClearParameter()
                _database.AddParameter("@OrderID", oOrder.OrderID, True)
                AddOrderParametersToCommand(oOrder)
                _database.AddParameter("@Reason", oOrder.Reason, True)
                _database.ExecuteSP_NO_Return("Order_Update")
            End Sub

            Public Sub [Update_OrderRef](ByVal orderId As Integer, ByVal orderRef As String)
                _database.ClearParameter()
                _database.AddParameter("@OrderID", orderId, True)
                _database.AddParameter("@OrderRef", orderRef, True)
                _database.ExecuteSP_NO_Return("Order_Update_OrderReference")
            End Sub

            Private Sub AddOrderParametersToCommand(ByRef oOrder As Order)
                With _database
                    .AddParameter("@DatePlaced", oOrder.DatePlaced, True)
                    .AddParameter("@OrderTypeID", oOrder.OrderTypeID, True)
                    .AddParameter("@OrderReference", oOrder.OrderReference, True)
                    .AddParameter("@UserID", oOrder.UserID, True)
                    .AddParameter("@OrderStatusID", oOrder.OrderStatusID, True)
                    .AddParameter("@ReasonForReject", oOrder.ReasonForReject, True)
                    If oOrder.DeliveryDeadline = Nothing Then
                        .AddParameter("@DeliveryDeadline", DBNull.Value, True)
                    Else
                        .AddParameter("@DeliveryDeadline", oOrder.DeliveryDeadline, True)
                    End If

                    .AddParameter("@SpecialInstructions", oOrder.SpecialInstructions, True)
                    .AddParameter("@ContactID", oOrder.ContactID, True)
                    .AddParameter("@InvoiceAddressID", oOrder.InvoiceAddressID, True)
                    .AddParameter("@AllocatedToUser", oOrder.AllocatedToUser, True)

                    .AddParameter("@DepartmentRef", oOrder.DepartmentRef, True)

                    .AddParameter("@DoNotConsolidated", oOrder.DoNotConsolidated, True)
                End With
            End Sub

            Public Function Get_All_Places_Item_Can_Be_Got_From() As DataView
                Dim getFroms As New DataTable
                getFroms.Columns.Add(New DataColumn("ValueMember"))
                getFroms.Columns.Add(New DataColumn("DisplayMember"))
                getFroms.Columns.Add(New DataColumn("TableName"))

                Dim newRow As DataRow

                newRow = getFroms.NewRow()
                newRow.Item("ValueMember") = 0
                newRow.Item("DisplayMember") = Entity.Sys.Enums.ComboValues.Please_Select.ToString.Replace("_", " ").Replace("P", "--- P").Replace("t", "t ---")
                newRow.Item("TableName") = Entity.Sys.Enums.TableNames.NO_TABLE.ToString
                getFroms.Rows.Add(newRow)

                newRow = getFroms.NewRow()
                newRow.Item("ValueMember") = 1
                newRow.Item("DisplayMember") = "SUPPLIER"
                getFroms.Rows.Add(newRow)

                newRow = getFroms.NewRow()
                newRow.Item("ValueMember") = 3
                newRow.Item("DisplayMember") = "WAREHOUSE"
                getFroms.Rows.Add(newRow)

                newRow = getFroms.NewRow()
                newRow.Item("ValueMember") = 2
                newRow.Item("DisplayMember") = "VAN"
                getFroms.Rows.Add(newRow)

                Return New DataView(getFroms)
            End Function

            Public Function Order_GetEngineerNameFromPO(ByVal PONumber As String) As String
                _database.ClearParameter()
                _database.AddParameter("@PONumber", PONumber, True)
                Return _database.ExecuteScalar("SELECT TOP (1) tblEngineer.Name FROM tblVan INNER JOIN tblLocations ON tblVan.VanID = tblLocations.VanID INNER JOIN tblEngineerVan ON tblVan.VanID = tblEngineerVan.VanID INNER JOIN tblEngineer ON tblEngineerVan.EngineerID = tblEngineer.EngineerID INNER JOIN tblOrderLocation ON tblLocations.LocationID = tblOrderLocation.LocationID INNER JOIN tblOrder ON tblOrderLocation.OrderID = tblOrder.OrderID WHERE (tblVan.Deleted = 0) AND (tblLocations.Deleted = 0) AND (tblOrder.OrderReference = @PONumber) ORDER BY tblEngineerVan.StartDateTime DESC")
            End Function

            Public Function Order_Get_OrderID_ByRef(ByVal PONumber As String) As String
                _database.ClearParameter()
                _database.AddParameter("@PONumber", PONumber, True)
                Return _database.ExecuteScalar("SELECT TOP (1) OrderID FROM tblOrder WHERE (OrderReference = @PONumber) ORDER BY DatePlaced DESC")
            End Function

            Public Function [Search](ByVal criteria As String, ByVal userId As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@SearchString", criteria, True)
                _database.AddParameter("@UserID", userId, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("Order_Search_Mk1")
                dt.TableName = Entity.Sys.Enums.TableNames.tblOrder.ToString
                Return New DataView(dt)
            End Function

#End Region

            Public Sub ReallocateReceivedStock(ByVal LocationID As Integer,
                                                ByVal StockTransactionType As Integer,
                                                ByVal Type As String,
                                                ByVal PartProductID As Integer,
                                                ByVal Quantity As Integer,
                                                ByVal OrderPartProductID As Integer)

                If LocationID > 0 And StockTransactionType > 0 Then
                    Select Case Type
                        Case "Part"
                            Dim oPartTransaction As New Entity.PartTransactions.PartTransaction
                            oPartTransaction.SetLocationID = LocationID
                            oPartTransaction.SetPartID = PartProductID
                            oPartTransaction.SetOrderPartID = OrderPartProductID
                            If CInt(StockTransactionType) = CInt(Entity.Sys.Enums.Transaction.StockOut) Then
                                oPartTransaction.SetAmount = Quantity * -1
                            Else
                                oPartTransaction.SetAmount = Quantity
                            End If
                            oPartTransaction.SetTransactionTypeID = StockTransactionType
                            DB.PartTransaction.Insert(oPartTransaction)
                        Case "Product"
                            Dim oProductTransaction As New Entity.ProductTransactions.ProductTransaction
                            oProductTransaction.SetLocationID = LocationID
                            oProductTransaction.SetProductID = PartProductID
                            oProductTransaction.SetOrderProductID = OrderPartProductID
                            If CInt(StockTransactionType) = CInt(Entity.Sys.Enums.Transaction.StockOut) Then
                                oProductTransaction.SetAmount = Quantity * -1
                            Else
                                oProductTransaction.SetAmount = Quantity
                            End If
                            oProductTransaction.SetTransactionTypeID = StockTransactionType
                            DB.ProductTransaction.Insert(oProductTransaction)
                    End Select

                End If

            End Sub

            Public Sub AllocatedDistributions(ByVal PartsAndProductsDistribution As DataTable)
                For Each row As DataRow In PartsAndProductsDistribution.Rows

                    _database.ClearParameter()
                    _database.AddParameter("@LocationID", row.Item("LocationID"), True)
                    _database.AddParameter("@AllocatedID", row.Item("AllocatedID"), True)
                    _database.AddParameter("@Other", row.Item("Other"), True)
                    _database.AddParameter("@Quantity", row.Item("Quantity"), True)
                    _database.AddParameter("@PartProductID", row.Item("PartProductID"), True)
                    _database.AddParameter("@OrderPartProductID", row.Item("OrderPartProductID"), True)

                    _database.ExecuteSP_NO_Return("EngineerVisitPartDistributed_Insert")

                    If row.Item("StockTransactionType") = -1 Then
                        'PART CREDIT
                        Dim CurrentPartsToBeCredited As New Entity.PartsToBeCrediteds.PartsToBeCredited
                        CurrentPartsToBeCredited.IgnoreExceptionsOnSetMethods = True

                        Dim op As Entity.OrderParts.OrderPart = DB.OrderPart.OrderPart_Get(row.Item("OrderPartProductID"))
                        Dim ps As Entity.PartSuppliers.PartSupplier = DB.PartSupplier.PartSupplier_Get(op.PartSupplierID)

                        CurrentPartsToBeCredited.SetOrderID = op.OrderID
                        CurrentPartsToBeCredited.SetSupplierID = ps.SupplierID
                        CurrentPartsToBeCredited.SetPartID = row.Item("PartProductID")
                        CurrentPartsToBeCredited.SetQty = row.Item("Quantity")
                        CurrentPartsToBeCredited.SetStatusID = CInt(Entity.Sys.Enums.PartsToBeCreditedStatus.Awaiting_Part_Return)
                        CurrentPartsToBeCredited.SetManuallyAdded = False
                        CurrentPartsToBeCredited.SetOrderReference = DB.Order.Order_Get(op.OrderID).OrderReference
                        DB.PartsToBeCredited.Insert(CurrentPartsToBeCredited)

                    End If

                    If row.Item("LocationID") > 0 And row.Item("StockTransactionType") > 0 Then

                        Dim oPartTransaction As New Entity.PartTransactions.PartTransaction
                        oPartTransaction.SetLocationID = row.Item("LocationID")
                        oPartTransaction.SetPartID = row.Item("PartProductID")
                        oPartTransaction.SetOrderPartID = row.Item("OrderPartProductID")
                        If CInt(row("StockTransactionType")) = CInt(Entity.Sys.Enums.Transaction.StockOut) Then
                            oPartTransaction.SetAmount = row.Item("Quantity") * -1
                        Else
                            oPartTransaction.SetAmount = row.Item("Quantity")
                        End If
                        oPartTransaction.SetTransactionTypeID = row.Item("StockTransactionType")
                        DB.PartTransaction.Insert(oPartTransaction)

                    End If

                Next
            End Sub

            Public Function OrderStatus_Get_All() As DataView
                _database.ClearParameter()
                Dim dt As DataTable = _database.ExecuteSP_DataTable("OrderStatus_Get_All")
                Return New DataView(dt)
            End Function

            Public Function OrderStatus_Get_All_ForOrderManager() As DataView
                _database.ClearParameter()
                Dim dt As DataTable = _database.ExecuteSP_DataTable("OrderStatus_Get_All_ForOrderManager")
                Return New DataView(dt)
            End Function

        End Class

    End Namespace

End Namespace