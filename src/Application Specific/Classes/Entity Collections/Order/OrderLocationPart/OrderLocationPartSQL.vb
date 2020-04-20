Imports System.Data.SqlClient

Namespace Entity

    Namespace OrderLocationPart

        Public Class OrderLocationPartSQL
            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

#Region "Functions"

            Public Sub Delete(ByVal OrderLocationPartID As Integer, ByVal trans As SqlClient.SqlTransaction)

                Dim Command As SqlClient.SqlCommand = New SqlClient.SqlCommand

                Command.CommandText = "OrderLocationPart_Delete"
                Command.CommandType = CommandType.StoredProcedure
                Command.Transaction = trans
                Command.Connection = trans.Connection

                Command.Parameters.AddWithValue("@OrderLocationPartID", OrderLocationPartID)
                Command.ExecuteNonQuery()

            End Sub

            Public Sub Delete(ByVal OrderLocationPartID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@OrderLocationPartID", OrderLocationPartID, True)
                _database.ExecuteSP_NO_Return("OrderLocationPart_Delete")
            End Sub

            Public Sub DeleteForOrder(ByVal OrderID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@OrderID", OrderID, True)
                _database.ExecuteSP_NO_Return("OrderLocationPart_DeleteForOrder")
            End Sub

            Public Function [OrderLocationPart_Get](ByVal OrderLocationPartID As Integer, ByVal trans As SqlClient.SqlTransaction) As OrderLocationPart

                Dim Command As SqlClient.SqlCommand = New SqlClient.SqlCommand

                Command.CommandText = "OrderLocationPart_Get"
                Command.CommandType = CommandType.StoredProcedure
                Command.Transaction = trans
                Command.Connection = trans.Connection

                Command.Parameters.AddWithValue("@OrderLocationPartID", OrderLocationPartID)

                Dim Adapter As New SqlClient.SqlDataAdapter(Command)
                Dim returnDS As New DataSet
                Adapter.Fill(returnDS)

                Dim dt As DataTable = returnDS.Tables(0)

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oOrderLocationPart As New OrderLocationPart
                        With oOrderLocationPart
                            .IgnoreExceptionsOnSetMethods = True
                            .SetOrderLocationPartID = dt.Rows(0).Item("OrderLocationPartID")
                            .SetPartID = dt.Rows(0).Item("PartID")
                            .SetLocationID = dt.Rows(0).Item("LocationID")
                            .SetQuantity = dt.Rows(0).Item("Quantity")
                            .SetQuantityReceived = dt.Rows(0).Item("QuantityReceived")
                            .SetOrderID = dt.Rows(0).Item("OrderID")
                            .SetSellPrice = dt.Rows(0).Item("SellPrice")
                            .SetDeleted = dt.Rows(0).Item("Deleted")
                        End With
                        oOrderLocationPart.Exists = True
                        Return oOrderLocationPart
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function [OrderLocationPart_Get](ByVal OrderLocationPartID As Integer) As OrderLocationPart
                _database.ClearParameter()
                _database.AddParameter("@OrderLocationPartID", OrderLocationPartID)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("OrderLocationPart_Get")

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oOrderLocationPart As New OrderLocationPart
                        With oOrderLocationPart
                            .IgnoreExceptionsOnSetMethods = True
                            .SetOrderLocationPartID = dt.Rows(0).Item("OrderLocationPartID")
                            .SetPartID = dt.Rows(0).Item("PartID")
                            .SetLocationID = dt.Rows(0).Item("LocationID")
                            .SetQuantity = dt.Rows(0).Item("Quantity")
                            .SetQuantityReceived = dt.Rows(0).Item("QuantityReceived")
                            .SetOrderID = dt.Rows(0).Item("OrderID")
                            .SetSellPrice = dt.Rows(0).Item("SellPrice")
                            .SetDeleted = dt.Rows(0).Item("Deleted")
                        End With
                        oOrderLocationPart.Exists = True
                        Return oOrderLocationPart
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function [OrderLocationPart_GetAll]() As DataView
                _database.ClearParameter()
                Dim dt As DataTable = _database.ExecuteSP_DataTable("OrderLocationPart_GetAll")
                dt.TableName = Entity.Sys.Enums.TableNames.tblOrderLocationPart.ToString
                Return New DataView(dt)
            End Function

            Public Function [Insert](ByVal oOrderLocationPart As OrderLocationPart, ByVal DoConsolidation As Boolean) As OrderLocationPart
                _database.ClearParameter()
                AddOrderLocationPartParametersToCommand(oOrderLocationPart)

                oOrderLocationPart.SetOrderLocationPartID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("OrderLocationPart_Insert"))
                oOrderLocationPart.Exists = True

                If DoConsolidation Then
                    DB.OrderConsolidations.Create_And_Insert_Location(oOrderLocationPart.LocationID, oOrderLocationPart.OrderID)
                End If

                Return oOrderLocationPart
            End Function

            Public Function [Insert](ByVal oOrderLocationPart As OrderLocationPart, ByVal DoConsolidation As Boolean, ByVal trans As SqlClient.SqlTransaction) As OrderLocationPart

                Dim Command As SqlClient.SqlCommand = New SqlClient.SqlCommand

                Command.CommandText = "OrderLocationPart_Insert"
                Command.CommandType = CommandType.StoredProcedure
                Command.Transaction = trans
                Command.Connection = trans.Connection

                Command.Parameters.AddWithValue("@PartID", oOrderLocationPart.PartID)
                Command.Parameters.AddWithValue("@LocationID", oOrderLocationPart.LocationID)
                Command.Parameters.AddWithValue("@Quantity", oOrderLocationPart.Quantity)
                Command.Parameters.AddWithValue("@QuantityReceived", oOrderLocationPart.QuantityReceived)
                Command.Parameters.AddWithValue("@OrderID", oOrderLocationPart.OrderID)
                Command.Parameters.AddWithValue("@SellPrice", oOrderLocationPart.SellPrice)
           
                oOrderLocationPart.SetOrderLocationPartID = Entity.Sys.Helper.MakeIntegerValid(Command.ExecuteScalar)
                oOrderLocationPart.Exists = True

                If DoConsolidation Then
                    DB.OrderConsolidations.Create_And_Insert_Location(oOrderLocationPart.LocationID, oOrderLocationPart.OrderID, trans)
                End If

                Return oOrderLocationPart
            End Function


            Public Sub [Update](ByVal oOrderLocationPart As OrderLocationPart)
                _database.ClearParameter()
                _database.AddParameter("@OrderLocationPartID", oOrderLocationPart.OrderLocationPartID, True)
                AddOrderLocationPartParametersToCommand(oOrderLocationPart)
                _database.ExecuteSP_NO_Return("OrderLocationPart_Update")
            End Sub



            Private Sub AddOrderLocationPartParametersToCommand(ByRef oOrderLocationPart As OrderLocationPart)
                With _database
                    .AddParameter("@PartID", oOrderLocationPart.PartID, True)
                    .AddParameter("@LocationID", oOrderLocationPart.LocationID, True)
                    .AddParameter("@Quantity", oOrderLocationPart.Quantity, True)
                    .AddParameter("@QuantityReceived", oOrderLocationPart.QuantityReceived, True)
                    .AddParameter("@OrderID", oOrderLocationPart.OrderID, True)
                    .AddParameter("@SellPrice", oOrderLocationPart.SellPrice, True)
                End With
            End Sub

            Public Sub EngineerReceived(ByVal OrderLocationPartID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@OrderLocationPartID", OrderLocationPartID, True)
                _database.ExecuteSP_NO_Return("OrderLocationPart_EngineerReceived")
            End Sub

            Public Sub MarkOrderQuantityReceived(ByVal OrderLocationPartID As Integer, ByVal OrderLocationQuantityOrdered As Integer)
                _database.ClearParameter()
                _database.AddParameter("@OrderLocationPartID", OrderLocationPartID, True)
                _database.AddParameter("@QuantityReceived", OrderLocationQuantityOrdered, True)
                _database.ExecuteSP_NO_Return("OrderLocationPart_MarkOrderQuantityReceived")
            End Sub

#End Region

        End Class

    End Namespace

End Namespace


