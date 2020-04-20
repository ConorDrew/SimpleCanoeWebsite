Imports System.Data.SqlClient

Namespace Importer.Validation

    Public Class ValidationSQL
        Private _database As Entity.Sys.Database

        Public Sub New(ByVal database As Entity.Sys.Database)
            _database = database
        End Sub

        Public Function CategoryExists(ByVal Category As String) As Boolean
            If DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.PartCategories).Table.Select("Name = '" & Category & "'").Length = 0 And DB.Picklists.GetAllPartMappings(Entity.Sys.Enums.PickListTypes.PartCategories).Table.Select("PartMapMatch = '" & Category & "'").Length = 0 Then
                Return False
            Else
                Return True
            End If
        End Function

        Public Function CategoryID(ByVal Category As String, ByVal trans As SqlClient.SqlTransaction) As Integer
            Dim Command As SqlClient.SqlCommand = New SqlClient.SqlCommand

            Command.CommandText = Entity.Sys.Helper.GetTextResource("Picklists_Get_PartMapping.sql").Replace("?EnumTypeID", CInt(Entity.Sys.Enums.PickListTypes.PartCategories))
            Command.CommandType = CommandType.Text
            Command.Transaction = trans
            Command.Connection = trans.Connection

            Dim Adapter As New SqlClient.SqlDataAdapter(Command)
            Dim returnDS As New DataSet
            Adapter.Fill(returnDS)

            If DB.Picklists.GetAllPartMappings(Entity.Sys.Enums.PickListTypes.PartCategories).Table.Select("PartMapMatch = '" & Category & "'").Length = 0 Then
                Return returnDS.Tables(0).Select("Name = '" & Category & "'")(0).Item("ManagerID")
            Else
                Return returnDS.Tables(0).Select("PartMapMatch = '" & Category & "'")(0).Item("ManagerID")
            End If
        End Function

        Public Function Parts_PreImportData(ByVal SupplierID As Integer, ByVal PartCode As String, ByVal Description As String, ByVal Category As String, ByVal SupplierPartCode As String, ByVal SupplierPrice As Double) As Integer
            _database.ClearParameter()
            _database.AddParameter("@SupplierID", SupplierID, True)
            _database.AddParameter("@PartCode", PartCode, True)
            _database.AddParameter("@Description", Description, True)
            _database.AddParameter("@Category", Category, True)
            _database.AddParameter("@SupplierPartCode", SupplierPartCode, True)
            _database.AddParameter("@SupplierPrice", SupplierPrice, True)

            _database.ExecuteSP_NO_Return("Part_PreImportInsert")

            Return _database.ExecuteScalar("SELECT COUNT(*) FROM tblPartsPreImport", False)
        End Function

        Public Function Parts_GetPreImportData(Optional ByVal ValidateType As Integer = 0) As DataView
            _database.ClearParameter()
            _database.AddParameter("@ValidateType", ValidateType, True)

            Dim dt As DataTable = _database.ExecuteSP_DataTable("Parts_GetPreImport")
            dt.TableName = "Parts_GetPreImport"
            Return New DataView(dt)
        End Function

        Public Sub Parts_ValidatePreImportData(Optional ByVal ValidateType As Integer = 0, Optional ByVal pfh As Boolean = False)
            _database.ClearParameter()
            _database.AddParameter("@ValidateType", ValidateType, True)
            _database.AddParameter("@PFH", pfh, True)

            _database.ExecuteSP_NO_Return("Parts_PreImportValidate_Mk2")
        End Sub

        Public Sub Parts_PreImportNoChangeRemove(ByVal PrimaryPrice As Boolean)
            _database.ClearParameter()
            _database.AddParameter("@UserID", loggedInUser.UserID, True)
            _database.AddParameter("@PrimaryPrice", PrimaryPrice, True)
            _database.ExecuteSP_NO_Return("Parts_PreImportNoChange")

        End Sub

        Public Sub Parts_ImportApplyPriceChange(ByVal ValidateType As Integer)
            _database.ClearParameter()
            _database.AddParameter("@ValidateType", ValidateType, True)
            _database.AddParameter("@UserID", loggedInUser.UserID, True)

            _database.ExecuteSP_NO_Return("Parts_PreImportApplyPrices")
        End Sub

        Public Sub Parts_ImportAddPartSuppliers(Optional ByVal ValidateType As Integer = 0)
            _database.ClearParameter()
            _database.AddParameter("@UserID", loggedInUser.UserID, True)

            _database.ExecuteSP_NO_Return("Parts_PreImportSupplierPart")
        End Sub

        Public Sub Parts_ImportAddParts(Optional ByVal ValidateType As Integer = 0)
            _database.ClearParameter()
            _database.AddParameter("@UserID", loggedInUser.UserID, True)

            _database.ExecuteSP_NO_Return("Parts_PreImportAddNewPart")
        End Sub

        Public Function Parts_CheckPreImportCount() As Integer
            _database.ClearParameter()

            Return _database.ExecuteScalar("SELECT COUNT(*) FROM tblPartsPreImport", False)
        End Function

        Public Function Parts_ClearPreImport() As Integer
            _database.ClearParameter()

            Return _database.ExecuteScalar("DELETE FROM tblPartsPreImport")
        End Function

        Public Sub Parts_PreImportChange(ByVal ImportID As Integer, ByVal Exclude As Boolean, ByVal ForceInsert As Boolean, ByVal ImportPrice As Double, ByVal ImportDescription As String, ByVal SwapSPN As Boolean, ByVal Category As String)
            _database.ClearParameter()
            _database.AddParameter("@ImportID", ImportID, True)
            _database.AddParameter("@Exclude", Exclude, True)
            _database.AddParameter("@ForceInsert", ForceInsert, True)
            _database.AddParameter("@ImportPrice", ImportPrice, True)
            _database.AddParameter("@ImportDesc", ImportDescription, True)
            _database.AddParameter("@SwapSPN", SwapSPN, True)
            _database.AddParameter("@Category", Category, True)

            _database.ExecuteSP_NO_Return("Parts_PreImportChange")
        End Sub

        Public Sub Parts_UpdatePart(ByVal ImportID As Integer, ByVal ImportDescription As String, ByVal ExistingSPC As String)
            _database.ClearParameter()
            _database.AddParameter("@ImportID", ImportID, True)
            _database.AddParameter("@ImportDesc", ImportDescription, True)
            _database.AddParameter("@NewExistingSPC", ExistingSPC, True)
            _database.AddParameter("@UserID", loggedInUser.UserID, True)

            _database.ExecuteSP_NO_Return("Parts_PreImportUpdatePart")
        End Sub

        Public Function Parts_PreImportStats() As DataTable
            _database.ClearParameter()

            Dim dt As DataTable = _database.ExecuteSP_DataTable("Parts_PreImportStats")
            dt.TableName = "Parts_PreImportStats"
            Return dt
        End Function

        Public Sub POInvoice_ClearImportTables()
            _database.ClearParameter()
            _database.ExecuteSP_NO_Return("POInvoiceImport_ClearImportTables")
        End Sub

        Public Sub POInvoiceImport_ClearRecordFromImportTables(ByVal PurchaseOrderNo As String, ByVal InvoiceNo As String)
            _database.ClearParameter()
            _database.AddParameter("@PurchaseOrderNo", PurchaseOrderNo, True)
            _database.AddParameter("@InvoiceNo", InvoiceNo, True)
            _database.ExecuteSP_NO_Return("POInvoiceImport_ClearRecordFromImportTables")
        End Sub

        Public Function POInvoiceImport_InsertOrder(ByVal InvoiceNo As String, ByVal InvoiceDate As Date,
                                                    ByVal PurchaseOrderNo As String, ByVal SupplierID As Integer,
                                                    ByVal OrderType As String, Optional ByVal nominalCode As String = Nothing) As Integer

            _database.ClearParameter()
            _database.AddParameter("@InvoiceNo", InvoiceNo, True)
            _database.AddParameter("@InvoiceDate", InvoiceDate, True)
            _database.AddParameter("@PurchaseOrderNo", PurchaseOrderNo, True)
            _database.AddParameter("@SupplierID", SupplierID, True)
            _database.AddParameter("@NoOfParts", 0, True)
            _database.AddParameter("@TotalUnitPrice", 0, True)
            _database.AddParameter("@TotalNetAmount", 0, True)
            _database.AddParameter("@TotalVATAmount", 0, True)
            _database.AddParameter("@TotalGrossAmount", 0, True)
            _database.AddParameter("@OrderType", OrderType, True)
            _database.AddParameter("@NominalCode", nominalCode, True)

            Return CInt(_database.ExecuteSP_OBJECT("POInvoiceImport_InsertOrder"))
        End Function

        Public Sub POInvoiceImport_InsertPart(ByVal PurchaseOrderNo As String, ByVal SupplierPartCode As String, ByVal Description As String, ByVal Quantity As Integer, ByVal UnitPrice As Double, ByVal NetAmount As Double, ByVal VATAmount As Double, ByVal GrossAmount As Double, ByVal InvoiceNo As String)
            _database.ClearParameter()
            _database.AddParameter("@PurchaseOrderNo", PurchaseOrderNo, True)
            _database.AddParameter("@SupplierPartCode", SupplierPartCode, True)
            _database.AddParameter("@Description", Description, True)
            _database.AddParameter("@Quantity", Quantity, True)
            _database.AddParameter("@UnitPrice", UnitPrice, True)
            _database.AddParameter("@NetAmount", NetAmount, True)
            _database.AddParameter("@VATAmount", VATAmount, True)
            _database.AddParameter("@GrossAmount", GrossAmount, True)
            _database.AddParameter("@InvoiceNo", InvoiceNo, True)

            _database.ExecuteSP_NO_Return("POInvoiceImport_InsertPart")
        End Sub

        Public Function Orders_GetID(ByVal poNumber As String, ByVal supplierId As String, ByVal invoiceNumber As String) As Integer
            _database.ClearParameter()
            _database.AddParameter("@PurchaseOrderNo", poNumber, True)
            _database.AddParameter("@SupplierID", supplierId, True)
            _database.AddParameter("@InvoiceNo", invoiceNumber, True)

            Return Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("POInvoiceImport_Orders_GetID"))
        End Function

        Public Sub POInvoiceImport_UpdateOrderTotals(ByVal PurchaseOrderNo As String, ByVal NoOfParts As Integer, ByVal TotalUnitPrice As Double, ByVal TotalNetAmount As Double, ByVal TotalVATAmount As Double, ByVal TotalGrossAmount As Double, ByVal TotalQtyOfParts As Integer, ByVal InvoiceNo As String)
            _database.ClearParameter()
            _database.AddParameter("@PurchaseOrderNo", PurchaseOrderNo, True)
            _database.AddParameter("@NoOfParts", NoOfParts, True)
            _database.AddParameter("@TotalUnitPrice", TotalUnitPrice, True)
            _database.AddParameter("@TotalNetAmount", TotalNetAmount, True)
            _database.AddParameter("@TotalVATAmount", TotalVATAmount, True)
            _database.AddParameter("@TotalGrossAmount", TotalGrossAmount, True)
            _database.AddParameter("@TotalQtyOfParts", TotalQtyOfParts, True)
            _database.AddParameter("@InvoiceNo", InvoiceNo, True)

            _database.ExecuteSP_NO_Return("POInvoiceImport_UpdateOrderTotals")
        End Sub

        Public Sub POInvoiceImport_ValidateOrders(Optional ByVal ValidateType As Integer = 0)
            _database.ClearParameter()
            _database.AddParameter("@ValidateType", ValidateType, True)

            _database.ExecuteSP_NO_Return("POInvoiceImport_ValidateOrders_Test")
        End Sub

        Public Sub POInvoiceImport_UpdatePurchaseOrderNoAndValidate(ByVal ImportID As Integer, ByVal PurchaseOrderNo As String)
            _database.ClearParameter()
            _database.AddParameter("@ID", ImportID, True)
            _database.AddParameter("@PurchaseOrderNo", PurchaseOrderNo, True)

            _database.ExecuteSP_NO_Return("POInvoiceImport_UpdatePurchaseOrderNoAndValidate")
        End Sub

        Public Function POInvoiceImport_ValidateOrder(ByVal ImportID As Integer) As Boolean
            _database.ClearParameter()
            _database.AddParameter("@ID", ImportID, True)

            Dim rows As Integer = _database.ExecuteSP_ReturnRowsAffected("POInvoiceImport_ValidateOrder_Mk1")
            Dim result As Boolean = False
            If rows = 1 Then result = True

            Return result
        End Function

        Public Function POInvoiceImport_ShowData(Optional ByVal ValidateResult As Integer = 0) As DataView
            _database.ClearParameter()
            _database.AddParameter("@ValidateResult", ValidateResult, True)

            Dim dt As DataTable = _database.ExecuteSP_DataTable("POInvoiceImport_ShowData")
            dt.TableName = "POInvoiceImport_ShowData"
            Return New DataView(dt)
        End Function

        Public Function POInvoiceImport_ShowData_Mk1() As DataView
            _database.ClearParameter()

            Dim dt As DataTable = _database.ExecuteSP_DataTable("POInvoiceImport_ShowData_Mk1")
            dt.TableName = "POInvoiceImport_ShowData"
            Return New DataView(dt)
        End Function

        Public Function POInvoiceImport_GetOrdersWithNoParts(ByVal ValidateResult As Integer) As DataView
            _database.ClearParameter()
            _database.AddParameter("@ValidateResult", ValidateResult, True)

            Dim dt As DataTable = _database.ExecuteSP_DataTable("POInvoiceImport_GetOrdersWithNoParts")
            dt.TableName = "POInvoiceImport_GetOrdersWithNoParts"
            Return New DataView(dt)
        End Function

        Public Sub POInvoiceImport_UpdateExclude(ByVal ID As Integer, ByVal Exclude As Boolean)
            _database.ClearParameter()
            _database.AddParameter("@ID", ID, True)
            _database.AddParameter("@Exclude", Exclude, True)

            _database.ExecuteSP_NO_Return("POInvoiceImport_UpdateExclude")
        End Sub

        Public Sub POInvoiceImport_UpdateRequiresAuthorisation(ByVal ID As Integer, ByVal RequiresAuth As Boolean)
            _database.ClearParameter()
            _database.AddParameter("@ID", ID, True)
            _database.AddParameter("@RequiresAuth", RequiresAuth, True)

            _database.ExecuteSP_NO_Return("POInvoiceImport_UpdateRequiresAuthorisation")
        End Sub

        Public Sub Order_UpdateSupplier(ByVal OrderID As Integer, ByVal SupplierID As Integer)
            _database.ClearParameter()
            _database.AddParameter("@OrderID", OrderID, True)
            _database.AddParameter("@SupplierID", SupplierID, True)

            _database.ExecuteSP_NO_Return("Order_UpdateSupplier")
        End Sub

        Public Sub POInvoiceImport_UpdateSupplierInvoiceCreated(ByVal ID As Integer, ByVal InvoiceCreated As Boolean)
            _database.ClearParameter()
            _database.AddParameter("@ID", ID, True)
            _database.AddParameter("@SupplierInvoiceCreated", InvoiceCreated, True)

            _database.ExecuteSP_NO_Return("POInvoiceImport_UpdateSupplierInvoiceCreated")
        End Sub

        Public Sub POInvoiceImport_UpdateDelete(ByVal ID As Integer, ByVal ToBeDeleted As Boolean)
            _database.ClearParameter()
            _database.AddParameter("@ID", ID, True)
            _database.AddParameter("@ToBeDeleted", ToBeDeleted, True)

            _database.ExecuteSP_NO_Return("POInvoiceImport_UpdateDelete")
        End Sub

        Public Function POInvoiceImport_ShowPOParts(ByVal PurchaseOrderNo As String, ByVal InvoiceNo As String) As DataView
            _database.ClearParameter()
            _database.AddParameter("@PurchaseOrderNo", PurchaseOrderNo, True)
            _database.AddParameter("@InvoiceNo", InvoiceNo, True)

            Dim dt As DataTable = _database.ExecuteSP_DataTable("POInvoiceImport_ShowPOParts")
            dt.TableName = "POInvoiceImport_Parts"
            Return New DataView(dt)
        End Function

        Public Function POInvoiceImport_GetPOParts(ByVal PurchaseOrderNo As String, ByVal InvoiceNo As String) As DataView
            _database.ClearParameter()
            _database.AddParameter("@PurchaseOrderNo", PurchaseOrderNo, True)
            _database.AddParameter("@InvoiceNo", InvoiceNo, True)

            Dim dt As DataTable = _database.ExecuteSP_DataTable("POInvoiceImport_ShowPOParts")
            dt.TableName = "POInvoiceImport_Parts"
            Return New DataView(dt)
        End Function

        Public Sub POInvoiceImport_AddSupplierInvoiceDetailToPO(ByVal PurchaseOrderNo As String)
            _database.ClearParameter()
            _database.AddParameter("@PurchaseOrderNo", PurchaseOrderNo, True)
            _database.ExecuteSP_NO_Return("Parts_PreImportValidate")
        End Sub

        Public Sub POInvoiceImport_UpdateValidationType(ByVal ID As Integer, Optional ByVal ValidateResult As Integer = 0)
            _database.ClearParameter()
            _database.AddParameter("@ID", ID, True)
            _database.AddParameter("@ValidateResult", ValidateResult, True)

            _database.ExecuteSP_NO_Return("POInvoiceImport_UpdateValidateResult")
        End Sub

        Public Sub POInvoiceImport_UpdateFailedPart(ByVal ID As Integer, ByVal Failed As Boolean)
            _database.ClearParameter()
            _database.AddParameter("@ID", ID, True)
            _database.AddParameter("@Failed", Failed, True)

            _database.ExecuteSP_NO_Return("POInvoiceImport_UpdateFailedPart")
        End Sub

        Public Sub POInvoiceImport_UpdatePartQty(ByVal PartID As Integer, ByVal PartQty As Integer)
            _database.ClearParameter()
            _database.AddParameter("@ID", PartID, True)
            _database.AddParameter("@Quantity", PartQty, True)

            _database.ExecuteSP_NO_Return("POInvoiceImport_UpdatePartQty")
        End Sub

        Public Sub POInvoiceImport_UpdatePartUnitPrice(ByVal PartID As Integer, ByVal PartUnitPrice As Double)
            _database.ClearParameter()
            _database.AddParameter("@ID", PartID, True)
            _database.AddParameter("@UnitPrice", PartUnitPrice, True)

            _database.ExecuteSP_NO_Return("POInvoiceImport_UpdatePartUnitPrice")
        End Sub

        Public Sub POInvoiceImport_UpdateOrderTotalsAfterPartChange(ByVal PurchaseOrderNo As String, ByVal InvoiceNo As String)
            _database.ClearParameter()
            _database.AddParameter("@PurchaseOrderNo", PurchaseOrderNo, True)
            _database.AddParameter("@InvoiceNo", InvoiceNo, True)

            _database.ExecuteSP_NO_Return("POInvoiceImport_UpdateOrderTotalsAfterPartChange")
        End Sub

        '
        Public Function POInvoiceImport_CheckImportHasBeenSent(ByVal InvoiceNo As String, ByVal InvoiceDate As Date,
                                                                       ByVal SupplierPartCode As String) As Integer
            _database.ClearParameter()
            _database.AddParameter("@InvoiceNumber", InvoiceNo, True)
            _database.AddParameter("@InvoiceDate", InvoiceDate, True)
            _database.AddParameter("@SupplierPartCode", SupplierPartCode, True)
            Return _database.ExecuteScalar("SELECT COUNT(*) AS Expr1 " &
                                           "FROM tblPOInvoiceImport_Orders " &
                                           "LEFT OUTER JOIN tblPOInvoiceImport_Parts " &
                                           "ON tblPOInvoiceImport_Orders.InvoiceNo = tblPOInvoiceImport_Parts.InvoiceNo " &
                                           "WHERE (tblPOInvoiceImport_Orders.InvoiceNo = @InvoiceNumber) " &
                                           "AND (tblPOInvoiceImport_Orders.InvoiceDate = @InvoiceDate) " &
                                           "AND (tblPOInvoiceImport_Parts.SupplierPartCode = @SupplierPartCode) " &
                                           "AND (tblPOInvoiceImport_Orders.SupplierInvoiceCreated = 1)", False)
        End Function

        Public Function POInvoiceImport_CheckImportInvoiceExists(ByVal InvoiceNo As String, ByVal InvoiceDate As Date,
                                                                       ByVal SupplierPartCode As String) As Integer
            _database.ClearParameter()
            _database.AddParameter("@InvoiceNumber", InvoiceNo, True)
            _database.AddParameter("@InvoiceDate", InvoiceDate, True)
            _database.AddParameter("@SupplierPartCode", SupplierPartCode, True)
            Return _database.ExecuteScalar("SELECT COUNT(*) AS Expr1 " &
                                           "FROM tblPOInvoiceImport_Orders " &
                                           "LEFT OUTER JOIN tblPOInvoiceImport_Parts " &
                                           "ON tblPOInvoiceImport_Orders.InvoiceNo = tblPOInvoiceImport_Parts.InvoiceNo " &
                                           "WHERE (tblPOInvoiceImport_Orders.InvoiceNo = @InvoiceNumber) " &
                                           "AND (tblPOInvoiceImport_Orders.InvoiceDate = @InvoiceDate) " &
                                           "AND (tblPOInvoiceImport_Parts.SupplierPartCode = @SupplierPartCode) ", False)
        End Function

        Public Function POInvoiceImport_ValidatePart(ByVal SupplierID As Integer, ByVal PartCode As String) As Integer
            _database.ClearParameter()
            _database.AddParameter("@SupplierID", SupplierID, True)
            _database.AddParameter("@PartCode", PartCode, True)
            Return _database.ExecuteScalar("SELECT COUNT(*)	FROM tblPart INNER JOIN tblPartSupplier ON tblPart.PartID = tblPartSupplier.PartID WHERE (tblPartSupplier.Deleted IS NULL OR tblPartSupplier.Deleted = 0) AND (tblPart.Deleted IS NULL OR tblPart.Deleted = 0) AND (tblPartSupplier.SupplierID = @SupplierID) AND (tblPartSupplier.PartCode = @PartCode)", False)
        End Function

        Public Function POInvoiceImport_GetPartID(ByVal SupplierID As Integer, ByVal PartCode As String) As Integer
            _database.ClearParameter()
            _database.AddParameter("@SupplierID", SupplierID, True)
            _database.AddParameter("@PartCode", PartCode, True)
            Return _database.ExecuteScalar("SELECT tblPart.PartID FROM tblPart INNER JOIN tblPartSupplier ON tblPart.PartID = tblPartSupplier.PartID WHERE (tblPart.Deleted IS NULL OR tblPart.Deleted = 0) AND (tblPartSupplier.SupplierID = @SupplierID) AND (tblPartSupplier.PartCode = @PartCode) GROUP BY tblPart.PartID", False)
        End Function

        Public Function POInvoiceImport_GetOrderStatus(ByVal OrderID As Integer) As Integer
            _database.ClearParameter()
            _database.AddParameter("@OrderID", OrderID, True)
            Return _database.ExecuteScalar("SELECT OrderStatusID FROM tblOrder WHERE (OrderID = @OrderID)", False)
        End Function

        Public Sub PartsOrderedImport_ClearImportTable()
            _database.ClearParameter()
            _database.ExecuteSP_NO_Return("PartsOrderedImport_ClearImportTable")
        End Sub

        Public Function Parts_CheckPartsOrderedImportCount() As Integer
            _database.ClearParameter()

            Return _database.ExecuteScalar("SELECT COUNT(*) FROM tblPartsOrderedImport", False)
        End Function

        Public Function PartsOrderedImport_CheckImportExists(ByVal InvoiceNo As String, ByVal InvoiceDate As Date, ByVal PurchaseOrderNo As String, ByVal SupplierPartCode As String, ByVal Description As String, ByVal Quantity As Integer) As Integer
            _database.ClearParameter()
            _database.AddParameter("@SupplierOrderNumber", InvoiceNo, True)
            _database.AddParameter("@OrderDate", InvoiceDate, True)
            _database.AddParameter("@PurchaseOrderNumber", PurchaseOrderNo, True)
            _database.AddParameter("@SupplierPartCode", SupplierPartCode, True)
            _database.AddParameter("@Description", Description, True)
            _database.AddParameter("@Quantity", Quantity, True)
            Return _database.ExecuteScalar("SELECT COUNT(*) AS Expr1 FROM tblPartsOrderedImport WHERE (SupplierOrderNumber = @SupplierOrderNumber) AND (OrderDate = @OrderDate) AND (PurchaseOrderNumber = @PurchaseOrderNumber) AND (SupplierPartCode = @SupplierPartCode) AND (Description = @Description) AND (Quantity = @Quantity)", False)
        End Function

        Public Sub PartsOrderedImport_InsertPart(ByVal SupplierOrderNumber As String, ByVal OrderDate As DateTime, ByVal PurchaseOrderNumber As String, ByVal SupplierPartCode As String, ByVal Description As String, ByVal Quantity As Integer, ByVal SupplierID As Integer, ByVal ImportedByUserID As Integer)
            _database.ClearParameter()
            _database.AddParameter("@SupplierOrderNumber", SupplierOrderNumber, True)
            _database.AddParameter("@OrderDate", OrderDate, True)
            _database.AddParameter("@PurchaseOrderNumber", PurchaseOrderNumber, True)
            _database.AddParameter("@SupplierPartCode", SupplierPartCode, True)
            _database.AddParameter("@Description", Description, True)
            _database.AddParameter("@Quantity", Quantity, True)
            _database.AddParameter("@SupplierID", SupplierID, True)
            _database.AddParameter("@ImportedByUserID", ImportedByUserID, True)

            _database.ExecuteSP_NO_Return("PartsOrderedImport_InsertPart")
        End Sub

        Public Function PartsOrderedImport_GetAllUnprocessedParts() As DataView
            _database.ClearParameter()

            Dim dt As DataTable = _database.ExecuteSP_DataTable("PartsOrderedImport_GetAllUnprocessedParts")
            dt.TableName = "tblPartsOrderedImport"
            Return New DataView(dt)
        End Function

        Public Function PartsOrderedImport_RevalidateRecords(ByVal ValidateType As Integer) As DataView
            _database.ClearParameter()
            _database.AddParameter("@ValidateType", ValidateType, True)
            Dim dt As DataTable = _database.ExecuteSP_DataTable("PartsOrderedImport_ReValidateRecords")
            dt.TableName = "tblPartsOrderedImport"
            Return New DataView(dt)
        End Function

        Public Function PartsOrderedImport_ValidatePart(ByVal SupplierID As Integer, ByVal PartCode As String) As Integer
            _database.ClearParameter()
            _database.AddParameter("@SupplierID", SupplierID, True)
            _database.AddParameter("@PartCode", PartCode, True)
            Return _database.ExecuteScalar("SELECT COUNT(*)	FROM tblPart INNER JOIN tblPartSupplier ON tblPart.PartID = tblPartSupplier.PartID WHERE (tblPart.Deleted IS NULL OR tblPart.Deleted = 0) AND (tblPartSupplier.SupplierID = @SupplierID) AND (tblPartSupplier.PartCode = @PartCode)", False)
        End Function

        Public Sub PartsOrderedImport_UpdateProcessed(ByVal ID As Integer, ByVal Processed As Boolean)
            _database.ClearParameter()
            _database.AddParameter("@ID", ID, True)
            _database.AddParameter("@Processed", Processed, True)

            _database.ExecuteSP_NO_Return("PartsOrderedImport_UpdateProcessed")
        End Sub

        Public Sub PartsOrderedImport_UpdateExclude(ByVal ID As Integer, ByVal Exclude As Boolean)
            _database.ClearParameter()
            _database.AddParameter("@ID", ID, True)
            _database.AddParameter("@Exclude", Exclude, True)

            _database.ExecuteSP_NO_Return("PartsOrderedImport_UpdateExclude")
        End Sub

        Public Sub PartsOrderedImport_UpdateValidateType(ByVal ID As Integer, ByVal ValidateType As Integer)
            _database.ClearParameter()
            _database.AddParameter("@ID", ID, True)
            _database.AddParameter("@ValidateType", ValidateType, True)

            _database.ExecuteSP_NO_Return("PartsOrderedImport_UpdateValidateType")
        End Sub

        Public Function PartsOrderedImport_ShowData(Optional ByVal ValidateResult As Integer = 0) As DataView
            _database.ClearParameter()
            _database.AddParameter("@ValidateType", ValidateResult, True)

            Dim dt As DataTable = _database.ExecuteSP_DataTable("PartsOrderedImport_ShowData")
            dt.TableName = "PartsOrderedImport"
            Return New DataView(dt)
        End Function

        Public Sub PartsOrderedImport_UpdatePurchaseOrderNumber(ByVal ImportID As Integer, ByVal PurchaseOrderNumber As String)
            _database.ClearParameter()
            _database.AddParameter("@ID", ImportID, True)
            _database.AddParameter("@PurchaseOrderNumber", PurchaseOrderNumber, True)

            _database.ExecuteSP_NO_Return("PartsOrderedImport_UpdatePurchaseOrderNumber")
        End Sub

        Public Sub PartsOrderedImport_UpdateSupplierPartCode(ByVal ImportID As Integer, ByVal SupplierPartCode As String)
            _database.ClearParameter()
            _database.AddParameter("@ID", ImportID, True)
            _database.AddParameter("@SupplierPartCode", SupplierPartCode, True)

            _database.ExecuteSP_NO_Return("PartsOrderedImport_UpdateSupplierPartCode")
        End Sub

        Public Function PartsOrderedImport_GetPartID(ByVal SupplierID As Integer, ByVal PartCode As String) As Integer
            _database.ClearParameter()
            _database.AddParameter("@SupplierID", SupplierID, True)
            _database.AddParameter("@PartCode", PartCode, True)
            Return _database.ExecuteScalar("SELECT tblPart.PartID FROM tblPart INNER JOIN tblPartSupplier ON tblPart.PartID = tblPartSupplier.PartID WHERE (tblPart.Deleted IS NULL OR tblPart.Deleted = 0) AND (tblPartSupplier.SupplierID = @SupplierID) AND (tblPartSupplier.PartCode = @PartCode) GROUP BY tblPart.PartID", False)
        End Function

        Public Sub PartsOrderedImport_UpdateDelete(ByVal ID As Integer, ByVal ToBeDeleted As Boolean)
            _database.ClearParameter()
            _database.AddParameter("@ID", ID, True)
            _database.AddParameter("@ToBeDeleted", ToBeDeleted, True)

            _database.ExecuteSP_NO_Return("PartsOrderedImport_UpdateDelete")
        End Sub

        Public Sub PartsOrderedImport_ClearRecordFromImportTables(ByVal ID As Integer)
            _database.ClearParameter()
            _database.AddParameter("@ID", ID, True)
            _database.ExecuteSP_NO_Return("PartsOrderedImport_ClearRecordFromImportTables")
        End Sub

        Public Function Parts_CheckPartsInvoiceImportCount() As Integer
            _database.ClearParameter()

            Return _database.ExecuteScalar("SELECT COUNT(*) FROM tblPartsInvoiceImport", False)
        End Function

        Public Sub Parts_PartsInvoiceImportData(ByVal InvoiceNo As String, ByVal InvoiceDate As Date, ByVal PurchaseOrderNo As String, ByVal Engineer As String, ByVal SiteAddress As String, ByVal OrderType As String, ByVal SupplierPartCode As String, ByVal Description As String, ByVal Quantity As Integer, ByVal UnitPrice As Double, ByVal NetAmount As Double, ByVal VATAmount As Double, ByVal GrossAmount As Double)
            _database.ClearParameter()
            _database.AddParameter("@InvoiceNo", InvoiceNo, True)
            _database.AddParameter("@InvoiceDate", InvoiceDate, True)
            _database.AddParameter("@PurchaseOrderNo", PurchaseOrderNo, True)
            _database.AddParameter("@Engineer", Engineer, True)
            _database.AddParameter("@SiteAddress", SiteAddress, True)
            _database.AddParameter("@OrderType", OrderType, True)
            _database.AddParameter("@SupplierPartCode", SupplierPartCode, True)
            _database.AddParameter("@Description", Description, True)
            _database.AddParameter("@Quantity", Quantity, True)
            _database.AddParameter("@UnitPrice", UnitPrice, True)
            _database.AddParameter("@NetAmount", NetAmount, True)
            _database.AddParameter("@VATAmount", VATAmount, True)
            _database.AddParameter("@GrossAmount", GrossAmount, True)

            _database.ExecuteSP_NO_Return("Parts_PartsInvoiceImport_Insert")
        End Sub

        Public Function Parts_PartsInvoiceImport_ShowResults(Optional ByVal ValidateResult As Integer = 0) As DataView
            _database.ClearParameter()
            _database.AddParameter("@ValidateResult", ValidateResult, True)

            Dim dt As DataTable = _database.ExecuteSP_DataTable("Parts_PartsInvoiceImport_ShowResults")
            dt.TableName = "Parts_PartsInvoiceImport_ShowResults"
            Return New DataView(dt)
        End Function

        Public Function Parts_ClearPartsInvoiceImportTable() As Integer
            _database.ClearParameter()

            Return _database.ExecuteScalar("DELETE FROM tblPartsInvoiceImport")
        End Function

        Public Sub Parts_PartsInvoiceImport_UpdateExclude(ByVal ID As Integer, ByVal Exclude As Boolean)
            _database.ClearParameter()
            _database.AddParameter("@ID", ID, True)
            _database.AddParameter("@Exclude", Exclude, True)

            _database.ExecuteSP_NO_Return("Parts_PartsInvoiceImport_UpdateExclude")
        End Sub

        Public Sub Parts_PartsInvoiceImport_ValidateImportData(Optional ByVal ValidateType As Integer = 0)
            _database.ClearParameter()
            _database.AddParameter("@ValidateType", ValidateType, True)

            _database.ExecuteSP_NO_Return("Parts_PartsInvoiceImport_Validate")
        End Sub

        Public Sub BulkInsert(ByVal dt As DataTable)
            Dim ServerConnection As New SqlClient.SqlConnection(TheSystem.Configuration.ConnectionString)

            ServerConnection.Open()
            Using copy As New SqlBulkCopy(ServerConnection)
                copy.ColumnMappings.Add(0, 2)
                copy.ColumnMappings.Add(1, 3)
                copy.ColumnMappings.Add(2, 4)
                copy.ColumnMappings.Add(3, 7)
                copy.ColumnMappings.Add(4, 8)
                copy.ColumnMappings.Add(5, 15) 'pfh
                copy.ColumnMappings.Add(6, 5) 'Category
                copy.DestinationTableName = "tblPartsPreImport"
                copy.WriteToServer(dt)
            End Using
            ServerConnection.Close()
        End Sub

    End Class

End Namespace