Imports System.Data.SqlClient

Namespace Entity

Namespace ProductSupplierPriceRequests

Public Class ProductSupplierPriceRequestSQL
    Private _database As Sys.Database

    Public Sub New(ByVal database As Sys.Database)
        _database = database
    End Sub

#Region "Functions"

	
    Public Sub Delete(ByVal ProductSupplierPriceRequestID As Integer)
    		_database.ClearParameter()
            _database.AddParameter("@ProductSupplierPriceRequestID", ProductSupplierPriceRequestID, True)
            _database.ExecuteSP_NO_Return("ProductSupplierPriceRequest_Delete")
            End Sub

            Public Sub DeleteForOrder(ByVal OrderID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@OrderID", OrderID, True)
                _database.ExecuteSP_NO_Return("ProductSupplierPriceRequest_DeleteForOrder")
            End Sub

            Public Function [ProductSupplierPriceRequest_Get](ByVal ProductSupplierPriceRequestID As Integer) As ProductSupplierPriceRequest
                _database.ClearParameter()
                _database.AddParameter("@ProductSupplierPriceRequestID", ProductSupplierPriceRequestID)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("ProductSupplierPriceRequest_Get")

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oProductSupplierPriceRequest As New ProductSupplierPriceRequest
                        With oProductSupplierPriceRequest
                            .IgnoreExceptionsOnSetMethods = True
                            .SetProductSupplierPriceRequestID = dt.Rows(0).Item("ProductSupplierPriceRequestID")
                            .SetOrderID = dt.Rows(0).Item("OrderID")
                            .SetQuantityInPack = dt.Rows(0).Item("QuantityInPack")
                            .SetComplete = dt.Rows(0).Item("Complete")
                            .SetProductID = dt.Rows(0).Item("ProductID")
                            .SetSupplierID = dt.Rows(0).Item("SupplierID")

                            .SetDeleted = dt.Rows(0).Item("Deleted")
                        End With
                        oProductSupplierPriceRequest.Exists = True
                        Return oProductSupplierPriceRequest
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function ProductSupplierPriceRequest_GetForOrder(ByVal OrderID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@OrderID", OrderID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("ProductSupplierPriceRequest_GetForOrder")
                dt.TableName = Entity.Sys.Enums.TableNames.tblProduct.ToString
                Return New DataView(dt)
            End Function

            Public Function [ProductSupplierPriceRequest_GetAll]() As DataView
                _database.ClearParameter()
                Dim dt As DataTable = _database.ExecuteSP_DataTable("ProductSupplierPriceRequest_GetAll")
                dt.TableName = Entity.Sys.Enums.TableNames.tblProductSupplierPriceRequest.ToString
                Return New DataView(dt)
            End Function

            Public Function [Insert](ByVal oProductSupplierPriceRequest As ProductSupplierPriceRequest) As ProductSupplierPriceRequest
                _database.ClearParameter()
                AddProductSupplierPriceRequestParametersToCommand(oProductSupplierPriceRequest)
                _database.AddParameter("@QuoteID", oProductSupplierPriceRequest.QuoteID, True)
                _database.AddParameter("@OrderID", oProductSupplierPriceRequest.OrderID, True)
                oProductSupplierPriceRequest.SetProductSupplierPriceRequestID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("ProductSupplierPriceRequest_Insert"))
                oProductSupplierPriceRequest.Exists = True
                Return oProductSupplierPriceRequest
            End Function

            Public Function [InsertForQuote](ByVal oProductSupplierPriceRequest As ProductSupplierPriceRequest) As ProductSupplierPriceRequest
                _database.ClearParameter()
                AddProductSupplierPriceRequestParametersToCommand(oProductSupplierPriceRequest)
                _database.AddParameter("@QuoteID", oProductSupplierPriceRequest.QuoteID, True)
                oProductSupplierPriceRequest.SetProductSupplierPriceRequestID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("ProductSupplierPriceRequest_InsertForQuote"))
                oProductSupplierPriceRequest.Exists = True
                Return oProductSupplierPriceRequest
            End Function

            Public Function [InsertForOrder](ByVal oProductSupplierPriceRequest As ProductSupplierPriceRequest) As ProductSupplierPriceRequest
                _database.ClearParameter()
                AddProductSupplierPriceRequestParametersToCommand(oProductSupplierPriceRequest)
                _database.AddParameter("@OrderID", oProductSupplierPriceRequest.OrderID, True)
                oProductSupplierPriceRequest.SetProductSupplierPriceRequestID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("PartSupplierPriceRequest_InsertForOrder"))
                oProductSupplierPriceRequest.Exists = True
                Return oProductSupplierPriceRequest
            End Function

            Public Sub Complete(ByVal ProductSupplierPriceRequestID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@ProductSupplierPriceRequestID", ProductSupplierPriceRequestID, True)

                _database.ExecuteSP_NO_Return("ProductSupplierPriceRequest_Complete")
            End Sub

            Private Sub AddProductSupplierPriceRequestParametersToCommand(ByRef oProductSupplierPriceRequest As ProductSupplierPriceRequest)
                With _database
                    .AddParameter("@QuantityInPack", oProductSupplierPriceRequest.QuantityInPack, True)
                    .AddParameter("@Complete", oProductSupplierPriceRequest.Complete, True)
                    .AddParameter("@ProductID", oProductSupplierPriceRequest.ProductID, True)
                    .AddParameter("@SupplierID", oProductSupplierPriceRequest.SupplierID, True)
                End With
            End Sub
#End Region

End Class

End Namespace

End Namespace


