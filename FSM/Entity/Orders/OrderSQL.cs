// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Orders.OrderSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.OrderParts;
using FSM.Entity.PartsToBeCrediteds;
using FSM.Entity.PartSuppliers;
using FSM.Entity.PartTransactions;
using FSM.Entity.ProductTransactions;
using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace FSM.Entity.Orders
{
  public class OrderSQL
  {
    private Database _database;

    public OrderSQL(Database database)
    {
      this._database = database;
    }

    public DataView Order_CheckReference(string OrderRef)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@OrderReference", (object) OrderRef, true);
      DataTable table = this._database.ExecuteSP_DataTable(nameof (Order_CheckReference), true);
      table.TableName = Enums.TableNames.tblOrder.ToString();
      return new DataView(table);
    }

    public DataView Order_ItemsGetAll(int OrderID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@OrderID", (object) OrderID, true);
      DataTable table = this._database.ExecuteSP_DataTable(nameof (Order_ItemsGetAll), true);
      table.TableName = Enums.TableNames.tblOrder.ToString();
      return new DataView(table);
    }

    public DataView OrderSupplierItemsForPrint_Get(int OrderID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@OrderID", (object) OrderID, true);
      DataTable table = this._database.ExecuteSP_DataTable(nameof (OrderSupplierItemsForPrint_Get), true);
      table.TableName = Enums.TableNames.tblOrder.ToString();
      return new DataView(table);
    }

    public DataTable OrderItemsForPrint_Get(int OrderID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@OrderID", (object) OrderID, true);
      DataTable dataTable = this._database.ExecuteSP_DataTable(nameof (OrderItemsForPrint_Get), true);
      dataTable.TableName = Enums.TableNames.tblOrder.ToString();
      return dataTable;
    }

    public void Delete(int OrderID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@OrderID", (object) OrderID, true);
      this._database.ExecuteSP_NO_Return("Order_Delete", true);
    }

    public void Delete(int OrderID, SqlTransaction trans)
    {
      new SqlCommand()
      {
        CommandText = "Order_Delete",
        CommandType = CommandType.StoredProcedure,
        Transaction = trans,
        Connection = trans.Connection,
        Parameters = {
          new SqlParameter("@OrderID", (object) OrderID)
        }
      }.ExecuteNonQuery();
    }

    public void PermanentDelete(int OrderID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@OrderID", (object) OrderID, true);
      this._database.ExecuteSP_NO_Return("Order_PermanentDelete", true);
    }

    public Order Order_Get(int OrderID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@OrderID", (object) OrderID, false);
      this._database.AddParameter("@OrderInvoiceTypeID", (object) 261, false);
      this._database.AddParameter("@VisitInvoiceTypeID", (object) 260, false);
      DataTable dataTable = this._database.ExecuteSP_DataTable(nameof (Order_Get), true);
      if (dataTable == null || dataTable.Rows.Count <= 0)
        return (Order) null;
      Order order1 = new Order();
      Order order2 = order1;
      order2.IgnoreExceptionsOnSetMethods = true;
      order2.SetOrderID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0][nameof (OrderID)]);
      order2.DatePlaced = Conversions.ToDate(dataTable.Rows[0]["DatePlaced"]);
      order2.SetOrderTypeID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["OrderTypeID"]);
      order2.SetOrderReference = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["OrderReference"]);
      order2.SetUserID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["UserID"]);
      order2.SetOrderStatusID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["OrderStatusID"]);
      order2.SetReasonForReject = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ReasonForReject"]);
      order2.DeliveryDeadline = Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["DeliveryDeadline"])) ? DateTime.MinValue : Conversions.ToDate(dataTable.Rows[0]["DeliveryDeadline"]);
      order2.SetSentToSage = (object) Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SentToSage"]));
      order2.SetSupplierInvoiceAmount = (object) Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SupplierInvoiceAmount"]));
      order2.SetSupplierInvoiceReference = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SupplierInvoiceReference"]));
      order2.SupplierInvoiceDate = Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SupplierInvoiceDate"])) ? DateTime.MinValue : Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SupplierInvoiceDate"]));
      order2.SetSpecialInstructions = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SpecialInstructions"]));
      order2.SetContactID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ContactID"]));
      order2.SetInvoiceAddressID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["InvoiceAddressID"]));
      order2.SetAllocatedToUser = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["AllocatedToUser"]));
      order2.SetDeleted = Conversions.ToBoolean(dataTable.Rows[0]["Deleted"]);
      order2.SetInvoiced = Conversions.ToBoolean(dataTable.Rows[0]["Invoiced"]);
      order2.SetExportedToSage = Conversions.ToBoolean(dataTable.Rows[0]["ExportedToSage"]);
      order2.SetNominalCode = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["NominalCode"]));
      order2.SetDepartmentRef = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["DepartmentRef"]));
      order2.SetExtraRef = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ExtraRef"]));
      order2.SetTaxCodeID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["TaxCodeID"]));
      order2.SetReadyToSendToSage = Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ReadyToSendToSage"]));
      order2.SetOrderConsolidationID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["OrderConsolidationID"]));
      order2.SetVATAmount = (object) Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["VATAmount"]));
      order2.SetDoNotConsolidated = (object) Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["DoNotConsolidated"]));
      order1.Exists = true;
      return order1;
    }

    public Order Order_Get(int OrderID, SqlTransaction trans)
    {
      SqlCommand selectCommand = new SqlCommand();
      selectCommand.CommandText = nameof (Order_Get);
      selectCommand.CommandType = CommandType.StoredProcedure;
      selectCommand.Transaction = trans;
      selectCommand.Connection = trans.Connection;
      selectCommand.Parameters.AddWithValue("@OrderID", (object) OrderID);
      selectCommand.Parameters.AddWithValue("@OrderInvoiceTypeID", (object) 261);
      selectCommand.Parameters.AddWithValue("@VisitInvoiceTypeID", (object) 260);
      SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
      DataSet dataSet = new DataSet();
      sqlDataAdapter.Fill(dataSet);
      DataTable table = dataSet.Tables[0];
      if (table == null || table.Rows.Count <= 0)
        return (Order) null;
      Order order1 = new Order();
      Order order2 = order1;
      order2.IgnoreExceptionsOnSetMethods = true;
      order2.SetOrderID = RuntimeHelpers.GetObjectValue(table.Rows[0][nameof (OrderID)]);
      order2.DatePlaced = Conversions.ToDate(table.Rows[0]["DatePlaced"]);
      order2.SetOrderTypeID = RuntimeHelpers.GetObjectValue(table.Rows[0]["OrderTypeID"]);
      order2.SetOrderReference = RuntimeHelpers.GetObjectValue(table.Rows[0]["OrderReference"]);
      order2.SetUserID = RuntimeHelpers.GetObjectValue(table.Rows[0]["UserID"]);
      order2.SetOrderStatusID = RuntimeHelpers.GetObjectValue(table.Rows[0]["OrderStatusID"]);
      order2.SetReasonForReject = RuntimeHelpers.GetObjectValue(table.Rows[0]["ReasonForReject"]);
      order2.DeliveryDeadline = Information.IsDBNull(RuntimeHelpers.GetObjectValue(table.Rows[0]["DeliveryDeadline"])) ? DateTime.MinValue : Conversions.ToDate(table.Rows[0]["DeliveryDeadline"]);
      order2.SetSentToSage = (object) Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(table.Rows[0]["SentToSage"]));
      order2.SetSupplierInvoiceAmount = (object) Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(table.Rows[0]["SupplierInvoiceAmount"]));
      order2.SetSupplierInvoiceReference = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(table.Rows[0]["SupplierInvoiceReference"]));
      order2.SupplierInvoiceDate = Information.IsDBNull(RuntimeHelpers.GetObjectValue(table.Rows[0]["SupplierInvoiceDate"])) ? DateTime.MinValue : Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(table.Rows[0]["SupplierInvoiceDate"]));
      order2.SetSpecialInstructions = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(table.Rows[0]["SpecialInstructions"]));
      order2.SetContactID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(table.Rows[0]["ContactID"]));
      order2.SetInvoiceAddressID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(table.Rows[0]["InvoiceAddressID"]));
      order2.SetAllocatedToUser = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(table.Rows[0]["AllocatedToUser"]));
      order2.SetDeleted = Conversions.ToBoolean(table.Rows[0]["Deleted"]);
      order2.SetInvoiced = Conversions.ToBoolean(table.Rows[0]["Invoiced"]);
      order2.SetExportedToSage = Conversions.ToBoolean(table.Rows[0]["ExportedToSage"]);
      order2.SetNominalCode = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(table.Rows[0]["NominalCode"]));
      order2.SetDepartmentRef = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(table.Rows[0]["DepartmentRef"]));
      order2.SetExtraRef = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(table.Rows[0]["ExtraRef"]));
      order2.SetTaxCodeID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(table.Rows[0]["TaxCodeID"]));
      order2.SetReadyToSendToSage = Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(table.Rows[0]["ReadyToSendToSage"]));
      order2.SetOrderConsolidationID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(table.Rows[0]["OrderConsolidationID"]));
      order2.SetVATAmount = (object) Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(table.Rows[0]["VATAmount"]));
      order2.SetDoNotConsolidated = (object) Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(table.Rows[0]["DoNotConsolidated"]));
      order1.Exists = true;
      return order1;
    }

    public DataView Order_Get_ByRef(string OrderReference)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@OrderReference", (object) OrderReference, true);
      DataTable table = this._database.ExecuteSP_DataTable(nameof (Order_Get_ByRef), true);
      table.TableName = Enums.TableNames.tblOrder.ToString();
      return new DataView(table);
    }

    public DataView Order_Get_ByRef(string OrderReference, SqlTransaction trans)
    {
      SqlCommand selectCommand = new SqlCommand();
      selectCommand.CommandText = nameof (Order_Get_ByRef);
      selectCommand.CommandType = CommandType.StoredProcedure;
      selectCommand.Transaction = trans;
      selectCommand.Connection = trans.Connection;
      selectCommand.Parameters.AddWithValue("@OrderReference", (object) OrderReference);
      SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
      DataSet dataSet = new DataSet();
      sqlDataAdapter.Fill(dataSet);
      DataTable table = dataSet.Tables[0];
      table.TableName = Enums.TableNames.tblOrder.ToString();
      return new DataView(table);
    }

    public DataView OrderPart_GetForOrder(int OrderID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@OrderID", (object) OrderID, true);
      DataTable table = this._database.ExecuteSP_DataTable(nameof (OrderPart_GetForOrder), true);
      table.TableName = Enums.TableNames.tblPartSupplier.ToString();
      return new DataView(table);
    }

    public DataView OrderPart_GetForOrder(int OrderID, SqlTransaction trans)
    {
      SqlCommand selectCommand = new SqlCommand();
      selectCommand.CommandText = nameof (OrderPart_GetForOrder);
      selectCommand.CommandType = CommandType.StoredProcedure;
      selectCommand.Transaction = trans;
      selectCommand.Connection = trans.Connection;
      selectCommand.Parameters.AddWithValue("@OrderID", (object) OrderID);
      SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
      DataSet dataSet = new DataSet();
      sqlDataAdapter.Fill(dataSet);
      DataTable table = dataSet.Tables[0];
      table.TableName = Enums.TableNames.tblPartSupplier.ToString();
      return new DataView(table);
    }

    public DataView OrderProduct_GetForOrder(int OrderID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@OrderID", (object) OrderID, true);
      DataTable table = this._database.ExecuteSP_DataTable(nameof (OrderProduct_GetForOrder), true);
      table.TableName = Enums.TableNames.tblProductSupplier.ToString();
      return new DataView(table);
    }

    public DataView Order_GetAll(string SearchCriteria)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@OrderInvoiceTypeID", (object) 261, false);
      this._database.AddParameter("@VisitInvoiceTypeID", (object) 260, false);
      this._database.AddParameter("@SearchCriteria", (object) SearchCriteria, true);
      DataTable table = this._database.ExecuteSP_DataTable(nameof (Order_GetAll), true);
      table.TableName = Enums.TableNames.tblOrder.ToString();
      return new DataView(table);
    }

    public DataView Order_GetAll_NEW(
      string SearchCriteria,
      int OrderSiteID,
      int OrderVanID,
      int OrderWarehouseID,
      int OrderJobID,
      int OrderTypeID,
      string OrderReference,
      string OrderConsolidationRef,
      int OrderStatus,
      int PartsNotReceived,
      int OrderSupplierExported,
      int OrderSupplierID,
      DateTime? OrderDatePlacedFrom,
      DateTime? OrderDatePlacedTo,
      DateTime? OrderDeliveryDeadlineFrom,
      DateTime? OrderDeliveryDeadlineTo,
      string OrderDepartment)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@OrderInvoiceTypeID", (object) 261, false);
      this._database.AddParameter("@VisitInvoiceTypeID", (object) 260, false);
      this._database.AddParameter("@SearchCriteria", (object) SearchCriteria, true);
      this._database.AddParameter("@OrderSiteID", (object) OrderSiteID, true);
      this._database.AddParameter("@OrderVanID", (object) OrderVanID, true);
      this._database.AddParameter("@OrderWarehouseID", (object) OrderWarehouseID, true);
      this._database.AddParameter("@OrderJobID", (object) OrderJobID, true);
      this._database.AddParameter("@PartsNotReceived", (object) PartsNotReceived, true);
      this._database.AddParameter("@OrderTypeID", (object) OrderTypeID, true);
      this._database.AddParameter("@OrderSupplierID", (object) OrderSupplierID, true);
      this._database.AddParameter("@OrderSupplierExported", (object) OrderSupplierExported, true);
      this._database.AddParameter("@OrderReference", (object) OrderReference, true);
      this._database.AddParameter("@OrderConsolidationRef", (object) OrderConsolidationRef, true);
      this._database.AddParameter("@OrderDatePlacedFrom", (object) OrderDatePlacedFrom, true);
      this._database.AddParameter("@OrderDatePlacedTo", (object) OrderDatePlacedTo, true);
      this._database.AddParameter("@OrderDeliveryDeadlineFrom", (object) OrderDeliveryDeadlineFrom, true);
      this._database.AddParameter("@OrderDeliveryDeadlineTo", (object) OrderDeliveryDeadlineTo, true);
      this._database.AddParameter("@OrderStatus", (object) OrderStatus, true);
      this._database.AddParameter("@OrderDepartment", (object) OrderDepartment, true);
      DataTable table = this._database.ExecuteSP_DataTable(nameof (Order_GetAll_NEW), true);
      table.TableName = Enums.TableNames.tblOrder.ToString();
      return new DataView(table);
    }

    public DataView Orders_GetForJob(int jobID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@jobID", (object) jobID, true);
      DataTable table = this._database.ExecuteSP_DataTable(nameof (Orders_GetForJob), true);
      table.TableName = Enums.TableNames.tblOrder.ToString();
      return new DataView(table);
    }

    public DataView Orders_GetJob(int orderID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@OrderID", (object) orderID, true);
      DataTable table = this._database.ExecuteSP_DataTable("Order_GetJob_OrderID", true);
      table.TableName = Enums.TableNames.tblOrder.ToString();
      return new DataView(table);
    }

    public DataView Orders_GetForItem(string Type, int ID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@Type", (object) Type, true);
      this._database.AddParameter("@ID", (object) ID, true);
      DataTable table = this._database.ExecuteSP_DataTable(nameof (Orders_GetForItem), true);
      table.TableName = Enums.TableNames.tblOrder.ToString();
      return new DataView(table);
    }

    public DataView Orders_GetForEngineerVisit(int EngineerVisitID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@EngineerVisitID", (object) EngineerVisitID, true);
      DataTable table = this._database.ExecuteSP_DataTable(nameof (Orders_GetForEngineerVisit), true);
      table.TableName = Enums.TableNames.tblOrder.ToString();
      return new DataView(table);
    }

    public DataView VanParts_GetForOrder(int OrderID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@OrderID", (object) OrderID, true);
      DataTable table = this._database.ExecuteSP_DataTable(nameof (VanParts_GetForOrder), true);
      table.TableName = Enums.TableNames.tblPart.ToString();
      return new DataView(table);
    }

    public DataView VanProducts_GetForOrder(int OrderID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@OrderID", (object) OrderID, true);
      DataTable table = this._database.ExecuteSP_DataTable(nameof (VanProducts_GetForOrder), true);
      table.TableName = Enums.TableNames.tblProduct.ToString();
      return new DataView(table);
    }

    public DataView WarehouseParts_GetForOrder(int OrderID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@OrderID", (object) OrderID, true);
      DataTable table = this._database.ExecuteSP_DataTable(nameof (WarehouseParts_GetForOrder), true);
      table.TableName = Enums.TableNames.tblPart.ToString();
      return new DataView(table);
    }

    public DataView WarehouseProducts_GetForOrder(int OrderID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@OrderID", (object) OrderID, true);
      DataTable table = this._database.ExecuteSP_DataTable(nameof (WarehouseProducts_GetForOrder), true);
      table.TableName = Enums.TableNames.tblProduct.ToString();
      return new DataView(table);
    }

    public Order Insert(Order oOrder)
    {
      this._database.ClearParameter();
      this.AddOrderParametersToCommand(ref oOrder);
      oOrder.SetOrderID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("Order_Insert", true)));
      oOrder.Exists = true;
      return oOrder;
    }

    public Order Insert(Order oOrder, SqlTransaction trans)
    {
      SqlCommand sqlCommand = new SqlCommand();
      sqlCommand.CommandText = "Order_Insert";
      sqlCommand.CommandType = CommandType.StoredProcedure;
      sqlCommand.Transaction = trans;
      sqlCommand.Connection = trans.Connection;
      sqlCommand.Parameters.AddWithValue("@DatePlaced", (object) oOrder.DatePlaced);
      sqlCommand.Parameters.AddWithValue("@OrderTypeID", (object) oOrder.OrderTypeID);
      sqlCommand.Parameters.AddWithValue("@OrderReference", (object) oOrder.OrderReference);
      sqlCommand.Parameters.AddWithValue("@UserID", (object) oOrder.UserID);
      sqlCommand.Parameters.AddWithValue("@OrderStatusID", (object) oOrder.OrderStatusID);
      sqlCommand.Parameters.AddWithValue("@ReasonForReject", (object) oOrder.ReasonForReject);
      if (DateTime.Compare(oOrder.DeliveryDeadline, DateTime.MinValue) == 0)
        sqlCommand.Parameters.AddWithValue("@DeliveryDeadline", (object) DBNull.Value);
      else
        sqlCommand.Parameters.AddWithValue("@DeliveryDeadline", (object) oOrder.DeliveryDeadline);
      sqlCommand.Parameters.AddWithValue("@SpecialInstructions", (object) oOrder.SpecialInstructions);
      sqlCommand.Parameters.AddWithValue("@ContactID", (object) oOrder.ContactID);
      sqlCommand.Parameters.AddWithValue("@InvoiceAddressID", (object) oOrder.InvoiceAddressID);
      sqlCommand.Parameters.AddWithValue("@AllocatedToUser", (object) oOrder.AllocatedToUser);
      sqlCommand.Parameters.AddWithValue("@DepartmentRef", (object) oOrder.DepartmentRef);
      sqlCommand.Parameters.AddWithValue("@DoNotConsolidated", (object) oOrder.DoNotConsolidated);
      oOrder.SetOrderID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(sqlCommand.ExecuteScalar()));
      oOrder.Exists = true;
      return oOrder;
    }

    public DataView Order_GetPartsSummaryForVan(int OrderID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@OrderID", (object) OrderID, true);
      DataTable table = this._database.ExecuteSP_DataTable(nameof (Order_GetPartsSummaryForVan), true);
      table.TableName = Enums.TableNames.tblOrder.ToString();
      return new DataView(table);
    }

    public DataView Order_GetProductsSummaryForVan(int OrderID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@OrderID", (object) OrderID, true);
      DataTable table = this._database.ExecuteSP_DataTable(nameof (Order_GetProductsSummaryForVan), true);
      table.TableName = Enums.TableNames.tblOrder.ToString();
      return new DataView(table);
    }

    public DataView Order_GetPartsSummaryForWarehouse(int OrderID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@OrderID", (object) OrderID, true);
      DataTable table = this._database.ExecuteSP_DataTable(nameof (Order_GetPartsSummaryForWarehouse), true);
      table.TableName = Enums.TableNames.tblOrder.ToString();
      return new DataView(table);
    }

    public DataView Order_GetProductsSummaryForWarehouse(int OrderID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@OrderID", (object) OrderID, true);
      DataTable table = this._database.ExecuteSP_DataTable(nameof (Order_GetProductsSummaryForWarehouse), true);
      table.TableName = Enums.TableNames.tblOrder.ToString();
      return new DataView(table);
    }

    public DataView Order_SearchList(string criteria)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@Criteria", (object) criteria, true);
      DataTable table = this._database.ExecuteSP_DataTable(nameof (Order_SearchList), true);
      table.TableName = Enums.TableNames.tblOrder.ToString();
      return new DataView(table);
    }

    public DataView Order_PriceRequests_GetAll(int OrderID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@OrderID", (object) OrderID, true);
      DataTable table = this._database.ExecuteSP_DataTable(nameof (Order_PriceRequests_GetAll), true);
      table.TableName = Enums.TableNames.NOT_IN_DATABASE_PriceRequests.ToString();
      return new DataView(table);
    }

    public void Update(Order oOrder)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@OrderID", (object) oOrder.OrderID, true);
      this.AddOrderParametersToCommand(ref oOrder);
      this._database.AddParameter("@Reason", (object) oOrder.Reason, true);
      this._database.ExecuteSP_NO_Return("Order_Update", true);
    }

    public void Update_OrderRef(int orderId, string orderRef)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@OrderID", (object) orderId, true);
      this._database.AddParameter("@OrderRef", (object) orderRef, true);
      this._database.ExecuteSP_NO_Return("Order_Update_OrderReference", true);
    }

    private void AddOrderParametersToCommand(ref Order oOrder)
    {
      Database database = this._database;
      database.AddParameter("@DatePlaced", (object) oOrder.DatePlaced, true);
      database.AddParameter("@OrderTypeID", (object) oOrder.OrderTypeID, true);
      database.AddParameter("@OrderReference", (object) oOrder.OrderReference, true);
      database.AddParameter("@UserID", (object) oOrder.UserID, true);
      database.AddParameter("@OrderStatusID", (object) oOrder.OrderStatusID, true);
      database.AddParameter("@ReasonForReject", (object) oOrder.ReasonForReject, true);
      if (DateTime.Compare(oOrder.DeliveryDeadline, DateTime.MinValue) == 0)
        database.AddParameter("@DeliveryDeadline", (object) DBNull.Value, true);
      else
        database.AddParameter("@DeliveryDeadline", (object) oOrder.DeliveryDeadline, true);
      database.AddParameter("@SpecialInstructions", (object) oOrder.SpecialInstructions, true);
      database.AddParameter("@ContactID", (object) oOrder.ContactID, true);
      database.AddParameter("@InvoiceAddressID", (object) oOrder.InvoiceAddressID, true);
      database.AddParameter("@AllocatedToUser", (object) oOrder.AllocatedToUser, true);
      database.AddParameter("@DepartmentRef", (object) oOrder.DepartmentRef, true);
      database.AddParameter("@DoNotConsolidated", (object) oOrder.DoNotConsolidated, true);
    }

    public DataView Get_All_Places_Item_Can_Be_Got_From()
    {
      DataTable table = new DataTable();
      table.Columns.Add(new DataColumn("ValueMember"));
      table.Columns.Add(new DataColumn("DisplayMember"));
      table.Columns.Add(new DataColumn("TableName"));
      DataRow row1 = table.NewRow();
      row1["ValueMember"] = (object) 0;
      row1["DisplayMember"] = (object) Enums.ComboValues.Please_Select.ToString().Replace("_", " ").Replace("P", "--- P").Replace("t", "t ---");
      row1["TableName"] = (object) Enums.TableNames.NO_TABLE.ToString();
      table.Rows.Add(row1);
      DataRow row2 = table.NewRow();
      row2["ValueMember"] = (object) 1;
      row2["DisplayMember"] = (object) "SUPPLIER";
      table.Rows.Add(row2);
      DataRow row3 = table.NewRow();
      row3["ValueMember"] = (object) 3;
      row3["DisplayMember"] = (object) "WAREHOUSE";
      table.Rows.Add(row3);
      DataRow row4 = table.NewRow();
      row4["ValueMember"] = (object) 2;
      row4["DisplayMember"] = (object) "VAN";
      table.Rows.Add(row4);
      return new DataView(table);
    }

    public string Order_GetEngineerNameFromPO(string PONumber)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@PONumber", (object) PONumber, true);
      return Conversions.ToString(this._database.ExecuteScalar("SELECT TOP (1) tblEngineer.Name FROM tblVan INNER JOIN tblLocations ON tblVan.VanID = tblLocations.VanID INNER JOIN tblEngineerVan ON tblVan.VanID = tblEngineerVan.VanID INNER JOIN tblEngineer ON tblEngineerVan.EngineerID = tblEngineer.EngineerID INNER JOIN tblOrderLocation ON tblLocations.LocationID = tblOrderLocation.LocationID INNER JOIN tblOrder ON tblOrderLocation.OrderID = tblOrder.OrderID WHERE (tblVan.Deleted = 0) AND (tblLocations.Deleted = 0) AND (tblOrder.OrderReference = @PONumber) ORDER BY tblEngineerVan.StartDateTime DESC", true, false));
    }

    public string Order_Get_OrderID_ByRef(string PONumber)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@PONumber", (object) PONumber, true);
      return Conversions.ToString(this._database.ExecuteScalar("SELECT TOP (1) OrderID FROM tblOrder WHERE (OrderReference = @PONumber) ORDER BY DatePlaced DESC", true, false));
    }

    public DataView Search(string criteria, int userId)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@SearchString", (object) criteria, true);
      this._database.AddParameter("@UserID", (object) userId, true);
      DataTable table = this._database.ExecuteSP_DataTable("Order_Search_Mk1", true);
      table.TableName = Enums.TableNames.tblOrder.ToString();
      return new DataView(table);
    }

    public void ReallocateReceivedStock(
      int LocationID,
      int StockTransactionType,
      string Type,
      int PartProductID,
      int Quantity,
      int OrderPartProductID)
    {
      if (!(LocationID > 0 & StockTransactionType > 0))
        return;
      string Left = Type;
      if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "Part", false) != 0)
      {
        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "Product", false) == 0)
          App.DB.ProductTransaction.Insert(new ProductTransaction()
          {
            SetLocationID = (object) LocationID,
            SetProductID = (object) PartProductID,
            SetOrderProductID = (object) OrderPartProductID,
            SetAmount = StockTransactionType != 3 ? (object) Quantity : (object) checked (Quantity * -1),
            SetTransactionTypeID = (object) StockTransactionType
          });
      }
      else
        App.DB.PartTransaction.Insert(new PartTransaction()
        {
          SetLocationID = (object) LocationID,
          SetPartID = (object) PartProductID,
          SetOrderPartID = (object) OrderPartProductID,
          SetAmount = StockTransactionType != 3 ? (object) Quantity : (object) checked (Quantity * -1),
          SetTransactionTypeID = (object) StockTransactionType
        });
    }

    public void AllocatedDistributions(DataTable PartsAndProductsDistribution)
    {
      IEnumerator enumerator;
      try
      {
        enumerator = PartsAndProductsDistribution.Rows.GetEnumerator();
        while (enumerator.MoveNext())
        {
          DataRow current = (DataRow) enumerator.Current;
          this._database.ClearParameter();
          this._database.AddParameter("@LocationID", RuntimeHelpers.GetObjectValue(current["LocationID"]), true);
          this._database.AddParameter("@AllocatedID", RuntimeHelpers.GetObjectValue(current["AllocatedID"]), true);
          this._database.AddParameter("@Other", RuntimeHelpers.GetObjectValue(current["Other"]), true);
          this._database.AddParameter("@Quantity", RuntimeHelpers.GetObjectValue(current["Quantity"]), true);
          this._database.AddParameter("@PartProductID", RuntimeHelpers.GetObjectValue(current["PartProductID"]), true);
          this._database.AddParameter("@OrderPartProductID", RuntimeHelpers.GetObjectValue(current["OrderPartProductID"]), true);
          this._database.ExecuteSP_NO_Return("EngineerVisitPartDistributed_Insert", true);
          if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current["StockTransactionType"], (object) -1, false))
          {
            PartsToBeCredited oPartsToBeCredited = new PartsToBeCredited();
            oPartsToBeCredited.IgnoreExceptionsOnSetMethods = true;
            OrderPart orderPart = App.DB.OrderPart.OrderPart_Get(Conversions.ToInteger(current["OrderPartProductID"]));
            PartSupplier partSupplier = App.DB.PartSupplier.PartSupplier_Get(orderPart.PartSupplierID);
            oPartsToBeCredited.SetOrderID = (object) orderPart.OrderID;
            oPartsToBeCredited.SetSupplierID = (object) partSupplier.SupplierID;
            oPartsToBeCredited.SetPartID = RuntimeHelpers.GetObjectValue(current["PartProductID"]);
            oPartsToBeCredited.SetQty = RuntimeHelpers.GetObjectValue(current["Quantity"]);
            oPartsToBeCredited.SetStatusID = (object) 1;
            oPartsToBeCredited.SetManuallyAdded = (object) false;
            oPartsToBeCredited.SetOrderReference = (object) App.DB.Order.Order_Get(orderPart.OrderID).OrderReference;
            App.DB.PartsToBeCredited.Insert(oPartsToBeCredited);
          }
          if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.AndObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectGreater(current["LocationID"], (object) 0, false), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectGreater(current["StockTransactionType"], (object) 0, false))))
            App.DB.PartTransaction.Insert(new PartTransaction()
            {
              SetLocationID = RuntimeHelpers.GetObjectValue(current["LocationID"]),
              SetPartID = RuntimeHelpers.GetObjectValue(current["PartProductID"]),
              SetOrderPartID = RuntimeHelpers.GetObjectValue(current["OrderPartProductID"]),
              SetAmount = Conversions.ToInteger(current["StockTransactionType"]) != 3 ? RuntimeHelpers.GetObjectValue(current["Quantity"]) : Microsoft.VisualBasic.CompilerServices.Operators.MultiplyObject(current["Quantity"], (object) -1),
              SetTransactionTypeID = RuntimeHelpers.GetObjectValue(current["StockTransactionType"])
            });
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
    }

    public DataView OrderStatus_Get_All()
    {
      this._database.ClearParameter();
      return new DataView(this._database.ExecuteSP_DataTable(nameof (OrderStatus_Get_All), true));
    }

    public DataView OrderStatus_Get_All_ForOrderManager()
    {
      this._database.ClearParameter();
      return new DataView(this._database.ExecuteSP_DataTable(nameof (OrderStatus_Get_All_ForOrderManager), true));
    }
  }
}
