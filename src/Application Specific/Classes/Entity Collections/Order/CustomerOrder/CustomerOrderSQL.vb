Imports System.Data.SqlClient

Namespace Entity

    Namespace CustomerOrders

        Public Class CustomerOrderSQL
            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

#Region "Functions"

            Public Sub Delete(ByVal CustomerOrderID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@CustomerOrderID", CustomerOrderID, True)
                _database.ExecuteSP_NO_Return("CustomerOrder_Delete")
            End Sub

            Public Sub DeleteForOrder(ByVal OrderID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@OrderID", OrderID, True)
                _database.ExecuteSP_NO_Return("CustomerOrder_DeleteForOrder")
            End Sub

            Public Function CustomerOrder_GetForOrder(ByVal OrderID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@OrderID", OrderID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("CustomerOrder_GetForOrder")
                dt.TableName = Entity.Sys.Enums.TableNames.tblCustomer.ToString
                Return New DataView(dt)
            End Function

            Public Function [Insert](ByVal oCustomerOrder As CustomerOrder) As CustomerOrder
                _database.ClearParameter()
                AddCustomerOrderParametersToCommand(oCustomerOrder)

                oCustomerOrder.SetCustomerOrderID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("CustomerOrder_Insert"))
                oCustomerOrder.Exists = True
                Return oCustomerOrder
            End Function

            Public Function [Insert](ByVal oCustomerOrder As CustomerOrder, ByVal trans As SqlClient.SqlTransaction) As CustomerOrder

                Dim Command As SqlClient.SqlCommand = New SqlClient.SqlCommand

                Command.CommandText = "CustomerOrder_Insert"
                Command.CommandType = CommandType.StoredProcedure
                Command.Transaction = trans
                Command.Connection = trans.Connection

                Command.Parameters.AddWithValue("@OrderID", oCustomerOrder.OrderID)
                Command.Parameters.AddWithValue("@CustomerID", oCustomerOrder.CustomerID)

                oCustomerOrder.SetCustomerOrderID = Entity.Sys.Helper.MakeIntegerValid(Command.ExecuteScalar)
                oCustomerOrder.Exists = True

                Return oCustomerOrder

            End Function

            Public Sub [Update](ByVal oCustomerOrder As CustomerOrder)
                _database.ClearParameter()
                _database.AddParameter("@CustomerOrderID", oCustomerOrder.CustomerOrderID, True)
                AddCustomerOrderParametersToCommand(oCustomerOrder)
                _database.ExecuteSP_NO_Return("CustomerOrder_Update")
            End Sub

            Private Sub AddCustomerOrderParametersToCommand(ByRef oCustomerOrder As CustomerOrder)
                With _database
                    .AddParameter("@OrderID", oCustomerOrder.OrderID, True)
                    .AddParameter("@CustomerID", oCustomerOrder.CustomerID, True)

                End With
            End Sub

#End Region

        End Class

    End Namespace

End Namespace