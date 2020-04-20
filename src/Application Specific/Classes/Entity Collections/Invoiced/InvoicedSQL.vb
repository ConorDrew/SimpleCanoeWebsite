Imports System.Data.SqlClient
Imports System.Threading.Tasks

Namespace Entity

    Namespace Invoiceds

        Public Class InvoicedSQL
            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

#Region "Functions"

            Public Function [Invoiced_Get](ByVal InvoicedID As Integer) As Invoiced
                _database.ClearParameter()
                _database.AddParameter("@InvoicedID", InvoicedID)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("Invoiced_Get")

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oInvoiced As New Invoiced
                        With oInvoiced
                            .IgnoreExceptionsOnSetMethods = True
                            .SetInvoicedID = dt.Rows(0).Item("InvoicedID")
                            .RaisedDate = dt.Rows(0).Item("RaisedDate")
                            .SetInvoiceNumber = dt.Rows(0).Item("InvoiceNumber")
                            .SetRaisedByUserID = dt.Rows(0).Item("RaisedByUserID")
                            .SetVATRateID = dt.Rows(0).Item("VATRateID")
                            .SetPaidByID = dt.Rows(0).Item("PaidByID")
                            .SetAdhocInvoiceType = dt.Rows(0).Item("AdhocInvoiceType")
                        End With
                        oInvoiced.Exists = True
                        Return oInvoiced
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function [Invoiced_Get_ByInvoiceNumber](ByVal invoiceNumber As Integer) As Invoiced
                _database.ClearParameter()
                _database.AddParameter("@InvoicedNumber", invoiceNumber)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("Invoiced_Get_InvoiceNumber")

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oInvoiced As New Invoiced
                        With oInvoiced
                            .IgnoreExceptionsOnSetMethods = True
                            .SetInvoicedID = dt.Rows(0).Item("InvoicedID")
                            .RaisedDate = dt.Rows(0).Item("RaisedDate")
                            .SetInvoiceNumber = dt.Rows(0).Item("InvoiceNumber")
                            .SetRaisedByUserID = dt.Rows(0).Item("RaisedByUserID")
                            .SetVATRateID = dt.Rows(0).Item("VATRateID")
                            .SetPaidByID = dt.Rows(0).Item("PaidByID")
                            .SetAdhocInvoiceType = dt.Rows(0).Item("AdhocInvoiceType")
                        End With
                        oInvoiced.Exists = True
                        Return oInvoiced
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function [Invoiced_GetAll_Manager](
                ByVal RaisedFrom As DateTime, ByVal RaisedTo As DateTime, ByVal customerId As Integer,
                ByVal siteId As Integer, ByVal postcode As String, ByVal invoiceTypeId As Integer,
                ByVal jobNumber As String, ByVal invoiceNumber As String, ByVal userId As Integer,
                ByVal regionId As Integer, ByVal department As String, ByVal exportedToSage As Integer) As DataView

                _database.ClearParameter()
                _database.AddParameter("@RaisedFrom", CDate(Format(RaisedFrom, "dd/MM/yyyy") & " 00:00:00"), True)
                _database.AddParameter("@RaisedTo", CDate(Format(RaisedTo, "dd/MM/yyyy") & " 23:59:59"), True)
                _database.AddParameter("@InvoiceEnumVal", CInt(Entity.Sys.Enums.InvoiceAddressType.Invoice), True)
                _database.AddParameter("@JobInvTypeEnum", CInt(Entity.Sys.Enums.InvoiceType.Visit), True)
                _database.AddParameter("@OrderInvTypeEnum", CInt(Entity.Sys.Enums.InvoiceType.Order), True)
                _database.AddParameter("@Contract_Option1Enum", CInt(Entity.Sys.Enums.InvoiceType.Contract_Option1), True)
                _database.AddParameter("@Contract_Option2Enum", CInt(Entity.Sys.Enums.InvoiceType.Contract_Option2), True)
                _database.AddParameter("@Contract_Option3Enum", CInt(Entity.Sys.Enums.InvoiceType.Contract_Option3), True)
                _database.AddParameter("@CustomerId", customerId, True)
                _database.AddParameter("@SiteId", siteId, True)
                _database.AddParameter("@Postcode", postcode, True)
                _database.AddParameter("@InvoiceTypeID", invoiceTypeId, True)
                _database.AddParameter("@JobNumber", jobNumber, True)
                _database.AddParameter("@InvoiceNumber", invoiceNumber, True)
                _database.AddParameter("@UserId", userId, True)
                _database.AddParameter("@RegionId", regionId, True)
                _database.AddParameter("@Department", department, True)
                _database.AddParameter("@ExportedToSage", exportedToSage, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("Invoiced_GetAll_Manager5")
                dt.TableName = Entity.Sys.Enums.TableNames.tblInvoiced.ToString
                Return New DataView(dt)
            End Function

            Public Function [Insert](ByVal oInvoiced As Invoiced) As Invoiced
                _database.ClearParameter()
                AddInvoicedParametersToCommand(oInvoiced)

                oInvoiced.SetInvoicedID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("Invoiced_Insert"))
                oInvoiced.Exists = True
                Return oInvoiced
            End Function

            Public Sub [Update](ByVal oInvoiced As Invoiced)
                _database.ClearParameter()
                _database.AddParameter("@InvoicedID", oInvoiced.InvoicedID, True)
                AddInvoicedParametersToCommand(oInvoiced)
                _database.ExecuteSP_NO_Return("Invoiced_Update")
            End Sub

            Private Sub AddInvoicedParametersToCommand(ByRef oInvoiced As Invoiced)
                With _database
                    .AddParameter("@InvoiceNumber", oInvoiced.InvoiceNumber, True)
                    .AddParameter("@RaisedDate", oInvoiced.RaisedDate, True)
                    .AddParameter("@RaisedByUserID", oInvoiced.RaisedByUserID, True)
                    .AddParameter("@VATRateID", oInvoiced.VATRateID, True)
                    .AddParameter("@PaymentTermID", oInvoiced.PaymentTermID, True)
                    .AddParameter("@PaidByID", oInvoiced.PaidByID, True)
                    .AddParameter("@AdhocInvoicetype", oInvoiced.AdhocInvoiceType, True)
                End With
            End Sub

            Public Function [InvoiceDetails_Get_InvoicedID](ByVal InvoicedID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@InvoiceEnumVal", CInt(Entity.Sys.Enums.InvoiceAddressType.Invoice), True)
                _database.AddParameter("@JobInvTypeEnum", CInt(Entity.Sys.Enums.InvoiceType.Visit), True)
                _database.AddParameter("@OrderInvTypeEnum", CInt(Entity.Sys.Enums.InvoiceType.Order), True)
                _database.AddParameter("@Contract_Option1Enum", CInt(Entity.Sys.Enums.InvoiceType.Contract_Option1), True)
                _database.AddParameter("@Contract_Option2Enum", CInt(Entity.Sys.Enums.InvoiceType.Contract_Option2), True)
                _database.AddParameter("@Contract_Option3Enum", CInt(Entity.Sys.Enums.InvoiceType.Contract_Option3), True)

                _database.AddParameter("@InvoicedID", InvoicedID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("InvoiceDetails_Get_InvoicedID")

                dt.TableName = Entity.Sys.Enums.TableNames.tblInvoiced.ToString
                Return New DataView(dt)

            End Function

            Public Function [InvoiceDetails_Get_InvoiceToBeRaisedID](ByVal InvoicedID As Integer) As DataView
                _database.ClearParameter()

                _database.AddParameter("@InvoiceToBeRaisedID", InvoicedID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("InvoiceDetails_Get_InvoiceToBeRaisedID")

                dt.TableName = Entity.Sys.Enums.TableNames.tblInvoiced.ToString
                Return New DataView(dt)

            End Function

            Public Function [InvoiceDetails_Get_InvoicedNumber](ByVal InvoicedID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@InvoiceEnumVal", CInt(Entity.Sys.Enums.InvoiceAddressType.Invoice), True)
                _database.AddParameter("@JobInvTypeEnum", CInt(Entity.Sys.Enums.InvoiceType.Visit), True)
                _database.AddParameter("@OrderInvTypeEnum", CInt(Entity.Sys.Enums.InvoiceType.Order), True)
                _database.AddParameter("@Contract_Option1Enum", CInt(Entity.Sys.Enums.InvoiceType.Contract_Option1), True)
                _database.AddParameter("@Contract_Option2Enum", CInt(Entity.Sys.Enums.InvoiceType.Contract_Option2), True)
                _database.AddParameter("@Contract_Option3Enum", CInt(Entity.Sys.Enums.InvoiceType.Contract_Option3), True)

                _database.AddParameter("@InvoicedNumber", InvoicedID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("InvoiceDetails_Get_InvoicedNumber")

                dt.TableName = Entity.Sys.Enums.TableNames.tblInvoiced.ToString
                Return New DataView(dt)

            End Function

            Public Function Invoiced_GetContractOpt3_Jobs(ByVal InvoicedID As Integer, ByVal ContractSiteID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@ContractOpt3Enum", CInt(Entity.Sys.Enums.InvoiceType.Contract_Option3), True)
                _database.AddParameter("@InvoicedID", InvoicedID, True)
                _database.AddParameter("@ContractSiteID", ContractSiteID, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("Invoiced_GetContractOpt3_Jobs")

                dt.TableName = Entity.Sys.Enums.TableNames.tblInvoiced.ToString
                Return New DataView(dt)
            End Function

            Public Function Invoice_GetAdditionalNotes(ByVal InvoicedID As Integer) As String
                _database.ClearParameter()
                _database.AddParameter("@InvoicedID", InvoicedID, True)
                Return Entity.Sys.Helper.MakeStringValid(_database.ExecuteSP_OBJECT("Invoiced_GetNotes"))
            End Function

            Public Sub Invoice_UpdateAdditionalNotes(ByVal InvoicedID As Integer, ByVal Notes As String)
                _database.ClearParameter()
                _database.AddParameter("@InvoicedID", InvoicedID, True)
                _database.AddParameter("@Notes", Notes, True)
                _database.ExecuteSP_NO_Return("Invoiced_UpdateNotes")
            End Sub

            Public Function NCCValuation(ByVal InvoicedID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@InvoicedID", InvoicedID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("InvoicedManager_Get_NccVal")

                dt.TableName = Entity.Sys.Enums.TableNames.tblInvoicedPaymentApplications.ToString
                Return New DataView(dt)

            End Function

#End Region

#Region "Invoice Export"

            Public Function GetJobNominalCode_ForSupplierInvoice(ByVal OrderID As Integer) As DataTable

                _database.ClearParameter()
                _database.AddParameter("@OrderID", OrderID, True)
                Dim Results As DataTable = _database.ExecuteSP_DataTable("Invoiced_GetJobNominalCode_ForSupplierInvoice")
                Return Results

            End Function

#Region "Exported"

            Public Async Function MarkInvoiceAsExportedAsync(ByVal invoicedId As Integer) As Task
                Dim sqlParams As SqlParameter() = {New SqlParameter("@InvoicedID", invoicedId)}
                Await _database.ExecuteAsync("Invoiced_Update_AsExported", sqlParams)
            End Function

            Public Async Function MarkConsolidatedOrderAsExportedAsync(ByVal orderConsolidationId As Integer) As Task
                Dim sqlParams As SqlParameter() = {New SqlParameter("@OrderConsolidationID", orderConsolidationId)}
                Await _database.ExecuteAsync("OrderConsolidation_Update_AsExported", sqlParams)
            End Function

            Public Async Function MarkOrderAsExportedAsync(ByVal supplierInvoiceId As Integer) As Task
                Dim sqlParams As SqlParameter() = {New SqlParameter("@SupplierInvoiceID", supplierInvoiceId)}
                Await _database.ExecuteAsync("OrderSupplierInvoices_Update_AsExported", sqlParams)
            End Function

            Public Async Function MarkPartCreditedAsExportedAsync(ByVal partCreditsId As Integer, ByVal partsToBeCreditedId As Integer) As Task
                Dim sqlParams As SqlParameter() = {New SqlParameter("@PartsToBeCreditedID", partsToBeCreditedId), New SqlParameter("@PartCreditsID", partCreditsId)}
                Await _database.ExecuteAsync("PartCredits_Update_AsExported", sqlParams)
            End Function

            Public Async Function MarkSalesCreditAsExportedAsync(ByVal salesCreditId As Integer) As Task
                Dim sqlParams As SqlParameter() = {New SqlParameter("@SalesCreditID", salesCreditId)}
                Await _database.ExecuteAsync("SalesCredit_Update_AsExported", sqlParams)
            End Function

#End Region

#Region "Not Exported"

            Public Async Function MarkInvoiceAsNotExportedAsync(ByVal invoicedId As Integer) As Task
                Dim sqlParams As SqlParameter() = {New SqlParameter("@InvoicedID", invoicedId)}
                Await _database.ExecuteAsync("Invoiced_Update_AsNotExported", sqlParams)
            End Function

            Public Async Function MarkOrderAsNotExportedAsync(ByVal supplierInvoiceId As Integer) As Task
                Dim sqlParams As SqlParameter() = {New SqlParameter("@SupplierInvoiceID", supplierInvoiceId)}
                Await _database.ExecuteAsync("OrderSupplierInvoices_Update_AsNotExported", sqlParams)
            End Function

            Public Async Function MarkConsolidatedOrderAsNotExportedAsync(ByVal orderConsolidationId As Integer) As Task
                Dim sqlParams As SqlParameter() = {New SqlParameter("@OrderConsolidationID", orderConsolidationId)}
                Await _database.ExecuteAsync("OrderConsolidation_Update_AsNotExported", sqlParams)
            End Function

            Public Async Function MarkPartCreditedAsNotExportedAsync(ByVal partCreditsId As Integer, ByVal partsToBeCreditedId As Integer) As Task
                Dim sqlParams As SqlParameter() = {New SqlParameter("@PartsToBeCreditedID", partsToBeCreditedId), New SqlParameter("@PartCreditsID", partCreditsId)}
                Await _database.ExecuteAsync("PartCredits_Update_AsNotExported", sqlParams)
            End Function

            Public Async Function MarkSalesCreditAsNotExportedAsync(ByVal salesCreditId As Integer) As Task
                Dim sqlParams As SqlParameter() = {New SqlParameter("@SalesCreditID", salesCreditId)}
                Await _database.ExecuteAsync("SalesCredit_Update_AsNotExported", sqlParams)
            End Function

#End Region

#End Region

        End Class

    End Namespace

End Namespace