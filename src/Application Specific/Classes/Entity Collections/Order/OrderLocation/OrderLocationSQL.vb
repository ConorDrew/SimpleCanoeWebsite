Imports System.Data.SqlClient

Namespace Entity

Namespace OrderLocations

        Public Class OrderLocationSQL

            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

#Region "Functions"

            Public Sub Delete(ByVal OrderLocationID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@OrderLocationID", OrderLocationID, True)
                _database.ExecuteSP_NO_Return("OrderLocation_Delete")
            End Sub

            Public Sub DeleteForOrder(ByVal OrderID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@OrderID", OrderID, True)
                _database.ExecuteSP_NO_Return("OrderLocation_DeleteForOrder")
            End Sub

            Public Function OrderLocation_GetForOrder(ByVal OrderID As Integer) As OrderLocation
                _database.ClearParameter()
                _database.AddParameter("@OrderID", OrderID)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("OrderLocation_GetForOrder")

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oOrderLocation As New OrderLocation
                        With oOrderLocation
                            .IgnoreExceptionsOnSetMethods = True
                            .SetOrderLocationID = dt.Rows(0).Item("OrderLocationID")
                            .SetOrderID = dt.Rows(0).Item("OrderID")
                            .SetLocationID = dt.Rows(0).Item("LocationID")
                            .SetDeliveryAddressID = Entity.Sys.Helper.MakeIntegerValid(dt.Rows(0).Item("DeliveryAddressID"))
                            .SetDeleted = dt.Rows(0).Item("Deleted")
                        End With
                        oOrderLocation.Exists = True
                        Return oOrderLocation
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function [OrderLocation_Get](ByVal OrderLocationID As Integer) As OrderLocation
                _database.ClearParameter()
                _database.AddParameter("@OrderLocationID", OrderLocationID)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("OrderLocation_Get")

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oOrderLocation As New OrderLocation
                        With oOrderLocation
                            .IgnoreExceptionsOnSetMethods = True
                            .SetOrderLocationID = dt.Rows(0).Item("OrderLocationID")
                            .SetOrderID = dt.Rows(0).Item("OrderID")
                            .SetLocationID = dt.Rows(0).Item("LocationID")
                            .SetDeliveryAddressID = Entity.Sys.Helper.MakeIntegerValid(dt.Rows(0).Item("DeliveryAddressID"))
                            .SetDeleted = dt.Rows(0).Item("Deleted")
                        End With
                        oOrderLocation.Exists = True
                        Return oOrderLocation
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function [OrderLocation_GetAll]() As DataView
                _database.ClearParameter()
                Dim dt As DataTable = _database.ExecuteSP_DataTable("OrderLocation_GetAll")
                dt.TableName = Entity.Sys.Enums.TableNames.tblOrderLocation.ToString
                Return New DataView(dt)
            End Function

            Public Function [Insert](ByVal oOrderLocation As OrderLocation, ByVal trans As SqlClient.SqlTransaction) As OrderLocation

                Dim Command As SqlClient.SqlCommand = New SqlClient.SqlCommand

                Command.CommandText = "OrderLocation_Insert"
                Command.CommandType = CommandType.StoredProcedure
                Command.Transaction = trans
                Command.Connection = trans.Connection

                Command.Parameters.AddWithValue("@OrderID", oOrderLocation.OrderID)
                Command.Parameters.AddWithValue("@LocationID", oOrderLocation.LocationID)
                Command.Parameters.AddWithValue("@DeliveryAddressID", oOrderLocation.DeliveryAddressID)

                oOrderLocation.SetOrderLocationID = Entity.Sys.Helper.MakeIntegerValid(Command.ExecuteScalar)
                oOrderLocation.Exists = True

                Return oOrderLocation

            End Function

            Public Function [Insert](ByVal oOrderLocation As OrderLocation) As OrderLocation
                _database.ClearParameter()
                AddOrderLocationParametersToCommand(oOrderLocation)

                oOrderLocation.SetOrderLocationID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("OrderLocation_Insert"))
                oOrderLocation.Exists = True
                Return oOrderLocation
            End Function

            Public Sub [Update](ByVal oOrderLocation As OrderLocation)
                _database.ClearParameter()
                _database.AddParameter("@OrderLocationID", oOrderLocation.OrderLocationID, True)
                AddOrderLocationParametersToCommand(oOrderLocation)
                _database.ExecuteSP_NO_Return("OrderLocation_Update")
            End Sub

            Private Sub AddOrderLocationParametersToCommand(ByRef oOrderLocation As OrderLocation)
                With _database
                    .AddParameter("@OrderID", oOrderLocation.OrderID, True)
                    .AddParameter("@LocationID", oOrderLocation.LocationID, True)
                    .AddParameter("@DeliveryAddressID", oOrderLocation.DeliveryAddressID, True)
                End With
            End Sub

#End Region

        End Class

End Namespace

End Namespace


