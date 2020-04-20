Imports System.Data.SqlClient

Namespace Entity

Namespace OrderCharges

Public Class OrderChargeSQL
    Private _database As Sys.Database

    Public Sub New(ByVal database As Sys.Database)
        _database = database
    End Sub

#Region "Functions"

	
    Public Sub Delete(ByVal OrderChargeID As Integer)
    		_database.ClearParameter()
            _database.AddParameter("@OrderChargeID", OrderChargeID, True)
            _database.ExecuteSP_NO_Return("OrderCharge_Delete")
    End Sub

            Public Function OrderCharge_GetForOrder(ByVal OrderID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@OrderID", OrderID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("OrderCharge_GetForOrder")
                dt.TableName = Entity.Sys.Enums.TableNames.tblOrderCharge.ToString
                Return New DataView(dt)
            End Function

            Public Function [OrderCharge_Get](ByVal OrderChargeID As Integer) As OrderCharge
                _database.ClearParameter()
                _database.AddParameter("@OrderChargeID", OrderChargeID)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("OrderCharge_Get")

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oOrderCharge As New OrderCharge
                        With oOrderCharge
                            .IgnoreExceptionsOnSetMethods = True
                            .SetOrderChargeID = dt.Rows(0).Item("OrderChargeID")
                            .SetOrderID = dt.Rows(0).Item("OrderID")
                            .SetOrderChargeTypeID = dt.Rows(0).Item("OrderChargeTypeID")
                            .SetAmount = dt.Rows(0).Item("Amount")
                            .SetReference = dt.Rows(0).Item("Reference")

                            .SetDeleted = dt.Rows(0).Item("Deleted")
                        End With
                        oOrderCharge.Exists = True
                        Return oOrderCharge
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function OrderCharge_GetForConsolidatedOrder(ByVal OrderConsolidationID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@OrderConsolidationID", OrderConsolidationID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("OrderCharge_GetForConsolidatedOrder")
                dt.TableName = Entity.Sys.Enums.TableNames.tblOrderCharge.ToString
                Return New DataView(dt)
            End Function



            Public Function [OrderCharge_GetAll]() As DataView
                _database.ClearParameter()
                Dim dt As DataTable = _database.ExecuteSP_DataTable("OrderCharge_GetAll")
                dt.TableName = Entity.Sys.Enums.TableNames.tblOrderCharge.ToString
                Return New DataView(dt)
            End Function

            Public Function [Insert](ByVal oOrderCharge As OrderCharge) As OrderCharge
                _database.ClearParameter()
                AddOrderChargeParametersToCommand(oOrderCharge)

                oOrderCharge.SetOrderChargeID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("OrderCharge_Insert"))
                oOrderCharge.Exists = True
                Return oOrderCharge
            End Function


            Public Sub [Update](ByVal oOrderCharge As OrderCharge)
                _database.ClearParameter()
                _database.AddParameter("@OrderChargeID", oOrderCharge.OrderChargeID, True)
                AddOrderChargeParametersToCommand(oOrderCharge)
                _database.ExecuteSP_NO_Return("OrderCharge_Update")
            End Sub



            Private Sub AddOrderChargeParametersToCommand(ByRef oOrderCharge As OrderCharge)
                With _database
                    .AddParameter("@OrderID", oOrderCharge.OrderID, True)
                    .AddParameter("@OrderChargeTypeID", oOrderCharge.OrderChargeTypeID, True)
                    .AddParameter("@Amount", oOrderCharge.Amount, True)
                    .AddParameter("@Reference", oOrderCharge.Reference, True)



                End With
            End Sub


#End Region

End Class

End Namespace

End Namespace


