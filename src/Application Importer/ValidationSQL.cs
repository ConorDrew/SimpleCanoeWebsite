using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Data;
using System.Data.SqlClient;

namespace FSM.Importer.Validation
{
    public class ValidationSQL
    {
        private Entity.Sys.Database _database;

        public ValidationSQL(Entity.Sys.Database database)
        {
            _database = database;
        }

        public bool CategoryExists(string Category)
        {
            if (App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.PartCategories).Table.Select("Name = '" + Category + "'").Length == 0 & App.DB.Picklists.GetAllPartMappings(Entity.Sys.Enums.PickListTypes.PartCategories).Table.Select("PartMapMatch = '" + Category + "'").Length == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public int CategoryID(string Category, SqlTransaction trans)
        {
            var Command = new SqlCommand();
            Command.CommandText = Entity.Sys.Helper.GetTextResource("Picklists_Get_PartMapping.sql").Replace("?EnumTypeID", Conversions.ToInteger(Entity.Sys.Enums.PickListTypes.PartCategories).ToString());
            Command.CommandType = CommandType.Text;
            Command.Transaction = trans;
            Command.Connection = trans.Connection;
            var Adapter = new SqlDataAdapter(Command);
            var returnDS = new DataSet();
            Adapter.Fill(returnDS);
            if (App.DB.Picklists.GetAllPartMappings(Entity.Sys.Enums.PickListTypes.PartCategories).Table.Select("PartMapMatch = '" + Category + "'").Length == 0)
            {
                return Conversions.ToInteger(returnDS.Tables[0].Select("Name = '" + Category + "'")[0]["ManagerID"]);
            }
            else
            {
                return Conversions.ToInteger(returnDS.Tables[0].Select("PartMapMatch = '" + Category + "'")[0]["ManagerID"]);
            }
        }

        public int Parts_PreImportData(int SupplierID, string PartCode, string Description, string Category, string SupplierPartCode, double SupplierPrice)
        {
            _database.ClearParameter();
            _database.AddParameter("@SupplierID", SupplierID, true);
            _database.AddParameter("@PartCode", PartCode, true);
            _database.AddParameter("@Description", Description, true);
            _database.AddParameter("@Category", Category, true);
            _database.AddParameter("@SupplierPartCode", SupplierPartCode, true);
            _database.AddParameter("@SupplierPrice", SupplierPrice, true);
            _database.ExecuteSP_NO_Return("Part_PreImportInsert");
            return Conversions.ToInteger(_database.ExecuteScalar("SELECT COUNT(*) FROM tblPartsPreImport", false));
        }

        public DataView Parts_GetPreImportData(int ValidateType = 0)
        {
            _database.ClearParameter();
            _database.AddParameter("@ValidateType", ValidateType, true);
            var dt = _database.ExecuteSP_DataTable("Parts_GetPreImport");
            dt.TableName = "Parts_GetPreImport";
            return new DataView(dt);
        }

        public void Parts_ValidatePreImportData(int ValidateType = 0, bool pfh = false)
        {
            _database.ClearParameter();
            _database.AddParameter("@ValidateType", ValidateType, true);
            _database.AddParameter("@PFH", pfh, true);
            _database.ExecuteSP_NO_Return("Parts_PreImportValidate_Mk2");
        }

        public void Parts_PreImportNoChangeRemove(bool PrimaryPrice)
        {
            _database.ClearParameter();
            _database.AddParameter("@UserID", App.loggedInUser.UserID, true);
            _database.AddParameter("@PrimaryPrice", PrimaryPrice, true);
            _database.ExecuteSP_NO_Return("Parts_PreImportNoChange");
        }

        public void Parts_ImportApplyPriceChange(int ValidateType)
        {
            _database.ClearParameter();
            _database.AddParameter("@ValidateType", ValidateType, true);
            _database.AddParameter("@UserID", App.loggedInUser.UserID, true);
            _database.ExecuteSP_NO_Return("Parts_PreImportApplyPrices");
        }

        public void Parts_ImportAddPartSuppliers(int ValidateType = 0)
        {
            _database.ClearParameter();
            _database.AddParameter("@UserID", App.loggedInUser.UserID, true);
            _database.ExecuteSP_NO_Return("Parts_PreImportSupplierPart");
        }

        public void Parts_ImportAddParts(int ValidateType = 0)
        {
            _database.ClearParameter();
            _database.AddParameter("@UserID", App.loggedInUser.UserID, true);
            _database.ExecuteSP_NO_Return("Parts_PreImportAddNewPart");
        }

        public int Parts_CheckPreImportCount()
        {
            _database.ClearParameter();
            return Conversions.ToInteger(_database.ExecuteScalar("SELECT COUNT(*) FROM tblPartsPreImport", false));
        }

        public int Parts_ClearPreImport()
        {
            _database.ClearParameter();
            return Conversions.ToInteger(_database.ExecuteScalar("DELETE FROM tblPartsPreImport"));
        }

        public void Parts_PreImportChange(int ImportID, bool Exclude, bool ForceInsert, double ImportPrice, string ImportDescription, bool SwapSPN, string Category)
        {
            _database.ClearParameter();
            _database.AddParameter("@ImportID", ImportID, true);
            _database.AddParameter("@Exclude", Exclude, true);
            _database.AddParameter("@ForceInsert", ForceInsert, true);
            _database.AddParameter("@ImportPrice", ImportPrice, true);
            _database.AddParameter("@ImportDesc", ImportDescription, true);
            _database.AddParameter("@SwapSPN", SwapSPN, true);
            _database.AddParameter("@Category", Category, true);
            _database.ExecuteSP_NO_Return("Parts_PreImportChange");
        }

        public void Parts_UpdatePart(int ImportID, string ImportDescription, string ExistingSPC)
        {
            _database.ClearParameter();
            _database.AddParameter("@ImportID", ImportID, true);
            _database.AddParameter("@ImportDesc", ImportDescription, true);
            _database.AddParameter("@NewExistingSPC", ExistingSPC, true);
            _database.AddParameter("@UserID", App.loggedInUser.UserID, true);
            _database.ExecuteSP_NO_Return("Parts_PreImportUpdatePart");
        }

        public DataTable Parts_PreImportStats()
        {
            _database.ClearParameter();
            var dt = _database.ExecuteSP_DataTable("Parts_PreImportStats");
            dt.TableName = "Parts_PreImportStats";
            return dt;
        }

        public void POInvoice_ClearImportTables()
        {
            _database.ClearParameter();
            _database.ExecuteSP_NO_Return("POInvoiceImport_ClearImportTables");
        }

        public void POInvoiceImport_ClearRecordFromImportTables(string PurchaseOrderNo, string InvoiceNo)
        {
            _database.ClearParameter();
            _database.AddParameter("@PurchaseOrderNo", PurchaseOrderNo, true);
            _database.AddParameter("@InvoiceNo", InvoiceNo, true);
            _database.ExecuteSP_NO_Return("POInvoiceImport_ClearRecordFromImportTables");
        }

        public int POInvoiceImport_InsertOrder(string InvoiceNo, DateTime InvoiceDate, string PurchaseOrderNo, int SupplierID, string OrderType, string nominalCode = null)
        {
            _database.ClearParameter();
            _database.AddParameter("@InvoiceNo", InvoiceNo, true);
            _database.AddParameter("@InvoiceDate", InvoiceDate, true);
            _database.AddParameter("@PurchaseOrderNo", PurchaseOrderNo, true);
            _database.AddParameter("@SupplierID", SupplierID, true);
            _database.AddParameter("@NoOfParts", 0, true);
            _database.AddParameter("@TotalUnitPrice", 0, true);
            _database.AddParameter("@TotalNetAmount", 0, true);
            _database.AddParameter("@TotalVATAmount", 0, true);
            _database.AddParameter("@TotalGrossAmount", 0, true);
            _database.AddParameter("@OrderType", OrderType, true);
            _database.AddParameter("@NominalCode", nominalCode, true);
            return Conversions.ToInteger(_database.ExecuteSP_OBJECT("POInvoiceImport_InsertOrder"));
        }

        public void POInvoiceImport_InsertPart(string PurchaseOrderNo, string SupplierPartCode, string Description, int Quantity, double UnitPrice, double NetAmount, double VATAmount, double GrossAmount, string InvoiceNo)
        {
            _database.ClearParameter();
            _database.AddParameter("@PurchaseOrderNo", PurchaseOrderNo, true);
            _database.AddParameter("@SupplierPartCode", SupplierPartCode, true);
            _database.AddParameter("@Description", Description, true);
            _database.AddParameter("@Quantity", Quantity, true);
            _database.AddParameter("@UnitPrice", UnitPrice, true);
            _database.AddParameter("@NetAmount", NetAmount, true);
            _database.AddParameter("@VATAmount", VATAmount, true);
            _database.AddParameter("@GrossAmount", GrossAmount, true);
            _database.AddParameter("@InvoiceNo", InvoiceNo, true);
            _database.ExecuteSP_NO_Return("POInvoiceImport_InsertPart");
        }

        public int Orders_GetID(string poNumber, string supplierId, string invoiceNumber)
        {
            _database.ClearParameter();
            _database.AddParameter("@PurchaseOrderNo", poNumber, true);
            _database.AddParameter("@SupplierID", supplierId, true);
            _database.AddParameter("@InvoiceNo", invoiceNumber, true);
            return Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("POInvoiceImport_Orders_GetID"));
        }

