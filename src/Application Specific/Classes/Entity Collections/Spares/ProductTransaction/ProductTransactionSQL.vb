Imports System.Data.SqlClient

Namespace Entity

Namespace ProductTransactions

Public Class ProductTransactionSQL
    Private _database As Sys.Database

    Public Sub New(ByVal database As Sys.Database)
        _database = database
    End Sub

#Region "Functions"

            Public Function ProductTransaction_GetByOrderLocationProduct(ByVal OrderLocationProductID As Integer, ByVal trans As SqlClient.SqlTransaction) As Entity.ProductTransactions.ProductTransaction

                Dim Command As SqlClient.SqlCommand = New SqlClient.SqlCommand

                Command.CommandText = "ProductTransaction_GetByOrderLocationProduct"
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
                        Dim oProductTransaction As New ProductTransaction
                        With oProductTransaction
                            .IgnoreExceptionsOnSetMethods = True
                            .SetProductTransactionID = dt.Rows(0).Item("ProductTransactionID")
                            .SetProductID = dt.Rows(0).Item("ProductID")
                            .SetAmount = dt.Rows(0).Item("Amount")
                            .TransactionDate = CDate(dt.Rows(0).Item("TransactionDate"))
                            .SetUserID = dt.Rows(0).Item("UserID")
                            .SetTransactionTypeID = dt.Rows(0).Item("TransactionTypeID")
                            .SetLocationID = dt.Rows(0).Item("LocationID")
                            .SetOrderProductID = dt.Rows(0).Item("OrderProductID")
                            .SetOrderLocationProductID = dt.Rows(0).Item("OrderLocationProductID")

                            .SetDeleted = dt.Rows(0).Item("Deleted")
                        End With
                        oProductTransaction.Exists = True
                        Return oProductTransaction
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function ProductTransaction_GetByOrderLocationProduct(ByVal OrderLocationProductID As Integer) As Entity.ProductTransactions.ProductTransaction
                _database.ClearParameter()
                _database.AddParameter("@OrderLocationProductID", OrderLocationProductID)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("ProductTransaction_GetByOrderLocationProduct")

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oProductTransaction As New ProductTransaction
                        With oProductTransaction
                            .IgnoreExceptionsOnSetMethods = True
                            .SetProductTransactionID = dt.Rows(0).Item("ProductTransactionID")
                            .SetProductID = dt.Rows(0).Item("ProductID")
                            .SetAmount = dt.Rows(0).Item("Amount")
                            .TransactionDate = CDate(dt.Rows(0).Item("TransactionDate"))
                            .SetUserID = dt.Rows(0).Item("UserID")
                            .SetTransactionTypeID = dt.Rows(0).Item("TransactionTypeID")
                            .SetLocationID = dt.Rows(0).Item("LocationID")
                            .SetOrderProductID = dt.Rows(0).Item("OrderProductID")
                            .SetOrderLocationProductID = dt.Rows(0).Item("OrderLocationProductID")

                            .SetDeleted = dt.Rows(0).Item("Deleted")
                        End With
                        oProductTransaction.Exists = True
                        Return oProductTransaction
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function ProductTransaction_Consolidate_All(ByVal LocationID As Integer, ByVal ProductID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@LocationID", LocationID, True)
                _database.AddParameter("@ProductID", ProductID, True)
                _database.ExecuteSP_NO_Return("ProductTransaction_Consolidate_All")
            End Function

            Public Function SearchByVan(ByVal SearchString As String, ByVal LocationID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@SearchString", SearchString, True)
                _database.AddParameter("@LocationID", LocationID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("Product_SearchByVan")
                dt.TableName = Entity.Sys.Enums.TableNames.tblProduct.ToString
                Return New DataView(dt)
            End Function

            Public Function GetByVan(ByVal VanID As Integer, Optional ByVal WithLocation As Boolean = False) As DataView
                If WithLocation Then
                    Dim registration As String = DB.Van.Van_Get(VanID).Registration.Split("*")(0).Trim

                    Dim dt As New DataTable
                    dt.Columns.Add(New DataColumn("Location"))
                    dt.Columns.Add(New DataColumn("ProductID", System.Type.GetType("System.Int32")))
                    dt.Columns.Add(New DataColumn("typemakemodel"))
                    dt.Columns.Add(New DataColumn("ProductNumber"))
                    dt.Columns.Add(New DataColumn("Amount", System.Type.GetType("System.Int32")))
                    dt.Columns.Add(New DataColumn("LocationID", System.Type.GetType("System.Int32")))

                    For Each vanRow As DataRow In DB.Van.Van_GetAll(False).Table.Rows
                        If Sys.Helper.MakeStringValid(vanRow.Item("Registration")).Split("*")(0).Trim = registration Then
                            _database.ClearParameter()
                            _database.AddParameter("@VanID", vanRow.Item("VanID"), True)

                            For Each row As DataRow In _database.ExecuteSP_DataTable("Product_GetByVan").Rows
                                Dim r As DataRow = dt.NewRow
                                r("Location") = Sys.Helper.MakeStringValid(vanRow.Item("Registration")).Split("*")(1).Trim
                                r("ProductID") = row.Item("ProductID")
                                r("typemakemodel") = row.Item("typemakemodel")
                                r("ProductNumber") = row.Item("ProductNumber")
                                r("Amount") = row.Item("Amount")
                                r("LocationID") = row.Item("LocationID")
                                dt.Rows.Add(r)
                            Next
                        End If
                    Next

                    dt.TableName = Entity.Sys.Enums.TableNames.tblProduct.ToString
                    Return New DataView(dt)
                Else
                    _database.ClearParameter()
                    _database.AddParameter("@VanID", VanID, True)
         
                    Dim dt As DataTable = _database.ExecuteSP_DataTable("Product_GetByVan")
                    dt.TableName = Entity.Sys.Enums.TableNames.tblProduct.ToString
                    Return New DataView(dt)
                End If
            End Function

            Public Function GetByWarehouse(ByVal WarehouseID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@WarehouseID", WarehouseID, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("Product_GetByWarehouse")
                dt.TableName = Entity.Sys.Enums.TableNames.tblProduct.ToString
                Return New DataView(dt)
            End Function

            Public Function SearchByWarehouse(ByVal SearchString As String, ByVal LocationID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@SearchString", SearchString, True)
                _database.AddParameter("@LocationID", LocationID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("Product_SearchByWarehouse")
                dt.TableName = Entity.Sys.Enums.TableNames.tblProduct.ToString
                Return New DataView(dt)
            End Function

            Public Sub DeleteForOrder(ByVal OrderID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@OrderID", OrderID, True)
                _database.ExecuteSP_NO_Return("ProductTransactions_DeleteForOrder")
            End Sub

            Public Sub Delete(ByVal ProductTransactionID As Integer, ByVal trans As SqlClient.SqlTransaction)

                Dim Command As SqlClient.SqlCommand = New SqlClient.SqlCommand

                Command.CommandText = "ProductTransaction_Delete"
                Command.CommandType = CommandType.StoredProcedure
                Command.Transaction = trans
                Command.Connection = trans.Connection
                Command.Parameters.AddWithValue("@ProductTransactionID", ProductTransactionID)

                Command.ExecuteNonQuery()

            End Sub

            Public Sub Delete(ByVal ProductTransactionID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@ProductTransactionID", ProductTransactionID, True)
                _database.ExecuteSP_NO_Return("ProductTransaction_Delete")
            End Sub

            Public Function [ProductTransaction_Get](ByVal ProductTransactionID As Integer) As ProductTransaction
                _database.ClearParameter()
                _database.AddParameter("@ProductTransactionID", ProductTransactionID)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("ProductTransaction_Get")

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oProductTransaction As New ProductTransaction
                        With oProductTransaction
                            .IgnoreExceptionsOnSetMethods = True
                            .SetProductTransactionID = dt.Rows(0).Item("ProductTransactionID")
                            .SetProductID = dt.Rows(0).Item("ProductID")
                            .SetAmount = dt.Rows(0).Item("Amount")
                            .TransactionDate = CDate(dt.Rows(0).Item("TransactionDate"))
                            .SetUserID = dt.Rows(0).Item("UserID")
                            .SetTransactionTypeID = dt.Rows(0).Item("TransactionTypeID")
                            .SetLocationID = dt.Rows(0).Item("LocationID")
                            .SetOrderProductID = dt.Rows(0).Item("OrderProductID")
                            .SetOrderLocationProductID = dt.Rows(0).Item("OrderLocationProductID")

                            .SetDeleted = dt.Rows(0).Item("Deleted")
                        End With
                        oProductTransaction.Exists = True
                        Return oProductTransaction
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function [ProductTransaction_GetAll]() As DataView
                _database.ClearParameter()
                Dim dt As DataTable = _database.ExecuteSP_DataTable("ProductTransaction_GetAll")
                dt.TableName = Entity.Sys.Enums.TableNames.tblProductTransaction.ToString
                Return New DataView(dt)
            End Function

            Public Function [Insert](ByVal oProductTransaction As ProductTransaction, ByVal trans As SqlClient.SqlTransaction) As ProductTransaction

                Dim Command As SqlClient.SqlCommand = New SqlClient.SqlCommand

                Command.CommandText = "ProductTransaction_Insert"
                Command.CommandType = CommandType.StoredProcedure
                Command.Transaction = trans
                Command.Connection = trans.Connection

                Command.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ProductID", oProductTransaction.ProductID))
                Command.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Amount", oProductTransaction.Amount))
                Command.Parameters.Add(New System.Data.SqlClient.SqlParameter("@UserID", loggedInUser.UserID))
                Command.Parameters.Add(New System.Data.SqlClient.SqlParameter("@TransactionTypeID", oProductTransaction.TransactionTypeID))
                Command.Parameters.Add(New System.Data.SqlClient.SqlParameter("@LocationID", oProductTransaction.LocationID))
                Command.Parameters.Add(New System.Data.SqlClient.SqlParameter("@OrderProductID", oProductTransaction.OrderProductID))
                Command.Parameters.Add(New System.Data.SqlClient.SqlParameter("@OrderLocationProductID", oProductTransaction.OrderLocationProductID))

                oProductTransaction.SetProductTransactionID = Command.ExecuteScalar
                oProductTransaction.Exists = True

                Return oProductTransaction

            End Function

            Public Function [Insert](ByVal oProductTransaction As ProductTransaction) As ProductTransaction
                _database.ClearParameter()
                AddProductTransactionParametersToCommand(oProductTransaction)

                oProductTransaction.SetProductTransactionID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("ProductTransaction_Insert"))
                oProductTransaction.Exists = True
                Return oProductTransaction
            End Function


            Public Sub [Update](ByVal oProductTransaction As ProductTransaction)
                _database.ClearParameter()
                _database.AddParameter("@ProductTransactionID", oProductTransaction.ProductTransactionID, True)
                AddProductTransactionParametersToCommand(oProductTransaction)

                _database.ExecuteSP_NO_Return("ProductTransaction_Update")
            End Sub

            Private Sub AddProductTransactionParametersToCommand(ByVal oProductTransaction As ProductTransaction)
                _database.AddParameter("@ProductID", oProductTransaction.ProductID, True)
                _database.AddParameter("@Amount", oProductTransaction.Amount, True)
                _database.AddParameter("@UserID", loggedInUser.UserID, True)
                _database.AddParameter("@TransactionTypeID", oProductTransaction.TransactionTypeID, True)
                _database.AddParameter("@LocationID", oProductTransaction.LocationID, True)
                _database.AddParameter("@OrderProductID", oProductTransaction.OrderProductID, True)
                _database.AddParameter("@OrderLocationProductID", oProductTransaction.OrderLocationProductID, True)
            End Sub

#End Region

End Class

End Namespace

End Namespace


