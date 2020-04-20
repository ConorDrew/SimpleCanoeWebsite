Imports System.Data.SqlClient

Namespace Entity

Namespace OrderProducts

Public Class OrderProductSQL
    Private _database As Sys.Database

    Public Sub New(ByVal database As Sys.Database)
        _database = database
    End Sub

#Region "Functions"

            Public Sub Delete(ByVal OrderProductID As Integer, ByVal trans As SqlClient.SqlTransaction)

                Dim Command As SqlClient.SqlCommand = New SqlClient.SqlCommand

                Command.CommandText = "OrderProduct_Delete"
                Command.CommandType = CommandType.StoredProcedure
                Command.Transaction = trans
                Command.Connection = trans.Connection

                Command.Parameters.AddWithValue("@OrderProductID", OrderProductID)
                Command.ExecuteNonQuery()

            End Sub
	
            Public Sub Delete(ByVal OrderProductID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@OrderProductID", OrderProductID, True)
                _database.ExecuteSP_NO_Return("OrderProduct_Delete")
            End Sub

            Public Sub DeleteForOrder(ByVal OrderID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@OrderID", OrderID, True)
                _database.ExecuteSP_NO_Return("OrderProduct_DeleteForOrder")
            End Sub

            Public Function [OrderProduct_Get](ByVal OrderProductID As Integer) As OrderProduct
                _database.ClearParameter()
                _database.AddParameter("@OrderProductID", OrderProductID)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("OrderProduct_Get")

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oOrderProduct As New OrderProduct
                        With oOrderProduct
                            .IgnoreExceptionsOnSetMethods = True
                            .SetOrderProductID = dt.Rows(0).Item("OrderProductID")
                            .SetProductSupplierID = dt.Rows(0).Item("ProductSupplierID")
                            .SetQuantity = dt.Rows(0).Item("Quantity")
                            .SetQuantityReceived = dt.Rows(0).Item("QuantityReceived")
                            .SetBuyPrice = dt.Rows(0).Item("BuyPrice")
                            .SetSellPrice = dt.Rows(0).Item("SellPrice")
                            .SetOrderID = dt.Rows(0).Item("OrderID")
                            .SetDispatchSiteID = dt.Rows(0).Item("DispatchSiteID")
                            .SetDispatchWarehouseID = dt.Rows(0).Item("DispatchWarehouseID")
                            .SetDeleted = dt.Rows(0).Item("Deleted")
                        End With
                        oOrderProduct.Exists = True
                        Return oOrderProduct
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function [OrderProduct_GetAll]() As DataView
                _database.ClearParameter()
                Dim dt As DataTable = _database.ExecuteSP_DataTable("OrderProduct_GetAll")
                dt.TableName = Entity.Sys.Enums.TableNames.tblOrderProduct.ToString
                Return New DataView(dt)
            End Function

            Public Function [Insert](ByVal oOrderProduct As OrderProduct, ByVal DoConsolidation As Boolean, ByVal trans As SqlClient.SqlTransaction) As OrderProduct

                Dim Command As SqlClient.SqlCommand = New SqlClient.SqlCommand

                Command.CommandText = "OrderProduct_Insert"
                Command.CommandType = CommandType.StoredProcedure
                Command.Transaction = trans
                Command.Connection = trans.Connection

                Command.Parameters.AddWithValue("@ProductSupplierID", oOrderProduct.ProductSupplierID)
                Command.Parameters.AddWithValue("@Quantity", oOrderProduct.Quantity)
                Command.Parameters.AddWithValue("@QuantityReceived", oOrderProduct.QuantityReceived)
                Command.Parameters.AddWithValue("@BuyPrice", oOrderProduct.BuyPrice)
                Command.Parameters.AddWithValue("@SellPrice", oOrderProduct.SellPrice)
                Command.Parameters.AddWithValue("@OrderID", oOrderProduct.OrderID)
                Command.Parameters.AddWithValue("@DispatchSiteID", oOrderProduct.DispatchSiteID)
                Command.Parameters.AddWithValue("@DispatchWarehouseID", oOrderProduct.DispatchWarehouseID)

                oOrderProduct.SetOrderProductID = Entity.Sys.Helper.MakeIntegerValid(Command.ExecuteScalar)
                oOrderProduct.Exists = True

                If DoConsolidation Then
                    DB.OrderConsolidations.Create_And_Insert_Supplier(0, oOrderProduct.ProductSupplierID, oOrderProduct.OrderID, trans)
                End If

                Return oOrderProduct
            End Function

            Public Function [Insert](ByVal oOrderProduct As OrderProduct, ByVal DoConsolidation As Boolean) As OrderProduct
                _database.ClearParameter()
                AddOrderProductParametersToCommand(oOrderProduct)

                oOrderProduct.SetOrderProductID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("OrderProduct_Insert"))
                oOrderProduct.Exists = True

                If DoConsolidation Then
                    DB.OrderConsolidations.Create_And_Insert_Supplier(0, oOrderProduct.ProductSupplierID, oOrderProduct.OrderID)
                End If

                Return oOrderProduct
            End Function

            Public Sub [Update](ByVal oOrderProduct As OrderProduct)
                _database.ClearParameter()
                _database.AddParameter("@OrderProductID", oOrderProduct.OrderProductID, True)
                AddOrderProductParametersToCommand(oOrderProduct)
                _database.ExecuteSP_NO_Return("OrderProduct_Update")
            End Sub

            Public Sub MarkOrderQuantityReceived(ByVal OrderProductID As Integer, ByVal QuantityReceived As Integer)
                _database.ClearParameter()
                _database.AddParameter("@OrderProductID", OrderProductID, True)
                _database.AddParameter("@QuantityReceived", QuantityReceived, True)
                _database.ExecuteSP_NO_Return("OrderProduct_MarkOrderQuantityReceived")
            End Sub

            Private Sub AddOrderProductParametersToCommand(ByRef oOrderProduct As OrderProduct)
                With _database
                    .AddParameter("@ProductSupplierID", oOrderProduct.ProductSupplierID, True)
                    .AddParameter("@Quantity", oOrderProduct.Quantity, True)
                    .AddParameter("@QuantityReceived", oOrderProduct.QuantityReceived, True)
                    .AddParameter("@BuyPrice", oOrderProduct.BuyPrice, True)
                    .AddParameter("@SellPrice", oOrderProduct.SellPrice, True)
                    .AddParameter("@OrderID", oOrderProduct.OrderID, True)
                    .AddParameter("@DispatchSiteID", oOrderProduct.DispatchSiteID, True)
                    .AddParameter("@DispatchWarehouseID", oOrderProduct.DispatchWarehouseID, True)
                End With
            End Sub


#End Region

End Class

End Namespace

End Namespace