        public void POInvoiceImport_UpdateOrderTotals(string PurchaseOrderNo, int NoOfParts, double TotalUnitPrice, double TotalNetAmount, double TotalVATAmount, double TotalGrossAmount, int TotalQtyOfParts, string InvoiceNo)
        {
            _database.ClearParameter();
            _database.AddParameter("@PurchaseOrderNo", PurchaseOrderNo, true);
            _database.AddParameter("@NoOfParts", NoOfParts, true);
            _database.AddParameter("@TotalUnitPrice", TotalUnitPrice, true);
            _database.AddParameter("@TotalNetAmount", TotalNetAmount, true);
            _database.AddParameter("@TotalVATAmount", TotalVATAmount, true);
            _database.AddParameter("@TotalGrossAmount", TotalGrossAmount, true);
            _database.AddParameter("@TotalQtyOfParts", TotalQtyOfParts, true);
            _database.AddParameter("@InvoiceNo", InvoiceNo, true);
            _database.ExecuteSP_NO_Return("POInvoiceImport_UpdateOrderTotals");
        }

        public void POInvoiceImport_ValidateOrders(int ValidateType = 0)
        {
            _database.ClearParameter();
            _database.AddParameter("@ValidateType", ValidateType, true);
            _database.ExecuteSP_NO_Return("POInvoiceImport_ValidateOrders_Test");
        }

