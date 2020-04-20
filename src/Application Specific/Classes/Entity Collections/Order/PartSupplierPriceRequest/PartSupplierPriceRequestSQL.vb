Imports System.Data.SqlClient

Namespace Entity

Namespace PartSupplierPriceRequests

Public Class PartSupplierPriceRequestSQL
    Private _database As Sys.Database

    Public Sub New(ByVal database As Sys.Database)
        _database = database
    End Sub

#Region "Functions"

            Public Sub DeleteForOrder(ByVal OrderID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@OrderID", OrderID, True)
                _database.ExecuteSP_NO_Return("PartSupplierPriceRequest_DeleteForOrder")
            End Sub

            Public Sub Delete(ByVal PartSupplierPriceRequestID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@PartSupplierPriceRequestID", PartSupplierPriceRequestID, True)
                _database.ExecuteSP_NO_Return("PartSupplierPriceRequest_Delete")
            End Sub

            Public Function [PartSupplierPriceRequest_Get](ByVal PartSupplierPriceRequestID As Integer) As PartSupplierPriceRequest
                _database.ClearParameter()
                _database.AddParameter("@PartSupplierPriceRequestID", PartSupplierPriceRequestID)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("PartSupplierPriceRequest_Get")

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oPartSupplierPriceRequest As New PartSupplierPriceRequest
                        With oPartSupplierPriceRequest
                            .IgnoreExceptionsOnSetMethods = True
                            .SetPartSupplierPriceRequestID = dt.Rows(0).Item("PartSupplierPriceRequestID")
                            .SetOrderID = dt.Rows(0).Item("OrderID")
                            .SetSupplierID = dt.Rows(0).Item("SupplierID")
                            .SetPartID = dt.Rows(0).Item("PartID")
                            .SetQuantityInPack = dt.Rows(0).Item("QuantityInPack")
                            .SetComplete = dt.Rows(0).Item("Complete")

                            .SetDeleted = dt.Rows(0).Item("Deleted")
                        End With
                        oPartSupplierPriceRequest.Exists = True
                        Return oPartSupplierPriceRequest
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function [PartSupplierPriceRequest_GetForOrder](ByVal OrderID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@OrderID", OrderID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("PartSupplierPriceRequest_GetForOrder")
                dt.TableName = Entity.Sys.Enums.TableNames.tblPart.ToString
                Return New DataView(dt)
            End Function

            Public Function [PartSupplierPriceRequest_GetAll]() As DataView
                _database.ClearParameter()
                Dim dt As DataTable = _database.ExecuteSP_DataTable("PartSupplierPriceRequest_GetAll")
                dt.TableName = Entity.Sys.Enums.TableNames.tblPartSupplierPriceRequest.ToString
                Return New DataView(dt)
            End Function

            Public Function [Insert](ByVal oPartSupplierPriceRequest As PartSupplierPriceRequest) As PartSupplierPriceRequest
                _database.ClearParameter()
                AddPartSupplierPriceRequestParametersToCommand(oPartSupplierPriceRequest)
                _database.AddParameter("@QuoteID", oPartSupplierPriceRequest.QuoteID, True)
                _database.AddParameter("@OrderID", oPartSupplierPriceRequest.OrderID, True)
                oPartSupplierPriceRequest.SetPartSupplierPriceRequestID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("PartSupplierPriceRequest_Insert"))
                oPartSupplierPriceRequest.Exists = True
                Return oPartSupplierPriceRequest
            End Function

            Public Function [InsertForQuote](ByVal oPartSupplierPriceRequest As PartSupplierPriceRequest) As PartSupplierPriceRequest
                _database.ClearParameter()
                AddPartSupplierPriceRequestParametersToCommand(oPartSupplierPriceRequest)
                _database.AddParameter("@QuoteID", oPartSupplierPriceRequest.QuoteID, True)
                oPartSupplierPriceRequest.SetPartSupplierPriceRequestID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("PartSupplierPriceRequest_InsertForQuote"))
                oPartSupplierPriceRequest.Exists = True
                Return oPartSupplierPriceRequest
            End Function

            Public Function [InsertForOrder](ByVal oPartSupplierPriceRequest As PartSupplierPriceRequest) As PartSupplierPriceRequest
                _database.ClearParameter()
                AddPartSupplierPriceRequestParametersToCommand(oPartSupplierPriceRequest)
                _database.AddParameter("@OrderID", oPartSupplierPriceRequest.OrderID, True)
                oPartSupplierPriceRequest.SetPartSupplierPriceRequestID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("PartSupplierPriceRequest_InsertForOrder"))
                oPartSupplierPriceRequest.Exists = True
                Return oPartSupplierPriceRequest
            End Function

            Public Sub Complete(ByVal PartSupplierPriceRequestID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@PartSupplierPriceRequestID", PartSupplierPriceRequestID, True)

                _database.ExecuteSP_NO_Return("PartSupplierPriceRequest_Complete")
            End Sub



            Private Sub AddPartSupplierPriceRequestParametersToCommand(ByRef oPartSupplierPriceRequest As PartSupplierPriceRequest)
                With _database
                    .AddParameter("@SupplierID", oPartSupplierPriceRequest.SupplierID, True)
                    .AddParameter("@PartID", oPartSupplierPriceRequest.PartID, True)
                    .AddParameter("@QuantityInPack", oPartSupplierPriceRequest.QuantityInPack, True)
                    .AddParameter("@Complete", oPartSupplierPriceRequest.Complete, True)
                End With
            End Sub


#End Region

End Class

End Namespace

End Namespace


