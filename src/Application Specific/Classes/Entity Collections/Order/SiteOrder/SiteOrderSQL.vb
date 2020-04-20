Imports System.Data.SqlClient

Namespace Entity

Namespace SiteOrders

Public Class SiteOrderSQL
    Private _database As Sys.Database

    Public Sub New(ByVal database As Sys.Database)
        _database = database
    End Sub

#Region "Functions"

	
    Public Sub Delete(ByVal SiteOrderID As Integer)
    		_database.ClearParameter()
            _database.AddParameter("@SiteOrderID", SiteOrderID, True)
            _database.ExecuteSP_NO_Return("SiteOrder_Delete")
            End Sub

            Public Sub DeleteByOrder(ByVal OrderID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@OrderID", OrderID, True)
                _database.ExecuteSP_NO_Return("SiteOrder_DeleteByOrder")
            End Sub

            Public Function [SiteOrder_Get](ByVal SiteOrderID As Integer) As SiteOrder
                _database.ClearParameter()
                _database.AddParameter("@SiteOrderID", SiteOrderID)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("SiteOrder_Get")

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oSiteOrder As New SiteOrder
                        With oSiteOrder
                            .IgnoreExceptionsOnSetMethods = True
                            .SetSiteOrderID = dt.Rows(0).Item("SiteOrderID")
                            .SetSiteID = dt.Rows(0).Item("SiteID")
                            .SetOrderID = dt.Rows(0).Item("OrderID")
                        End With
                        oSiteOrder.Exists = True
                        Return oSiteOrder
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function [SiteOrder_GetForOrder](ByVal OrderID As Integer) As SiteOrder
                _database.ClearParameter()
                _database.AddParameter("@OrderID", OrderID)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("SiteOrder_GetForOrder")

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oSiteOrder As New SiteOrder
                        With oSiteOrder
                            .IgnoreExceptionsOnSetMethods = True
                            .SetSiteOrderID = dt.Rows(0).Item("SiteOrderID")
                            .SetSiteID = dt.Rows(0).Item("SiteID")
                            .SetOrderID = dt.Rows(0).Item("OrderID")
                        End With
                        oSiteOrder.Exists = True
                        Return oSiteOrder
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function [SiteOrder_GetAll]() As DataView
                _database.ClearParameter()
                Dim dt As DataTable = _database.ExecuteSP_DataTable("SiteOrder_GetAll")
                dt.TableName = Entity.Sys.Enums.TableNames.tblSiteOrder.ToString
                Return New DataView(dt)
            End Function

            Public Function [Insert](ByVal oSiteOrder As SiteOrder, ByVal trans As SqlClient.SqlTransaction) As SiteOrder

                Dim Command As SqlClient.SqlCommand = New SqlClient.SqlCommand

                Command.CommandText = "SiteOrder_Insert"
                Command.CommandType = CommandType.StoredProcedure
                Command.Transaction = trans
                Command.Connection = trans.Connection

                Command.Parameters.AddWithValue("@OrderID", oSiteOrder.OrderID)
                Command.Parameters.AddWithValue("@SiteID", oSiteOrder.SiteID)

                oSiteOrder.SetSiteOrderID = Entity.Sys.Helper.MakeIntegerValid(Command.ExecuteScalar)
                oSiteOrder.Exists = True
                Return oSiteOrder

            End Function

            Public Function [Insert](ByVal oSiteOrder As SiteOrder) As SiteOrder
                _database.ClearParameter()
                AddSiteOrderParametersToCommand(oSiteOrder)

                oSiteOrder.SetSiteOrderID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("SiteOrder_Insert"))
                oSiteOrder.Exists = True
                Return oSiteOrder
            End Function

            Public Sub [Update](ByVal oSiteOrder As SiteOrder)
                _database.ClearParameter()
                _database.AddParameter("@SiteOrderID", oSiteOrder.SiteOrderID, True)
                AddSiteOrderParametersToCommand(oSiteOrder)
                _database.ExecuteSP_NO_Return("SiteOrder_Update")
            End Sub



            Private Sub AddSiteOrderParametersToCommand(ByRef oSiteOrder As SiteOrder)
                With _database
                    .AddParameter("@SiteID", oSiteOrder.SiteID, True)
                    .AddParameter("@OrderID", oSiteOrder.OrderID, True)



                End With
            End Sub


#End Region

End Class

End Namespace

End Namespace