        public void POInvoiceImport_UpdatePurchaseOrderNoAndValidate(int ImportID, string PurchaseOrderNo)
        {
            _database.ClearParameter();
            _database.AddParameter("@ID", ImportID, true);
            _database.AddParameter("@PurchaseOrderNo", PurchaseOrderNo, true);
            _database.ExecuteSP_NO_Return("POInvoiceImport_UpdatePurchaseOrderNoAndValidate");
        }

        public bool POInvoiceImport_ValidateOrder(int ImportID)
        {
            _database.ClearParameter();
            _database.AddParameter("@ID", ImportID, true);
            int rows = _database.ExecuteSP_ReturnRowsAffected("POInvoiceImport_ValidateOrder_Mk2");
            bool result = false;
            if (rows == 1)
                result = true;
            return result;
        }

        public DataView POInvoiceImport_ShowData(int ValidateResult = 0)
        {
            _database.ClearParameter();
            _database.AddParameter("@ValidateResult", ValidateResult, true);
            var dt = _database.ExecuteSP_DataTable("POInvoiceImport_ShowData");
            dt.TableName = "POInvoiceImport_ShowData";
            return new DataView(dt);
        }

        public DataView POInvoiceImport_ShowData_Mk1()
        {
            _database.ClearParameter();
            var dt = _database.ExecuteSP_DataTable("POInvoiceImport_ShowData_Mk1");
            dt.TableName = "POInvoiceImport_ShowData";
            return new DataView(dt);
        }

