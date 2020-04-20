Imports System.Data.SqlClient

Namespace Entity

    Namespace OrderParts

        Public Class OrderPartSQL
            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

#Region "Functions"

            Public Sub Delete(ByVal OrderPartID As Integer, ByVal trans As SqlClient.SqlTransaction)

                Dim Command As SqlClient.SqlCommand = New SqlClient.SqlCommand
                Command.CommandText = "OrderPart_Delete"
                Command.CommandType = CommandType.StoredProcedure

                Command.Transaction = trans
                Command.Connection = trans.Connection

                Command.Parameters.AddWithValue("@OrderPartID", OrderPartID)
                Command.ExecuteNonQuery()

            End Sub

            Public Sub Delete(ByVal OrderPartID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@OrderPartID", OrderPartID, True)
                _database.ExecuteSP_NO_Return("OrderPart_Delete")
            End Sub

            Public Sub DeleteForOrder(ByVal OrderID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@OrderID", OrderID, True)
                _database.ExecuteSP_NO_Return("OrderPart_DeleteForOrder")
            End Sub

            Public Function [OrderPart_Get](ByVal OrderPartID As Integer) As OrderPart
                _database.ClearParameter()
                _database.AddParameter("@OrderPartID", OrderPartID)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("OrderPart_Get")

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oOrderPart As New OrderPart
                        With oOrderPart
                            .IgnoreExceptionsOnSetMethods = True
                            .SetOrderPartID = dt.Rows(0).Item("OrderPartID")
                            .SetOrderID = dt.Rows(0).Item("OrderID")
                            .SetPartSupplierID = dt.Rows(0).Item("PartSupplierID")
                            .SetQuantity = dt.Rows(0).Item("Quantity")
                            .SetQuantityReceived = dt.Rows(0).Item("QuantityReceived")
                            .SetBuyPrice = dt.Rows(0).Item("BuyPrice")
                            .SetSellPrice = dt.Rows(0).Item("SellPrice")
                            .SetDispatchSiteID = dt.Rows(0).Item("DispatchSiteID")
                            .SetDispatchWarehouseID = dt.Rows(0).Item("DispatchWarehouseID")
                            .SetDeleted = dt.Rows(0).Item("Deleted")
                            .SetChildSupplierID = dt.Rows(0).Item("ChildSupplierID")
                            .SetSpecialDescription = dt.Rows(0).Item("SpecialDescription")
                            .SetSpecialPartNumber = dt.Rows(0).Item("SpecialPartNumber")
                        End With
                        oOrderPart.Exists = True
                        Return oOrderPart
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function [OrderPart_GetAll]() As DataView
                _database.ClearParameter()
                Dim dt As DataTable = _database.ExecuteSP_DataTable("OrderPart_GetAll")
                dt.TableName = Entity.Sys.Enums.TableNames.tblOrderPart.ToString
                Return New DataView(dt)
            End Function

            Public Function [Insert](ByVal oOrderPart As OrderPart, ByVal DoConsolidation As Boolean) As OrderPart
                _database.ClearParameter()
                AddOrderPartParametersToCommand(oOrderPart)

                oOrderPart.SetOrderPartID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("OrderPart_Insert"))
                oOrderPart.Exists = True

                If DoConsolidation Then
                    DB.OrderConsolidations.Create_And_Insert_Supplier(oOrderPart.PartSupplierID, 0, oOrderPart.OrderID)
                End If

                Return oOrderPart
            End Function

            Public Function [Insert](ByVal oOrderPart As OrderPart, ByVal DoConsolidation As Boolean, ByVal trans As SqlClient.SqlTransaction) As OrderPart

                Dim Command As SqlClient.SqlCommand = New SqlClient.SqlCommand

                Command.CommandText = "OrderPart_Insert"
                Command.CommandType = CommandType.StoredProcedure
                Command.Transaction = trans
                Command.Connection = trans.Connection

                Command.Parameters.AddWithValue("@PartSupplierID", oOrderPart.PartSupplierID)
                Command.Parameters.AddWithValue("@Quantity", oOrderPart.Quantity)
                Command.Parameters.AddWithValue("@QuantityReceived", oOrderPart.QuantityReceived)
                Command.Parameters.AddWithValue("@BuyPrice", oOrderPart.BuyPrice)
                Command.Parameters.AddWithValue("@SellPrice", oOrderPart.SellPrice)
                Command.Parameters.AddWithValue("@OrderID", oOrderPart.OrderID)
                Command.Parameters.AddWithValue("@DispatchSiteID", oOrderPart.DispatchSiteID)
                Command.Parameters.AddWithValue("@DispatchWarehouseID", oOrderPart.DispatchWarehouseID)
                Command.Parameters.AddWithValue("@ChildSupplierID", oOrderPart.ChildSupplierID)
                Command.Parameters.AddWithValue("@SpecialDescription", oOrderPart.SpecialDescription)
                Command.Parameters.AddWithValue("@SpecialPartNumber", oOrderPart.SpecialPartNumber)

                oOrderPart.SetOrderPartID = Entity.Sys.Helper.MakeIntegerValid(Command.ExecuteScalar)
                oOrderPart.Exists = True

                If DoConsolidation Then
                    DB.OrderConsolidations.Create_And_Insert_Supplier(oOrderPart.PartSupplierID, 0, oOrderPart.OrderID, trans)
                End If

                Return oOrderPart
            End Function


            Public Sub [Update](ByVal oOrderPart As OrderPart)
                _database.ClearParameter()
                _database.AddParameter("@OrderPartID", oOrderPart.OrderPartID, True)
                AddOrderPartParametersToCommand(oOrderPart)
                _database.ExecuteSP_NO_Return("OrderPart_Update")
            End Sub

            Public Sub MarkOrderQuantityReceived(ByVal OrderPartID As Integer, ByVal QuantityReceived As Integer)
                _database.ClearParameter()
                _database.AddParameter("@OrderPartID", OrderPartID, True)
                _database.AddParameter("@QuantityReceived", QuantityReceived, True)
                _database.ExecuteSP_NO_Return("OrderPart_MarkOrderQuantityReceived")
            End Sub

            Private Sub AddOrderPartParametersToCommand(ByRef oOrderPart As OrderPart)
                With _database
                    .AddParameter("@OrderID", oOrderPart.OrderID, True)
                    .AddParameter("@PartSupplierID", oOrderPart.PartSupplierID, True)
                    .AddParameter("@Quantity", oOrderPart.Quantity, True)
                    .AddParameter("@QuantityReceived", oOrderPart.QuantityReceived, True)
                    .AddParameter("@BuyPrice", oOrderPart.BuyPrice, True)
                    .AddParameter("@SellPrice", oOrderPart.SellPrice, True)
                    .AddParameter("@DispatchSiteID", oOrderPart.DispatchSiteID, True)
                    .AddParameter("@DispatchWarehouseID", oOrderPart.DispatchWarehouseID, True)
                    .AddParameter("@ChildSupplierID", oOrderPart.ChildSupplierID, True)
                    .AddParameter("@SpecialDescription", oOrderPart.SpecialDescription, True)
                    .AddParameter("@SpecialPartNumber", oOrderPart.SpecialPartNumber, True)
                End With
            End Sub

            Public Sub EngineerReceived(ByVal OrderPartID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@OrderPartID", OrderPartID, True)
                _database.ExecuteSP_NO_Return("OrderPart_EngineerReceived")
            End Sub
#End Region

        End Class

    End Namespace

End Namespace


