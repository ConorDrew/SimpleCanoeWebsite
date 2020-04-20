Imports System.Data.SqlClient

Namespace Entity

    Namespace EngineerVisitOrders

        Public Class EngineerVisitOrderSQL
            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

#Region "Functions"

            Public Sub EngineerVisitOrder_DeleteForOrder(ByVal OrderID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@OrderID", OrderID, True)
   
                _database.ExecuteSP_NO_Return("EngineerVisitOrder_DeleteForOrder")
            End Sub

            Public Sub Delete(ByVal EngineerVisitOrderID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@EngineerVisitOrderID", EngineerVisitOrderID, True)
                _database.ExecuteSP_NO_Return("EngineerVistOrder_Delete")
            End Sub
            Public Function EngineerVisitOrder_Get(ByVal EngineerVisitID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@EngineerVisitID", EngineerVisitID)

                'Get the datatable from the database store in dt
                Return New DataView(_database.ExecuteSP_DataTable("EngineerVisitOrder_Get"))
            End Function

            Public Function EngineerVisitOrder_GetForOrder(ByVal OrderID As Integer) As EngineerVisitOrder
                _database.ClearParameter()
                _database.AddParameter("@OrderID", OrderID)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("EngineerVisitOrder_GetForOrder")

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oEngineerVisitOrder As New EngineerVisitOrder
                        With oEngineerVisitOrder
                            .IgnoreExceptionsOnSetMethods = True
                            .SetEngineerVisitOrderID = dt.Rows(0).Item("EngineerVisitOrderID")
                            .SetOrderID = dt.Rows(0).Item("OrderID")
                            .SetEngineerVisitID = dt.Rows(0).Item("EngineerVisitID")
                            .SetWarehouseID = dt.Rows(0).Item("WarehouseID")
                            .Exists = True
                        End With
                        Return oEngineerVisitOrder
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function [Insert](ByVal oEngineerVisitOrder As EngineerVisitOrder) As EngineerVisitOrder
                _database.ClearParameter()
                AddEngineerVisitOrderParametersToCommand(oEngineerVisitOrder)

                oEngineerVisitOrder.SetEngineerVisitOrderID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("EngineerVisitOrder_Insert"))
                oEngineerVisitOrder.Exists = True
                Return oEngineerVisitOrder
            End Function

            Public Function [Insert](ByVal oEngineerVisitOrder As EngineerVisitOrder, ByVal trans As SqlClient.SqlTransaction) As EngineerVisitOrder

                Dim Command As SqlClient.SqlCommand = New SqlClient.SqlCommand

                Command.CommandText = "EngineerVisitOrder_Insert"
                Command.CommandType = CommandType.StoredProcedure
                Command.Transaction = trans
                Command.Connection = trans.Connection

                Command.Parameters.AddWithValue("@OrderID", oEngineerVisitOrder.OrderID)
                Command.Parameters.AddWithValue("@EngineerVisitID", oEngineerVisitOrder.EngineerVisitID)
                Command.Parameters.AddWithValue("@WarehouseID", oEngineerVisitOrder.WarehouseID)

                oEngineerVisitOrder.SetEngineerVisitOrderID = Entity.Sys.Helper.MakeIntegerValid(Command.ExecuteScalar)
                oEngineerVisitOrder.Exists = True
                Return oEngineerVisitOrder

            End Function


            Public Sub [Update](ByVal oEngineerVisitOrder As EngineerVisitOrder)
                _database.ClearParameter()
                _database.AddParameter("@EngineerVisitOrderID", oEngineerVisitOrder.EngineerVisitOrderID, True)
                AddEngineerVisitOrderParametersToCommand(oEngineerVisitOrder)
                _database.ExecuteSP_NO_Return("EngineerVisitOrder_Update")
            End Sub



            Private Sub AddEngineerVisitOrderParametersToCommand(ByRef oEngineerVisitOrder As EngineerVisitOrder)
                With _database
                    .AddParameter("@OrderID", oEngineerVisitOrder.OrderID, True)
                    .AddParameter("@EngineerVisitID", oEngineerVisitOrder.EngineerVisitID, True)
                    .AddParameter("@WarehouseID", oEngineerVisitOrder.WarehouseID, True)

                End With
            End Sub


#End Region

        End Class

    End Namespace

End Namespace