        public DataView POInvoiceImport_GetOrdersWithNoParts(int ValidateResult)
        {
            _database.ClearParameter();
            _database.AddParameter("@ValidateResult", ValidateResult, true);
            var dt = _database.ExecuteSP_DataTable("POInvoiceImport_GetOrdersWithNoParts");
            dt.TableName = "POInvoiceImport_GetOrdersWithNoParts";
            return new DataView(dt);
        }

        public void POInvoiceImport_UpdateExclude(int ID, bool Exclude)
        {
            _database.ClearParameter();
            _database.AddParameter("@ID", ID, true);
            _database.AddParameter("@Exclude", Exclude, true);
            _database.ExecuteSP_NO_Return("POInvoiceImport_UpdateExclude");
        }

        public void POInvoiceImport_UpdateRequiresAuthorisation(int ID, bool RequiresAuth)
        {
            _database.ClearParameter();
            _database.AddParameter("@ID", ID, true);
            _database.AddParameter("@RequiresAuth", RequiresAuth, true);
            _database.ExecuteSP_NO_Return("POInvoiceImport_UpdateRequiresAuthorisation");
        }

        public void Order_UpdateSupplier(int OrderID, int SupplierID)
        {
            _database.ClearParameter();
            _database.AddParameter("@OrderID", OrderID, true);
            _database.AddParameter("@SupplierID", SupplierID, true);
            _database.ExecuteSP_NO_Return("Order_UpdateSupplier");
        }

        public void POInvoiceImport_UpdateSupplierInvoiceCreated(int ID, bool InvoiceCreated)
        {
            _database.ClearParameter();
            _database.AddParameter("@ID", ID, true);
            _database.AddParameter("@SupplierInvoiceCreated", InvoiceCreated, true);
            _database.ExecuteSP_NO_Return("POInvoiceImport_UpdateSupplierInvoiceCreated");
        }

        public void POInvoiceImport_UpdateDelete(int ID, bool ToBeDeleted)
        {
            _database.ClearParameter();
            _database.AddParameter("@ID", ID, true);
            _database.AddParameter("@ToBeDeleted", ToBeDeleted, true);
            _database.ExecuteSP_NO_Return("POInvoiceImport_UpdateDelete");
        }

        public DataView POInvoiceImport_ShowPOParts(string PurchaseOrderNo, string InvoiceNo)
        {
            _database.ClearParameter();
            _database.AddParameter("@PurchaseOrderNo", PurchaseOrderNo, true);
            _database.AddParameter("@InvoiceNo", InvoiceNo, true);
            var dt = _database.ExecuteSP_DataTable("POInvoiceImport_ShowPOParts");
            dt.TableName = "POInvoiceImport_Parts";
            return new DataView(dt);
        }

        public DataView POInvoiceImport_GetPOParts(string PurchaseOrderNo, string InvoiceNo)
        {
            _database.ClearParameter();
            _database.AddParameter("@PurchaseOrderNo", PurchaseOrderNo, true);
            _database.AddParameter("@InvoiceNo", InvoiceNo, true);
            var dt = _database.ExecuteSP_DataTable("POInvoiceImport_ShowPOParts");
            dt.TableName = "POInvoiceImport_Parts";
            return new DataView(dt);
        }

        public void POInvoiceImport_AddSupplierInvoiceDetailToPO(string PurchaseOrderNo)
        {
            _database.ClearParameter();
            _database.AddParameter("@PurchaseOrderNo", PurchaseOrderNo, true);
            _database.ExecuteSP_NO_Return("Parts_PreImportValidate");
        }

        public void POInvoiceImport_UpdateValidationType(int ID, int ValidateResult = 0)
        {
            _database.ClearParameter();
            _database.AddParameter("@ID", ID, true);
            _database.AddParameter("@ValidateResult", ValidateResult, true);
            _database.ExecuteSP_NO_Return("POInvoiceImport_UpdateValidateResult");
        }

        public void POInvoiceImport_UpdateFailedPart(int ID, bool Failed)
        {
            _database.ClearParameter();
            _database.AddParameter("@ID", ID, true);
            _database.AddParameter("@Failed", Failed, true);
            _database.ExecuteSP_NO_Return("POInvoiceImport_UpdateFailedPart");
        }

