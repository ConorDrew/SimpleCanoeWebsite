Imports System.Data.SqlClient

Namespace Entity

    Namespace OrderLocationProduct

        Public Class OrderLocationProductSQL
            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

#Region "Functions"


            Public Sub Delete(ByVal OrderLocationProductID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@OrderLocationProductID", OrderLocationProductID, True)
                _database.ExecuteSP_NO_Return("OrderLocationProduct_Delete")
            End Sub

            Public Sub Delete(ByVal OrderLocationProductID As Integer, ByVal trans As SqlClient.SqlTransaction)

                Dim Command As SqlClient.SqlCommand = New SqlClient.SqlCommand

                Command.CommandText = "OrderLocationProduct_Delete"
                Command.CommandType = CommandType.StoredProcedure
                Command.Transaction = trans
                Command.Connection = trans.Connection

                Command.Parameters.AddWithValue("@OrderLocationProductID", OrderLocationProductID)
                Command.ExecuteNonQuery()

            End Sub

            Public Sub DeleteForOrder(ByVal OrderID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@OrderID", OrderID, True)
                _database.ExecuteSP_NO_Return("OrderLocationProduct_DeleteForOrder")
            End Sub

            Public Function [OrderLocationProduct_Get](ByVal OrderLocationProductID As Integer, ByVal trans As SqlClient.SqlTransaction) As OrderLocationProduct

                Dim Command As SqlClient.SqlCommand = New SqlClient.SqlCommand

                Command.CommandText = "OrderLocationProduct_Get"
                Command.CommandType = CommandType.StoredProcedure
                Command.Transaction = trans
                Command.Connection = trans.Connection

                Command.Parameters.AddWithValue("@OrderLocationProductID", OrderLocationProductID)

                Dim Adapter As New SqlClient.SqlDataAdapter(Command)
                Dim returnDS As New DataSet
                Adapter.Fill(returnDS)

                Dim dt As DataTable = returnDS.Tables(0)

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oOrderLocationProduct As New OrderLocationProduct
                        With oOrderLocationProduct
                            .IgnoreExceptionsOnSetMethods = True
                            .SetOrderLocationProductID = dt.Rows(0).Item("OrderLocationProductID")
                            .SetProductID = dt.Rows(0).Item("ProductID")
                            .SetLocationID = dt.Rows(0).Item("LocationID")
                            .SetQuantity = dt.Rows(0).Item("Quantity")
                            .SetQuantityReceived = dt.Rows(0).Item("QuantityReceived")
                            .SetOrderID = dt.Rows(0).Item("OrderID")
                            .SetSellPrice = dt.Rows(0).Item("SellPrice")
                            .SetDeleted = dt.Rows(0).Item("Deleted")
                        End With
                        oOrderLocationProduct.Exists = True
                        Return oOrderLocationProduct
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function [OrderLocationProduct_Get](ByVal OrderLocationProductID As Integer) As OrderLocationProduct
                _database.ClearParameter()
                _database.AddParameter("@OrderLocationProductID", OrderLocationProductID)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("OrderLocationProduct_Get")

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oOrderLocationProduct As New OrderLocationProduct
                        With oOrderLocationProduct
                            .IgnoreExceptionsOnSetMethods = True
                            .SetOrderLocationProductID = dt.Rows(0).Item("OrderLocationProductID")
                            .SetProductID = dt.Rows(0).Item("ProductID")
                            .SetLocationID = dt.Rows(0).Item("LocationID")
                            .SetQuantity = dt.Rows(0).Item("Quantity")
                            .SetQuantityReceived = dt.Rows(0).Item("QuantityReceived")
                            .SetOrderID = dt.Rows(0).Item("OrderID")
                            .SetSellPrice = dt.Rows(0).Item("SellPrice")
                            .SetDeleted = dt.Rows(0).Item("Deleted")
                        End With
                        oOrderLocationProduct.Exists = True
                        Return oOrderLocationProduct
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function [OrderLocationProduct_GetAll]() As DataView
                _database.ClearParameter()
                Dim dt As DataTable = _database.ExecuteSP_DataTable("OrderLocationProduct_GetAll")
                dt.TableName = Entity.Sys.Enums.TableNames.tblOrderLocationProduct.ToString
                Return New DataView(dt)
            End Function

            Public Function [Insert](ByVal oOrderLocationProduct As OrderLocationProduct, ByVal DoConsolidation As Boolean) As OrderLocationProduct
                _database.ClearParameter()
                AddOrderLocationProductParametersToCommand(oOrderLocationProduct)

                oOrderLocationProduct.SetOrderLocationProductID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("OrderLocationProduct_Insert"))
                oOrderLocationProduct.Exists = True

                If DoConsolidation Then
                    DB.OrderConsolidations.Create_And_Insert_Location(oOrderLocationProduct.LocationID, oOrderLocationProduct.OrderID)
                End If

                Return oOrderLocationProduct
            End Function

            Public Function [Insert](ByVal oOrderLocationProduct As OrderLocationProduct, ByVal DoConsolidation As Boolean, ByVal trans As SqlClient.SqlTransaction) As OrderLocationProduct

                Dim Command As SqlClient.SqlCommand = New SqlClient.SqlCommand

                Command.CommandText = "OrderLocationProduct_Insert"
                Command.CommandType = CommandType.StoredProcedure
                Command.Transaction = trans
                Command.Connection = trans.Connection

                Command.Parameters.AddWithValue("@ProductID", oOrderLocationProduct.ProductID)
                Command.Parameters.AddWithValue("@LocationID", oOrderLocationProduct.LocationID)
                Command.Parameters.AddWithValue("@Quantity", oOrderLocationProduct.Quantity)
                Command.Parameters.AddWithValue("@QuantityReceived", oOrderLocationProduct.QuantityReceived)
                Command.Parameters.AddWithValue("@OrderID", oOrderLocationProduct.OrderID)
                Command.Parameters.AddWithValue("@SellPrice", oOrderLocationProduct.SellPrice)

                oOrderLocationProduct.SetOrderLocationProductID = Entity.Sys.Helper.MakeIntegerValid(Command.ExecuteScalar)
                oOrderLocationProduct.Exists = True

                If DoConsolidation Then
                    DB.OrderConsolidations.Create_And_Insert_Location(oOrderLocationProduct.LocationID, oOrderLocationProduct.OrderID, trans)
                End If

                Return oOrderLocationProduct
            End Function

            Public Sub [Update](ByVal oOrderLocationProduct As OrderLocationProduct)
                _database.ClearParameter()
                _database.AddParameter("@OrderLocationProductID", oOrderLocationProduct.OrderLocationProductID, True)
                AddOrderLocationProductParametersToCommand(oOrderLocationProduct)
                _database.ExecuteSP_NO_Return("OrderLocationProduct_Update")
            End Sub

            Private Sub AddOrderLocationProductParametersToCommand(ByRef oOrderLocationProduct As OrderLocationProduct)
                With _database
                    .AddParameter("@ProductID", oOrderLocationProduct.ProductID, True)
                    .AddParameter("@LocationID", oOrderLocationProduct.LocationID, True)
                    .AddParameter("@Quantity", oOrderLocationProduct.Quantity, True)
                    .AddParameter("@QuantityReceived", oOrderLocationProduct.QuantityReceived, True)
                    .AddParameter("@OrderID", oOrderLocationProduct.OrderID, True)
                    .AddParameter("@SellPrice", oOrderLocationProduct.SellPrice, True)
                End With
            End Sub
            Public Sub MarkOrderQuantityReceived(ByVal OrderLocationProductID As Integer, ByVal QuantityReceived As Integer)
                _database.ClearParameter()
                _database.AddParameter("@OrderLocationProductID", OrderLocationProductID, True)
                _database.AddParameter("@QuantityRecieved", QuantityReceived, True)
                _database.ExecuteSP_NO_Return("OrderLocationProduct_MarkOrderQuantityReceived")
            End Sub

#End Region

        End Class

    End Namespace

End Namespace


