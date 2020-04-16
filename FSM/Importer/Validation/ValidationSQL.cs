// Decompiled with JetBrains decompiler
// Type: FSM.Importer.Validation.ValidationSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace FSM.Importer.Validation
{
  public class ValidationSQL
  {
    private Database _database;

    public ValidationSQL(Database database)
    {
      this._database = database;
    }

    public bool CategoryExists(string Category)
    {
      return !(App.DB.Picklists.GetAll(Enums.PickListTypes.PartCategories, false).Table.Select("Name = '" + Category + "'").Length == 0 & App.DB.Picklists.GetAllPartMappings(Enums.PickListTypes.PartCategories).Table.Select("PartMapMatch = '" + Category + "'").Length == 0);
    }

    public int CategoryID(string Category, SqlTransaction trans)
    {
      SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(new SqlCommand()
      {
        CommandText = Helper.GetTextResource("Picklists_Get_PartMapping.sql").Replace("?EnumTypeID", Conversions.ToString(21)),
        CommandType = CommandType.Text,
        Transaction = trans,
        Connection = trans.Connection
      });
      DataSet dataSet = new DataSet();
      sqlDataAdapter.Fill(dataSet);
      return App.DB.Picklists.GetAllPartMappings(Enums.PickListTypes.PartCategories).Table.Select("PartMapMatch = '" + Category + "'").Length == 0 ? Conversions.ToInteger(dataSet.Tables[0].Select("Name = '" + Category + "'")[0]["ManagerID"]) : Conversions.ToInteger(dataSet.Tables[0].Select("PartMapMatch = '" + Category + "'")[0]["ManagerID"]);
    }

    public int Parts_PreImportData(
      int SupplierID,
      string PartCode,
      string Description,
      string Category,
      string SupplierPartCode,
      double SupplierPrice)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@SupplierID", (object) SupplierID, true);
      this._database.AddParameter("@PartCode", (object) PartCode, true);
      this._database.AddParameter("@Description", (object) Description, true);
      this._database.AddParameter("@Category", (object) Category, true);
      this._database.AddParameter("@SupplierPartCode", (object) SupplierPartCode, true);
      this._database.AddParameter("@SupplierPrice", (object) SupplierPrice, true);
      this._database.ExecuteSP_NO_Return("Part_PreImportInsert", true);
      return Conversions.ToInteger(this._database.ExecuteScalar("SELECT COUNT(*) FROM tblPartsPreImport", false, false));
    }

    public DataView Parts_GetPreImportData(int ValidateType = 0)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@ValidateType", (object) ValidateType, true);
      DataTable table = this._database.ExecuteSP_DataTable("Parts_GetPreImport", true);
      table.TableName = "Parts_GetPreImport";
      return new DataView(table);
    }

    public void Parts_ValidatePreImportData(int ValidateType = 0, bool pfh = false)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@ValidateType", (object) ValidateType, true);
      this._database.AddParameter("@PFH", (object) pfh, true);
      this._database.ExecuteSP_NO_Return("Parts_PreImportValidate_Mk2", true);
    }

    public void Parts_PreImportNoChangeRemove(bool PrimaryPrice)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@UserID", (object) App.loggedInUser.UserID, true);
      this._database.AddParameter("@PrimaryPrice", (object) PrimaryPrice, true);
      this._database.ExecuteSP_NO_Return("Parts_PreImportNoChange", true);
    }

    public void Parts_ImportApplyPriceChange(int ValidateType)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@ValidateType", (object) ValidateType, true);
      this._database.AddParameter("@UserID", (object) App.loggedInUser.UserID, true);
      this._database.ExecuteSP_NO_Return("Parts_PreImportApplyPrices", true);
    }

    public void Parts_ImportAddPartSuppliers(int ValidateType = 0)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@UserID", (object) App.loggedInUser.UserID, true);
      this._database.ExecuteSP_NO_Return("Parts_PreImportSupplierPart", true);
    }

    public void Parts_ImportAddParts(int ValidateType = 0)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@UserID", (object) App.loggedInUser.UserID, true);
      this._database.ExecuteSP_NO_Return("Parts_PreImportAddNewPart", true);
    }

    public int Parts_CheckPreImportCount()
    {
      this._database.ClearParameter();
      return Conversions.ToInteger(this._database.ExecuteScalar("SELECT COUNT(*) FROM tblPartsPreImport", false, false));
    }

    public int Parts_ClearPreImport()
    {
      this._database.ClearParameter();
      return Conversions.ToInteger(this._database.ExecuteScalar("DELETE FROM tblPartsPreImport", true, false));
    }

    public void Parts_PreImportChange(
      int ImportID,
      bool Exclude,
      bool ForceInsert,
      double ImportPrice,
      string ImportDescription,
      bool SwapSPN,
      string Category)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@ImportID", (object) ImportID, true);
      this._database.AddParameter("@Exclude", (object) Exclude, true);
      this._database.AddParameter("@ForceInsert", (object) ForceInsert, true);
      this._database.AddParameter("@ImportPrice", (object) ImportPrice, true);
      this._database.AddParameter("@ImportDesc", (object) ImportDescription, true);
      this._database.AddParameter("@SwapSPN", (object) SwapSPN, true);
      this._database.AddParameter("@Category", (object) Category, true);
      this._database.ExecuteSP_NO_Return(nameof (Parts_PreImportChange), true);
    }

    public void Parts_UpdatePart(int ImportID, string ImportDescription, string ExistingSPC)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@ImportID", (object) ImportID, true);
      this._database.AddParameter("@ImportDesc", (object) ImportDescription, true);
      this._database.AddParameter("@NewExistingSPC", (object) ExistingSPC, true);
      this._database.AddParameter("@UserID", (object) App.loggedInUser.UserID, true);
      this._database.ExecuteSP_NO_Return("Parts_PreImportUpdatePart", true);
    }

    public DataTable Parts_PreImportStats()
    {
      this._database.ClearParameter();
      DataTable dataTable = this._database.ExecuteSP_DataTable(nameof (Parts_PreImportStats), true);
      dataTable.TableName = nameof (Parts_PreImportStats);
      return dataTable;
    }

    public void POInvoice_ClearImportTables()
    {
      this._database.ClearParameter();
      this._database.ExecuteSP_NO_Return("POInvoiceImport_ClearImportTables", true);
    }

    public void POInvoiceImport_ClearRecordFromImportTables(
      string PurchaseOrderNo,
      string InvoiceNo)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@PurchaseOrderNo", (object) PurchaseOrderNo, true);
      this._database.AddParameter("@InvoiceNo", (object) InvoiceNo, true);
      this._database.ExecuteSP_NO_Return(nameof (POInvoiceImport_ClearRecordFromImportTables), true);
    }

    public int POInvoiceImport_InsertOrder(
      string InvoiceNo,
      DateTime InvoiceDate,
      string PurchaseOrderNo,
      int SupplierID,
      string OrderType,
      string nominalCode = null)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@InvoiceNo", (object) InvoiceNo, true);
      this._database.AddParameter("@InvoiceDate", (object) InvoiceDate, true);
      this._database.AddParameter("@PurchaseOrderNo", (object) PurchaseOrderNo, true);
      this._database.AddParameter("@SupplierID", (object) SupplierID, true);
      this._database.AddParameter("@NoOfParts", (object) 0, true);
      this._database.AddParameter("@TotalUnitPrice", (object) 0, true);
      this._database.AddParameter("@TotalNetAmount", (object) 0, true);
      this._database.AddParameter("@TotalVATAmount", (object) 0, true);
      this._database.AddParameter("@TotalGrossAmount", (object) 0, true);
      this._database.AddParameter("@OrderType", (object) OrderType, true);
      this._database.AddParameter("@NominalCode", (object) nominalCode, true);
      return Conversions.ToInteger(this._database.ExecuteSP_OBJECT(nameof (POInvoiceImport_InsertOrder), true));
    }

    public void POInvoiceImport_InsertPart(
      string PurchaseOrderNo,
      string SupplierPartCode,
      string Description,
      int Quantity,
      double UnitPrice,
      double NetAmount,
      double VATAmount,
      double GrossAmount,
      string InvoiceNo)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@PurchaseOrderNo", (object) PurchaseOrderNo, true);
      this._database.AddParameter("@SupplierPartCode", (object) SupplierPartCode, true);
      this._database.AddParameter("@Description", (object) Description, true);
      this._database.AddParameter("@Quantity", (object) Quantity, true);
      this._database.AddParameter("@UnitPrice", (object) UnitPrice, true);
      this._database.AddParameter("@NetAmount", (object) NetAmount, true);
      this._database.AddParameter("@VATAmount", (object) VATAmount, true);
      this._database.AddParameter("@GrossAmount", (object) GrossAmount, true);
      this._database.AddParameter("@InvoiceNo", (object) InvoiceNo, true);
      this._database.ExecuteSP_NO_Return(nameof (POInvoiceImport_InsertPart), true);
    }

    public int Orders_GetID(string poNumber, string supplierId, string invoiceNumber)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@PurchaseOrderNo", (object) poNumber, true);
      this._database.AddParameter("@SupplierID", (object) supplierId, true);
      this._database.AddParameter("@InvoiceNo", (object) invoiceNumber, true);
      return Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("POInvoiceImport_Orders_GetID", true)));
    }

    public void POInvoiceImport_UpdateOrderTotals(
      string PurchaseOrderNo,
      int NoOfParts,
      double TotalUnitPrice,
      double TotalNetAmount,
      double TotalVATAmount,
      double TotalGrossAmount,
      int TotalQtyOfParts,
      string InvoiceNo)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@PurchaseOrderNo", (object) PurchaseOrderNo, true);
      this._database.AddParameter("@NoOfParts", (object) NoOfParts, true);
      this._database.AddParameter("@TotalUnitPrice", (object) TotalUnitPrice, true);
      this._database.AddParameter("@TotalNetAmount", (object) TotalNetAmount, true);
      this._database.AddParameter("@TotalVATAmount", (object) TotalVATAmount, true);
      this._database.AddParameter("@TotalGrossAmount", (object) TotalGrossAmount, true);
      this._database.AddParameter("@TotalQtyOfParts", (object) TotalQtyOfParts, true);
      this._database.AddParameter("@InvoiceNo", (object) InvoiceNo, true);
      this._database.ExecuteSP_NO_Return(nameof (POInvoiceImport_UpdateOrderTotals), true);
    }

    public void POInvoiceImport_ValidateOrders(int ValidateType = 0)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@ValidateType", (object) ValidateType, true);
      this._database.ExecuteSP_NO_Return("POInvoiceImport_ValidateOrders_Test", true);
    }

    public void POInvoiceImport_UpdatePurchaseOrderNoAndValidate(
      int ImportID,
      string PurchaseOrderNo)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@ID", (object) ImportID, true);
      this._database.AddParameter("@PurchaseOrderNo", (object) PurchaseOrderNo, true);
      this._database.ExecuteSP_NO_Return(nameof (POInvoiceImport_UpdatePurchaseOrderNoAndValidate), true);
    }

    public bool POInvoiceImport_ValidateOrder(int ImportID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@ID", (object) ImportID, true);
      int num = this._database.ExecuteSP_ReturnRowsAffected("POInvoiceImport_ValidateOrder_Mk1");
      bool flag = false;
      if (num == 1)
        flag = true;
      return flag;
    }

    public DataView POInvoiceImport_ShowData(int ValidateResult = 0)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@ValidateResult", (object) ValidateResult, true);
      DataTable table = this._database.ExecuteSP_DataTable(nameof (POInvoiceImport_ShowData), true);
      table.TableName = nameof (POInvoiceImport_ShowData);
      return new DataView(table);
    }

    public DataView POInvoiceImport_ShowData_Mk1()
    {
      this._database.ClearParameter();
      DataTable table = this._database.ExecuteSP_DataTable(nameof (POInvoiceImport_ShowData_Mk1), true);
      table.TableName = "POInvoiceImport_ShowData";
      return new DataView(table);
    }

    public DataView POInvoiceImport_GetOrdersWithNoParts(int ValidateResult)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@ValidateResult", (object) ValidateResult, true);
      DataTable table = this._database.ExecuteSP_DataTable(nameof (POInvoiceImport_GetOrdersWithNoParts), true);
      table.TableName = nameof (POInvoiceImport_GetOrdersWithNoParts);
      return new DataView(table);
    }

    public void POInvoiceImport_UpdateExclude(int ID, bool Exclude)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@ID", (object) ID, true);
      this._database.AddParameter("@Exclude", (object) Exclude, true);
      this._database.ExecuteSP_NO_Return(nameof (POInvoiceImport_UpdateExclude), true);
    }

    public void POInvoiceImport_UpdateRequiresAuthorisation(int ID, bool RequiresAuth)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@ID", (object) ID, true);
      this._database.AddParameter("@RequiresAuth", (object) RequiresAuth, true);
      this._database.ExecuteSP_NO_Return(nameof (POInvoiceImport_UpdateRequiresAuthorisation), true);
    }

    public void Order_UpdateSupplier(int OrderID, int SupplierID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@OrderID", (object) OrderID, true);
      this._database.AddParameter("@SupplierID", (object) SupplierID, true);
      this._database.ExecuteSP_NO_Return(nameof (Order_UpdateSupplier), true);
    }

    public void POInvoiceImport_UpdateSupplierInvoiceCreated(int ID, bool InvoiceCreated)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@ID", (object) ID, true);
      this._database.AddParameter("@SupplierInvoiceCreated", (object) InvoiceCreated, true);
      this._database.ExecuteSP_NO_Return(nameof (POInvoiceImport_UpdateSupplierInvoiceCreated), true);
    }

    public void POInvoiceImport_UpdateDelete(int ID, bool ToBeDeleted)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@ID", (object) ID, true);
      this._database.AddParameter("@ToBeDeleted", (object) ToBeDeleted, true);
      this._database.ExecuteSP_NO_Return(nameof (POInvoiceImport_UpdateDelete), true);
    }

    public DataView POInvoiceImport_ShowPOParts(string PurchaseOrderNo, string InvoiceNo)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@PurchaseOrderNo", (object) PurchaseOrderNo, true);
      this._database.AddParameter("@InvoiceNo", (object) InvoiceNo, true);
      DataTable table = this._database.ExecuteSP_DataTable(nameof (POInvoiceImport_ShowPOParts), true);
      table.TableName = "POInvoiceImport_Parts";
      return new DataView(table);
    }

    public DataView POInvoiceImport_GetPOParts(string PurchaseOrderNo, string InvoiceNo)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@PurchaseOrderNo", (object) PurchaseOrderNo, true);
      this._database.AddParameter("@InvoiceNo", (object) InvoiceNo, true);
      DataTable table = this._database.ExecuteSP_DataTable("POInvoiceImport_ShowPOParts", true);
      table.TableName = "POInvoiceImport_Parts";
      return new DataView(table);
    }

    public void POInvoiceImport_AddSupplierInvoiceDetailToPO(string PurchaseOrderNo)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@PurchaseOrderNo", (object) PurchaseOrderNo, true);
      this._database.ExecuteSP_NO_Return("Parts_PreImportValidate", true);
    }

    public void POInvoiceImport_UpdateValidationType(int ID, int ValidateResult = 0)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@ID", (object) ID, true);
      this._database.AddParameter("@ValidateResult", (object) ValidateResult, true);
      this._database.ExecuteSP_NO_Return("POInvoiceImport_UpdateValidateResult", true);
    }

    public void POInvoiceImport_UpdateFailedPart(int ID, bool Failed)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@ID", (object) ID, true);
      this._database.AddParameter("@Failed", (object) Failed, true);
      this._database.ExecuteSP_NO_Return(nameof (POInvoiceImport_UpdateFailedPart), true);
    }

    public void POInvoiceImport_UpdatePartQty(int PartID, int PartQty)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@ID", (object) PartID, true);
      this._database.AddParameter("@Quantity", (object) PartQty, true);
      this._database.ExecuteSP_NO_Return(nameof (POInvoiceImport_UpdatePartQty), true);
    }

    public void POInvoiceImport_UpdatePartUnitPrice(int PartID, double PartUnitPrice)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@ID", (object) PartID, true);
      this._database.AddParameter("@UnitPrice", (object) PartUnitPrice, true);
      this._database.ExecuteSP_NO_Return(nameof (POInvoiceImport_UpdatePartUnitPrice), true);
    }

    public void POInvoiceImport_UpdateOrderTotalsAfterPartChange(
      string PurchaseOrderNo,
      string InvoiceNo)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@PurchaseOrderNo", (object) PurchaseOrderNo, true);
      this._database.AddParameter("@InvoiceNo", (object) InvoiceNo, true);
      this._database.ExecuteSP_NO_Return(nameof (POInvoiceImport_UpdateOrderTotalsAfterPartChange), true);
    }

    public int POInvoiceImport_CheckImportHasBeenSent(
      string InvoiceNo,
      DateTime InvoiceDate,
      string SupplierPartCode)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@InvoiceNumber", (object) InvoiceNo, true);
      this._database.AddParameter("@InvoiceDate", (object) InvoiceDate, true);
      this._database.AddParameter("@SupplierPartCode", (object) SupplierPartCode, true);
      return Conversions.ToInteger(this._database.ExecuteScalar("SELECT COUNT(*) AS Expr1 FROM tblPOInvoiceImport_Orders LEFT OUTER JOIN tblPOInvoiceImport_Parts ON tblPOInvoiceImport_Orders.InvoiceNo = tblPOInvoiceImport_Parts.InvoiceNo WHERE (tblPOInvoiceImport_Orders.InvoiceNo = @InvoiceNumber) AND (tblPOInvoiceImport_Orders.InvoiceDate = @InvoiceDate) AND (tblPOInvoiceImport_Parts.SupplierPartCode = @SupplierPartCode) AND (tblPOInvoiceImport_Orders.SupplierInvoiceCreated = 1)", false, false));
    }

    public int POInvoiceImport_CheckImportInvoiceExists(
      string InvoiceNo,
      DateTime InvoiceDate,
      string SupplierPartCode)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@InvoiceNumber", (object) InvoiceNo, true);
      this._database.AddParameter("@InvoiceDate", (object) InvoiceDate, true);
      this._database.AddParameter("@SupplierPartCode", (object) SupplierPartCode, true);
      return Conversions.ToInteger(this._database.ExecuteScalar("SELECT COUNT(*) AS Expr1 FROM tblPOInvoiceImport_Orders LEFT OUTER JOIN tblPOInvoiceImport_Parts ON tblPOInvoiceImport_Orders.InvoiceNo = tblPOInvoiceImport_Parts.InvoiceNo WHERE (tblPOInvoiceImport_Orders.InvoiceNo = @InvoiceNumber) AND (tblPOInvoiceImport_Orders.InvoiceDate = @InvoiceDate) AND (tblPOInvoiceImport_Parts.SupplierPartCode = @SupplierPartCode) ", false, false));
    }

    public int POInvoiceImport_ValidatePart(int SupplierID, string PartCode)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@SupplierID", (object) SupplierID, true);
      this._database.AddParameter("@PartCode", (object) PartCode, true);
      return Conversions.ToInteger(this._database.ExecuteScalar("SELECT COUNT(*)\tFROM tblPart INNER JOIN tblPartSupplier ON tblPart.PartID = tblPartSupplier.PartID WHERE (tblPartSupplier.Deleted IS NULL OR tblPartSupplier.Deleted = 0) AND (tblPart.Deleted IS NULL OR tblPart.Deleted = 0) AND (tblPartSupplier.SupplierID = @SupplierID) AND (tblPartSupplier.PartCode = @PartCode)", false, false));
    }

    public int POInvoiceImport_GetPartID(int SupplierID, string PartCode)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@SupplierID", (object) SupplierID, true);
      this._database.AddParameter("@PartCode", (object) PartCode, true);
      return Conversions.ToInteger(this._database.ExecuteScalar("SELECT tblPart.PartID FROM tblPart INNER JOIN tblPartSupplier ON tblPart.PartID = tblPartSupplier.PartID WHERE (tblPart.Deleted IS NULL OR tblPart.Deleted = 0) AND (tblPartSupplier.SupplierID = @SupplierID) AND (tblPartSupplier.PartCode = @PartCode) GROUP BY tblPart.PartID", false, false));
    }

    public int POInvoiceImport_GetOrderStatus(int OrderID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@OrderID", (object) OrderID, true);
      return Conversions.ToInteger(this._database.ExecuteScalar("SELECT OrderStatusID FROM tblOrder WHERE (OrderID = @OrderID)", false, false));
    }

    public void PartsOrderedImport_ClearImportTable()
    {
      this._database.ClearParameter();
      this._database.ExecuteSP_NO_Return(nameof (PartsOrderedImport_ClearImportTable), true);
    }

    public int Parts_CheckPartsOrderedImportCount()
    {
      this._database.ClearParameter();
      return Conversions.ToInteger(this._database.ExecuteScalar("SELECT COUNT(*) FROM tblPartsOrderedImport", false, false));
    }

    public int PartsOrderedImport_CheckImportExists(
      string InvoiceNo,
      DateTime InvoiceDate,
      string PurchaseOrderNo,
      string SupplierPartCode,
      string Description,
      int Quantity)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@SupplierOrderNumber", (object) InvoiceNo, true);
      this._database.AddParameter("@OrderDate", (object) InvoiceDate, true);
      this._database.AddParameter("@PurchaseOrderNumber", (object) PurchaseOrderNo, true);
      this._database.AddParameter("@SupplierPartCode", (object) SupplierPartCode, true);
      this._database.AddParameter("@Description", (object) Description, true);
      this._database.AddParameter("@Quantity", (object) Quantity, true);
      return Conversions.ToInteger(this._database.ExecuteScalar("SELECT COUNT(*) AS Expr1 FROM tblPartsOrderedImport WHERE (SupplierOrderNumber = @SupplierOrderNumber) AND (OrderDate = @OrderDate) AND (PurchaseOrderNumber = @PurchaseOrderNumber) AND (SupplierPartCode = @SupplierPartCode) AND (Description = @Description) AND (Quantity = @Quantity)", false, false));
    }

    public void PartsOrderedImport_InsertPart(
      string SupplierOrderNumber,
      DateTime OrderDate,
      string PurchaseOrderNumber,
      string SupplierPartCode,
      string Description,
      int Quantity,
      int SupplierID,
      int ImportedByUserID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@SupplierOrderNumber", (object) SupplierOrderNumber, true);
      this._database.AddParameter("@OrderDate", (object) OrderDate, true);
      this._database.AddParameter("@PurchaseOrderNumber", (object) PurchaseOrderNumber, true);
      this._database.AddParameter("@SupplierPartCode", (object) SupplierPartCode, true);
      this._database.AddParameter("@Description", (object) Description, true);
      this._database.AddParameter("@Quantity", (object) Quantity, true);
      this._database.AddParameter("@SupplierID", (object) SupplierID, true);
      this._database.AddParameter("@ImportedByUserID", (object) ImportedByUserID, true);
      this._database.ExecuteSP_NO_Return(nameof (PartsOrderedImport_InsertPart), true);
    }

    public DataView PartsOrderedImport_GetAllUnprocessedParts()
    {
      this._database.ClearParameter();
      DataTable table = this._database.ExecuteSP_DataTable(nameof (PartsOrderedImport_GetAllUnprocessedParts), true);
      table.TableName = "tblPartsOrderedImport";
      return new DataView(table);
    }

    public DataView PartsOrderedImport_RevalidateRecords(int ValidateType)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@ValidateType", (object) ValidateType, true);
      DataTable table = this._database.ExecuteSP_DataTable("PartsOrderedImport_ReValidateRecords", true);
      table.TableName = "tblPartsOrderedImport";
      return new DataView(table);
    }

    public int PartsOrderedImport_ValidatePart(int SupplierID, string PartCode)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@SupplierID", (object) SupplierID, true);
      this._database.AddParameter("@PartCode", (object) PartCode, true);
      return Conversions.ToInteger(this._database.ExecuteScalar("SELECT COUNT(*)\tFROM tblPart INNER JOIN tblPartSupplier ON tblPart.PartID = tblPartSupplier.PartID WHERE (tblPart.Deleted IS NULL OR tblPart.Deleted = 0) AND (tblPartSupplier.SupplierID = @SupplierID) AND (tblPartSupplier.PartCode = @PartCode)", false, false));
    }

    public void PartsOrderedImport_UpdateProcessed(int ID, bool Processed)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@ID", (object) ID, true);
      this._database.AddParameter("@Processed", (object) Processed, true);
      this._database.ExecuteSP_NO_Return(nameof (PartsOrderedImport_UpdateProcessed), true);
    }

    public void PartsOrderedImport_UpdateExclude(int ID, bool Exclude)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@ID", (object) ID, true);
      this._database.AddParameter("@Exclude", (object) Exclude, true);
      this._database.ExecuteSP_NO_Return(nameof (PartsOrderedImport_UpdateExclude), true);
    }

    public void PartsOrderedImport_UpdateValidateType(int ID, int ValidateType)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@ID", (object) ID, true);
      this._database.AddParameter("@ValidateType", (object) ValidateType, true);
      this._database.ExecuteSP_NO_Return(nameof (PartsOrderedImport_UpdateValidateType), true);
    }

    public DataView PartsOrderedImport_ShowData(int ValidateResult = 0)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@ValidateType", (object) ValidateResult, true);
      DataTable table = this._database.ExecuteSP_DataTable(nameof (PartsOrderedImport_ShowData), true);
      table.TableName = "PartsOrderedImport";
      return new DataView(table);
    }

    public void PartsOrderedImport_UpdatePurchaseOrderNumber(
      int ImportID,
      string PurchaseOrderNumber)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@ID", (object) ImportID, true);
      this._database.AddParameter("@PurchaseOrderNumber", (object) PurchaseOrderNumber, true);
      this._database.ExecuteSP_NO_Return(nameof (PartsOrderedImport_UpdatePurchaseOrderNumber), true);
    }

    public void PartsOrderedImport_UpdateSupplierPartCode(int ImportID, string SupplierPartCode)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@ID", (object) ImportID, true);
      this._database.AddParameter("@SupplierPartCode", (object) SupplierPartCode, true);
      this._database.ExecuteSP_NO_Return(nameof (PartsOrderedImport_UpdateSupplierPartCode), true);
    }

    public int PartsOrderedImport_GetPartID(int SupplierID, string PartCode)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@SupplierID", (object) SupplierID, true);
      this._database.AddParameter("@PartCode", (object) PartCode, true);
      return Conversions.ToInteger(this._database.ExecuteScalar("SELECT tblPart.PartID FROM tblPart INNER JOIN tblPartSupplier ON tblPart.PartID = tblPartSupplier.PartID WHERE (tblPart.Deleted IS NULL OR tblPart.Deleted = 0) AND (tblPartSupplier.SupplierID = @SupplierID) AND (tblPartSupplier.PartCode = @PartCode) GROUP BY tblPart.PartID", false, false));
    }

    public void PartsOrderedImport_UpdateDelete(int ID, bool ToBeDeleted)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@ID", (object) ID, true);
      this._database.AddParameter("@ToBeDeleted", (object) ToBeDeleted, true);
      this._database.ExecuteSP_NO_Return(nameof (PartsOrderedImport_UpdateDelete), true);
    }

    public void PartsOrderedImport_ClearRecordFromImportTables(int ID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@ID", (object) ID, true);
      this._database.ExecuteSP_NO_Return(nameof (PartsOrderedImport_ClearRecordFromImportTables), true);
    }

    public int Parts_CheckPartsInvoiceImportCount()
    {
      this._database.ClearParameter();
      return Conversions.ToInteger(this._database.ExecuteScalar("SELECT COUNT(*) FROM tblPartsInvoiceImport", false, false));
    }

    public void Parts_PartsInvoiceImportData(
      string InvoiceNo,
      DateTime InvoiceDate,
      string PurchaseOrderNo,
      string Engineer,
      string SiteAddress,
      string OrderType,
      string SupplierPartCode,
      string Description,
      int Quantity,
      double UnitPrice,
      double NetAmount,
      double VATAmount,
      double GrossAmount)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@InvoiceNo", (object) InvoiceNo, true);
      this._database.AddParameter("@InvoiceDate", (object) InvoiceDate, true);
      this._database.AddParameter("@PurchaseOrderNo", (object) PurchaseOrderNo, true);
      this._database.AddParameter("@Engineer", (object) Engineer, true);
      this._database.AddParameter("@SiteAddress", (object) SiteAddress, true);
      this._database.AddParameter("@OrderType", (object) OrderType, true);
      this._database.AddParameter("@SupplierPartCode", (object) SupplierPartCode, true);
      this._database.AddParameter("@Description", (object) Description, true);
      this._database.AddParameter("@Quantity", (object) Quantity, true);
      this._database.AddParameter("@UnitPrice", (object) UnitPrice, true);
      this._database.AddParameter("@NetAmount", (object) NetAmount, true);
      this._database.AddParameter("@VATAmount", (object) VATAmount, true);
      this._database.AddParameter("@GrossAmount", (object) GrossAmount, true);
      this._database.ExecuteSP_NO_Return("Parts_PartsInvoiceImport_Insert", true);
    }

    public DataView Parts_PartsInvoiceImport_ShowResults(int ValidateResult = 0)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@ValidateResult", (object) ValidateResult, true);
      DataTable table = this._database.ExecuteSP_DataTable(nameof (Parts_PartsInvoiceImport_ShowResults), true);
      table.TableName = nameof (Parts_PartsInvoiceImport_ShowResults);
      return new DataView(table);
    }

    public int Parts_ClearPartsInvoiceImportTable()
    {
      this._database.ClearParameter();
      return Conversions.ToInteger(this._database.ExecuteScalar("DELETE FROM tblPartsInvoiceImport", true, false));
    }

    public void Parts_PartsInvoiceImport_UpdateExclude(int ID, bool Exclude)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@ID", (object) ID, true);
      this._database.AddParameter("@Exclude", (object) Exclude, true);
      this._database.ExecuteSP_NO_Return(nameof (Parts_PartsInvoiceImport_UpdateExclude), true);
    }

    public void Parts_PartsInvoiceImport_ValidateImportData(int ValidateType = 0)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@ValidateType", (object) ValidateType, true);
      this._database.ExecuteSP_NO_Return("Parts_PartsInvoiceImport_Validate", true);
    }

    public void BulkInsert(DataTable dt)
    {
      SqlConnection connection = new SqlConnection(App.TheSystem.Configuration.ConnectionString);
      connection.Open();
      using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(connection))
      {
        sqlBulkCopy.ColumnMappings.Add(0, 2);
        sqlBulkCopy.ColumnMappings.Add(1, 3);
        sqlBulkCopy.ColumnMappings.Add(2, 4);
        sqlBulkCopy.ColumnMappings.Add(3, 7);
        sqlBulkCopy.ColumnMappings.Add(4, 8);
        sqlBulkCopy.ColumnMappings.Add(5, 15);
        sqlBulkCopy.ColumnMappings.Add(6, 5);
        sqlBulkCopy.DestinationTableName = "tblPartsPreImport";
        sqlBulkCopy.WriteToServer(dt);
      }
      connection.Close();
    }
  }
}