        public void POInvoiceImport_UpdatePartQty(int PartID, int PartQty)
        {
            _database.ClearParameter();
            _database.AddParameter("@ID", PartID, true);
            _database.AddParameter("@Quantity", PartQty, true);
            _database.ExecuteSP_NO_Return("POInvoiceImport_UpdatePartQty");
        }

        public void POInvoiceImport_UpdatePartUnitPrice(int PartID, double PartUnitPrice)
        {
            _database.ClearParameter();
            _database.AddParameter("@ID", PartID, true);
            _database.AddParameter("@UnitPrice", PartUnitPrice, true);
            _database.ExecuteSP_NO_Return("POInvoiceImport_UpdatePartUnitPrice");
        }

        public void POInvoiceImport_UpdateOrderTotalsAfterPartChange(string PurchaseOrderNo, string InvoiceNo)
        {
            _database.ClearParameter();
            _database.AddParameter("@PurchaseOrderNo", PurchaseOrderNo, true);
            _database.AddParameter("@InvoiceNo", InvoiceNo, true);
            _database.ExecuteSP_NO_Return("POInvoiceImport_UpdateOrderTotalsAfterPartChange");
        }

        //
        public int POInvoiceImport_CheckImportHasBeenSent(string InvoiceNo, DateTime InvoiceDate, string SupplierPartCode)
        {
            _database.ClearParameter();
            _database.AddParameter("@InvoiceNumber", InvoiceNo, true);
            _database.AddParameter("@InvoiceDate", InvoiceDate, true);
            _database.AddParameter("@SupplierPartCode", SupplierPartCode, true);
            return Conversions.ToInteger(_database.ExecuteScalar("SELECT COUNT(*) AS Expr1 " + "FROM tblPOInvoiceImport_Orders " + "LEFT OUTER JOIN tblPOInvoiceImport_Parts " + "ON tblPOInvoiceImport_Orders.InvoiceNo = tblPOInvoiceImport_Parts.InvoiceNo " + "WHERE (tblPOInvoiceImport_Orders.InvoiceNo = @InvoiceNumber) " + "AND (tblPOInvoiceImport_Orders.InvoiceDate = @InvoiceDate) " + "AND (tblPOInvoiceImport_Parts.SupplierPartCode = @SupplierPartCode) " + "AND (tblPOInvoiceImport_Orders.SupplierInvoiceCreated = 1)", false));
        }

        public int POInvoiceImport_CheckImportInvoiceExists(string InvoiceNo, DateTime InvoiceDate, string SupplierPartCode)
        {
            _database.ClearParameter();
            _database.AddParameter("@InvoiceNumber", InvoiceNo, true);
            _database.AddParameter("@InvoiceDate", InvoiceDate, true);
            _database.AddParameter("@SupplierPartCode", SupplierPartCode, true);
            return Conversions.ToInteger(_database.ExecuteScalar("SELECT COUNT(*) AS Expr1 " + "FROM tblPOInvoiceImport_Orders " + "LEFT OUTER JOIN tblPOInvoiceImport_Parts " + "ON tblPOInvoiceImport_Orders.InvoiceNo = tblPOInvoiceImport_Parts.InvoiceNo " + "WHERE (tblPOInvoiceImport_Orders.InvoiceNo = @InvoiceNumber) " + "AND (tblPOInvoiceImport_Orders.InvoiceDate = @InvoiceDate) " + "AND (tblPOInvoiceImport_Parts.SupplierPartCode = @SupplierPartCode) ", false));
        }

        public int POInvoiceImport_ValidatePart(int SupplierID, string PartCode)
        {
            _database.ClearParameter();
            _database.AddParameter("@SupplierID", SupplierID, true);
            _database.AddParameter("@PartCode", PartCode, true);
            return Conversions.ToInteger(_database.ExecuteScalar("SELECT COUNT(*)	FROM tblPart INNER JOIN tblPartSupplier ON tblPart.PartID = tblPartSupplier.PartID WHERE (tblPartSupplier.Deleted IS NULL OR tblPartSupplier.Deleted = 0) AND (tblPart.Deleted IS NULL OR tblPart.Deleted = 0) AND (tblPartSupplier.SupplierID = @SupplierID) AND (tblPartSupplier.PartCode = @PartCode)", false));
        }

