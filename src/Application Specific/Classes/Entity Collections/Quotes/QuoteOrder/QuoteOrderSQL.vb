Imports System.Data.SqlClient

Namespace Entity

Namespace QuoteOrders

Public Class QuoteOrderSQL
    Private _database As Sys.Database

    Public Sub New(ByVal database As Sys.Database)
        _database = database
    End Sub

#Region "Functions"

	
    Public Sub Delete(ByVal QuoteOrderID As Integer)
    		_database.ClearParameter()
            _database.AddParameter("@QuoteOrderID", QuoteOrderID, True)
            _database.ExecuteSP_NO_Return("QuoteOrder_Delete")
            End Sub

            Public Sub QuoteOrderProductsToInclude_Insert(ByVal QuoteOrderID As Integer, ByVal ProductSupplierID As Integer, ByVal SellPrice As Double)
                _database.ClearParameter()
                _database.AddParameter("@QuoteOrderID", QuoteOrderID, True)
                _database.AddParameter("@ProductSupplierID", ProductSupplierID, True)
                _database.AddParameter("@SellPrice", SellPrice, True)
                _database.ExecuteSP_NO_Return("QuoteOrderProductsToInclude_Insert")
            End Sub

            Public Sub QuoteOrderPartsToInclude_Insert(ByVal QuoteOrderID As Integer, ByVal PartSupplierID As Integer, ByVal SellPrice As Double)
                _database.ClearParameter()
                _database.AddParameter("@QuoteOrderID", QuoteOrderID, True)
                _database.AddParameter("@PartSupplierID", PartSupplierID, True)
                _database.AddParameter("@SellPrice", SellPrice, True)
                _database.ExecuteSP_NO_Return("QuoteOrderPartsToInclude_Insert")
            End Sub

            Public Sub QuoteOrder_DeleteItemsIncluded(ByVal QuoteOrderID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@QuoteOrderID", QuoteOrderID, True)
                _database.ExecuteSP_NO_Return("QuoteOrder_DeleteItemsIncluded")
            End Sub

            Public Function [QuoteOrder_Get](ByVal QuoteOrderID As Integer) As QuoteOrder
                _database.ClearParameter()
                _database.AddParameter("@QuoteOrderID", QuoteOrderID)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("QuoteOrder_Get")

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oQuoteOrder As New QuoteOrder
                        With oQuoteOrder
                            .IgnoreExceptionsOnSetMethods = True
                            .SetQuoteOrderID = dt.Rows(0).Item("QuoteOrderID")
                            .SetCustomerID = dt.Rows(0).Item("CustomerID")
                            .SetPropertyID = dt.Rows(0).Item("SiteID")
                            .SetWarehouseID = dt.Rows(0).Item("WarehouseID")
                            .SetContactID = dt.Rows(0).Item("ContactID")
                            .SetInvoiceAddressID = dt.Rows(0).Item("InvoiceAddressID")
                            .SetCustomerRef = dt.Rows(0).Item("CustomerRef")

                            If IsDBNull(dt.Rows(0).Item("DeliveryDeadline")) Then
                                .DeliveryDeadline = Nothing
                            Else
                                .DeliveryDeadline = CDate(dt.Rows(0).Item("DeliveryDeadline"))
                            End If

                            .SetSpecialInstructions = dt.Rows(0).Item("SpecialInstructions")
                            .SetCreatedByUser = dt.Rows(0).Item("CreatedByUser")
                            .SetAllocatedToUser = dt.Rows(0).Item("AllocatedToUser")
                            .EnquiryDate = dt.Rows(0).Item("EnquiryDate")
                            .ValidUntilDate = dt.Rows(0).Item("ValidUntilDate")
                            .SetAvailability = dt.Rows(0).Item("Availability")
                            .SetPriceDetails = dt.Rows(0).Item("PriceDetails")
                            .SetPriceExcludeDetails = dt.Rows(0).Item("PriceExcludeDetails")
                            .SetDeleted = dt.Rows(0).Item("Deleted")
                            .SetQuoteStatusID = dt.Rows(0).Item("StatusID")
                            .SetReasonForReject = dt.Rows(0).Item("ReasonForReject")
                        End With
                        oQuoteOrder.Exists = True
                        Return oQuoteOrder
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function [QuoteOrder_GetAll]() As DataView
                _database.ClearParameter()
                Dim dt As DataTable = _database.ExecuteSP_DataTable("QuoteOrder_GetAll")
                dt.TableName = Entity.Sys.Enums.TableNames.tblQuoteOrder.ToString
                Return New DataView(dt)
            End Function

            Public Function [Insert](ByVal oQuoteOrder As QuoteOrder) As QuoteOrder
                _database.ClearParameter()
                AddQuoteOrderParametersToCommand(oQuoteOrder)

                oQuoteOrder.SetQuoteOrderID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("QuoteOrder_Insert"))
                oQuoteOrder.Exists = True
                Return oQuoteOrder
            End Function


            Public Sub [Update](ByVal oQuoteOrder As QuoteOrder)
                _database.ClearParameter()
                _database.AddParameter("@QuoteOrderID", oQuoteOrder.QuoteOrderID, True)
                AddQuoteOrderParametersToCommand(oQuoteOrder)
                _database.ExecuteSP_NO_Return("QuoteOrder_Update")
            End Sub

            Public Function Quote_PriceRequests_GetAll(ByVal QuoteID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@QuoteID", QuoteID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("Quote_PriceRequests_GetAll")
                dt.TableName = Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_PriceRequests.ToString
                Return New DataView(dt)
            End Function

            Public Function Quote_PriceRequests_GetConfirmed(ByVal QuoteID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@QuoteID", QuoteID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("Quote_PriceRequests_GetConfirmed")
                dt.TableName = Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_PriceRequests.ToString

                For Each row As DataRow In dt.Rows
                    If IsDBNull(row.Item("Included")) Then
                        row.Item("Included") = 0
                    End If
                Next
                Return New DataView(dt)
            End Function

            Private Sub AddQuoteOrderParametersToCommand(ByRef oQuoteOrder As QuoteOrder)
                With _database
                    .AddParameter("@CustomerID", oQuoteOrder.CustomerID, True)
                    .AddParameter("@SiteID", oQuoteOrder.PropertyID, True)
                    .AddParameter("@WarehouseID", oQuoteOrder.WarehouseID, True)
                    .AddParameter("@ContactID", oQuoteOrder.ContactID, True)
                    .AddParameter("@InvoiceAddressID", oQuoteOrder.InvoiceAddressID, True)
                    .AddParameter("@CustomerRef", oQuoteOrder.CustomerRef, True)
                    .AddParameter("@SpecialInstructions", oQuoteOrder.SpecialInstructions, True)
                    .AddParameter("@CreatedByUser", oQuoteOrder.CreatedByUser, True)
                    .AddParameter("@AllocatedToUser", oQuoteOrder.AllocatedToUser, True)
                    .AddParameter("@EnquiryDate", oQuoteOrder.EnquiryDate, True)
                    .AddParameter("@ValidUntilDate", oQuoteOrder.ValidUntilDate, True)
                    If oQuoteOrder.DeliveryDeadline = Nothing Then
                        .AddParameter("@DeliveryDeadline", DBNull.Value, True)
                    Else
                        .AddParameter("@DeliveryDeadline", oQuoteOrder.DeliveryDeadline, True)
                    End If
                    .AddParameter("@Availability", oQuoteOrder.Availability, True)
                    .AddParameter("@PriceDetails", oQuoteOrder.PriceDetails, True)
                    .AddParameter("@PriceExcludeDetails", oQuoteOrder.PriceExcludeDetails, True)
                    .AddParameter("@StatusID", oQuoteOrder.QuoteStatusID, True)
                    .AddParameter("@ReasonForReject", oQuoteOrder.ReasonForReject, True)
                End With
            End Sub
#End Region

End Class

End Namespace

End Namespace