        public int POInvoiceImport_GetPartID(int SupplierID, string PartCode)
        {
            _database.ClearParameter();
            _database.AddParameter("@SupplierID", SupplierID, true);
            _database.AddParameter("@PartCode", PartCode, true);
            return Conversions.ToInteger(_database.ExecuteScalar("SELECT tblPart.PartID FROM tblPart INNER JOIN tblPartSupplier ON tblPart.PartID = tblPartSupplier.PartID WHERE (tblPart.Deleted IS NULL OR tblPart.Deleted = 0) AND (tblPartSupplier.SupplierID = @SupplierID) AND (tblPartSupplier.PartCode = @PartCode) GROUP BY tblPart.PartID", false));
        }

        public int POInvoiceImport_GetOrderStatus(int OrderID)
        {
            _database.ClearParameter();
            _database.AddParameter("@OrderID", OrderID, true);
            return Conversions.ToInteger(_database.ExecuteScalar("SELECT OrderStatusID FROM tblOrder WHERE (OrderID = @OrderID)", false));
        }

        public void PartsOrderedImport_ClearImportTable()
        {
            _database.ClearParameter();
            _database.ExecuteSP_NO_Return("PartsOrderedImport_ClearImportTable");
        }

        public int Parts_CheckPartsOrderedImportCount()
        {
            _database.ClearParameter();
            return Conversions.ToInteger(_database.ExecuteScalar("SELECT COUNT(*) FROM tblPartsOrderedImport", false));
        }

        public int PartsOrderedImport_CheckImportExists(string InvoiceNo, DateTime InvoiceDate, string PurchaseOrderNo, string SupplierPartCode, string Description, int Quantity)
        {
            _database.ClearParameter();
            _database.AddParameter("@SupplierOrderNumber", InvoiceNo, true);
            _database.AddParameter("@OrderDate", InvoiceDate, true);
            _database.AddParameter("@PurchaseOrderNumber", PurchaseOrderNo, true);
            _database.AddParameter("@SupplierPartCode", SupplierPartCode, true);
            _database.AddParameter("@Description", Description, true);
            _database.AddParameter("@Quantity", Quantity, true);
            return Conversions.ToInteger(_database.ExecuteScalar("SELECT COUNT(*) AS Expr1 FROM tblPartsOrderedImport WHERE (SupplierOrderNumber = @SupplierOrderNumber) AND (OrderDate = @OrderDate) AND (PurchaseOrderNumber = @PurchaseOrderNumber) AND (SupplierPartCode = @SupplierPartCode) AND (Description = @Description) AND (Quantity = @Quantity)", false));
        }

        public void PartsOrderedImport_InsertPart(string SupplierOrderNumber, DateTime OrderDate, string PurchaseOrderNumber, string SupplierPartCode, string Description, int Quantity, int SupplierID, int ImportedByUserID)
        {
            _database.ClearParameter();
            _database.AddParameter("@SupplierOrderNumber", SupplierOrderNumber, true);
            _database.AddParameter("@OrderDate", OrderDate, true);
            _database.AddParameter("@PurchaseOrderNumber", PurchaseOrderNumber, true);
            _database.AddParameter("@SupplierPartCode", SupplierPartCode, true);
            _database.AddParameter("@Description", Description, true);
            _database.AddParameter("@Quantity", Quantity, true);
            _database.AddParameter("@SupplierID", SupplierID, true);
            _database.AddParameter("@ImportedByUserID", ImportedByUserID, true);
            _database.ExecuteSP_NO_Return("PartsOrderedImport_InsertPart");
        }

        public DataView PartsOrderedImport_GetAllUnprocessedParts()
        {
            _database.ClearParameter();
            var dt = _database.ExecuteSP_DataTable("PartsOrderedImport_GetAllUnprocessedParts");
            dt.TableName = "tblPartsOrderedImport";
            return new DataView(dt);
        }

        public DataView PartsOrderedImport_RevalidateRecords(int ValidateType)
        {
            _database.ClearParameter();
            _database.AddParameter("@ValidateType", ValidateType, true);
            var dt = _database.ExecuteSP_DataTable("PartsOrderedImport_ReValidateRecords");
            dt.TableName = "tblPartsOrderedImport";
            return new DataView(dt);
        }

        public int PartsOrderedImport_ValidatePart(int SupplierID, string PartCode)
        {
            _database.ClearParameter();
            _database.AddParameter("@SupplierID", SupplierID, true);
            _database.AddParameter("@PartCode", PartCode, true);
            return Conversions.ToInteger(_database.ExecuteScalar("SELECT COUNT(*)	FROM tblPart INNER JOIN tblPartSupplier ON tblPart.PartID = tblPartSupplier.PartID WHERE (tblPart.Deleted IS NULL OR tblPart.Deleted = 0) AND (tblPartSupplier.SupplierID = @SupplierID) AND (tblPartSupplier.PartCode = @PartCode)", false));
        }

        public void PartsOrderedImport_UpdateProcessed(int ID, bool Processed)
        {
            _database.ClearParameter();
            _database.AddParameter("@ID", ID, true);
            _database.AddParameter("@Processed", Processed, true);
            _database.ExecuteSP_NO_Return("PartsOrderedImport_UpdateProcessed");
        }

        public void PartsOrderedImport_UpdateExclude(int ID, bool Exclude)
        {
            _database.ClearParameter();
            _database.AddParameter("@ID", ID, true);
            _database.AddParameter("@Exclude", Exclude, true);
            _database.ExecuteSP_NO_Return("PartsOrderedImport_UpdateExclude");
        }

        public void PartsOrderedImport_UpdateValidateType(int ID, int ValidateType)
        {
            _database.ClearParameter();
            _database.AddParameter("@ID", ID, true);
            _database.AddParameter("@ValidateType", ValidateType, true);
            _database.ExecuteSP_NO_Return("PartsOrderedImport_UpdateValidateType");
        }

        public DataView PartsOrderedImport_ShowData(int ValidateResult = 0)
        {
            _database.ClearParameter();
            _database.AddParameter("@ValidateType", ValidateResult, true);
            var dt = _database.ExecuteSP_DataTable("PartsOrderedImport_ShowData");
            dt.TableName = "PartsOrderedImport";
            return new DataView(dt);
        }

        public void PartsOrderedImport_UpdatePurchaseOrderNumber(int ImportID, string PurchaseOrderNumber)
        {
            _database.ClearParameter();
            _database.AddParameter("@ID", ImportID, true);
            _database.AddParameter("@PurchaseOrderNumber", PurchaseOrderNumber, true);
            _database.ExecuteSP_NO_Return("PartsOrderedImport_UpdatePurchaseOrderNumber");
        }

        public void PartsOrderedImport_UpdateSupplierPartCode(int ImportID, string SupplierPartCode)
        {
            _database.ClearParameter();
            _database.AddParameter("@ID", ImportID, true);
            _database.AddParameter("@SupplierPartCode", SupplierPartCode, true);
            _database.ExecuteSP_NO_Return("PartsOrderedImport_UpdateSupplierPartCode");
        }

        public int PartsOrderedImport_GetPartID(int SupplierID, string PartCode)
        {
            _database.ClearParameter();
            _database.AddParameter("@SupplierID", SupplierID, true);
            _database.AddParameter("@PartCode", PartCode, true);
            return Conversions.ToInteger(_database.ExecuteScalar("SELECT tblPart.PartID FROM tblPart INNER JOIN tblPartSupplier ON tblPart.PartID = tblPartSupplier.PartID WHERE (tblPart.Deleted IS NULL OR tblPart.Deleted = 0) AND (tblPartSupplier.SupplierID = @SupplierID) AND (tblPartSupplier.PartCode = @PartCode) GROUP BY tblPart.PartID", false));
        }

        public void PartsOrderedImport_UpdateDelete(int ID, bool ToBeDeleted)
        {
            _database.ClearParameter();
            _database.AddParameter("@ID", ID, true);
            _database.AddParameter("@ToBeDeleted", ToBeDeleted, true);
            _database.ExecuteSP_NO_Return("PartsOrderedImport_UpdateDelete");
        }

        public void PartsOrderedImport_ClearRecordFromImportTables(int ID)
        {
            _database.ClearParameter();
            _database.AddParameter("@ID", ID, true);
            _database.ExecuteSP_NO_Return("PartsOrderedImport_ClearRecordFromImportTables");
        }

        public int Parts_CheckPartsInvoiceImportCount()
        {
            _database.ClearParameter();
            return Conversions.ToInteger(_database.ExecuteScalar("SELECT COUNT(*) FROM tblPartsInvoiceImport", false));
        }

        public void Parts_PartsInvoiceImportData(string InvoiceNo, DateTime InvoiceDate, string PurchaseOrderNo, string Engineer, string SiteAddress, string OrderType, string SupplierPartCode, string Description, int Quantity, double UnitPrice, double NetAmount, double VATAmount, double GrossAmount)
        {
            _database.ClearParameter();
            _database.AddParameter("@InvoiceNo", InvoiceNo, true);
            _database.AddParameter("@InvoiceDate", InvoiceDate, true);
            _database.AddParameter("@PurchaseOrderNo", PurchaseOrderNo, true);
            _database.AddParameter("@Engineer", Engineer, true);
            _database.AddParameter("@SiteAddress", SiteAddress, true);
            _database.AddParameter("@OrderType", OrderType, true);
            _database.AddParameter("@SupplierPartCode", SupplierPartCode, true);
            _database.AddParameter("@Description", Description, true);
            _database.AddParameter("@Quantity", Quantity, true);
            _database.AddParameter("@UnitPrice", UnitPrice, true);
            _database.AddParameter("@NetAmount", NetAmount, true);
            _database.AddParameter("@VATAmount", VATAmount, true);
            _database.AddParameter("@GrossAmount", GrossAmount, true);
            _database.ExecuteSP_NO_Return("Parts_PartsInvoiceImport_Insert");
        }

        public DataView Parts_PartsInvoiceImport_ShowResults(int ValidateResult = 0)
        {
            _database.ClearParameter();
            _database.AddParameter("@ValidateResult", ValidateResult, true);
            var dt = _database.ExecuteSP_DataTable("Parts_PartsInvoiceImport_ShowResults");
            dt.TableName = "Parts_PartsInvoiceImport_ShowResults";
            return new DataView(dt);
        }

        public int Parts_ClearPartsInvoiceImportTable()
        {
            _database.ClearParameter();
            return Conversions.ToInteger(_database.ExecuteScalar("DELETE FROM tblPartsInvoiceImport"));
        }

        public void Parts_PartsInvoiceImport_UpdateExclude(int ID, bool Exclude)
        {
            _database.ClearParameter();
            _database.AddParameter("@ID", ID, true);
            _database.AddParameter("@Exclude", Exclude, true);
            _database.ExecuteSP_NO_Return("Parts_PartsInvoiceImport_UpdateExclude");
        }

        public void Parts_PartsInvoiceImport_ValidateImportData(int ValidateType = 0)
        {
            _database.ClearParameter();
            _database.AddParameter("@ValidateType", ValidateType, true);
            _database.ExecuteSP_NO_Return("Parts_PartsInvoiceImport_Validate");
        }

        public void BulkInsert(DataTable dt)
        {
            var ServerConnection = new SqlConnection(App.TheSystem.Configuration.ConnectionString);
            ServerConnection.Open();
            using (var copy = new SqlBulkCopy(ServerConnection))
            {
                copy.ColumnMappings.Add(0, 2);
                copy.ColumnMappings.Add(1, 3);
                copy.ColumnMappings.Add(2, 4);
                copy.ColumnMappings.Add(3, 7);
                copy.ColumnMappings.Add(4, 8);
                copy.ColumnMappings.Add(5, 15); // pfh
                copy.ColumnMappings.Add(6, 5); // Category
                copy.DestinationTableName = "tblPartsPreImport";
                copy.WriteToServer(dt);
            }

            ServerConnection.Close();
        }
    }
}