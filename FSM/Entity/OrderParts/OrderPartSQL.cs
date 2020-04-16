// Decompiled with JetBrains decompiler
// Type: FSM.Entity.OrderParts.OrderPartSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace FSM.Entity.OrderParts
{
  public class OrderPartSQL
  {
    private Database _database;

    public OrderPartSQL(Database database)
    {
      this._database = database;
    }

    public void Delete(int OrderPartID, SqlTransaction trans)
    {
      SqlCommand sqlCommand = new SqlCommand();
      sqlCommand.CommandText = "OrderPart_Delete";
      sqlCommand.CommandType = CommandType.StoredProcedure;
      sqlCommand.Transaction = trans;
      sqlCommand.Connection = trans.Connection;
      sqlCommand.Parameters.AddWithValue("@OrderPartID", (object) OrderPartID);
      sqlCommand.ExecuteNonQuery();
    }

    public void Delete(int OrderPartID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@OrderPartID", (object) OrderPartID, true);
      this._database.ExecuteSP_NO_Return("OrderPart_Delete", true);
    }

    public void DeleteForOrder(int OrderID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@OrderID", (object) OrderID, true);
      this._database.ExecuteSP_NO_Return("OrderPart_DeleteForOrder", true);
    }

    public OrderPart OrderPart_Get(int OrderPartID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@OrderPartID", (object) OrderPartID, false);
      DataTable dataTable = this._database.ExecuteSP_DataTable(nameof (OrderPart_Get), true);
      if (dataTable == null || dataTable.Rows.Count <= 0)
        return (OrderPart) null;
      OrderPart orderPart1 = new OrderPart();
      OrderPart orderPart2 = orderPart1;
      orderPart2.IgnoreExceptionsOnSetMethods = true;
      orderPart2.SetOrderPartID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0][nameof (OrderPartID)]);
      orderPart2.SetOrderID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["OrderID"]);
      orderPart2.SetPartSupplierID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["PartSupplierID"]);
      orderPart2.SetQuantity = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Quantity"]);
      orderPart2.SetQuantityReceived = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["QuantityReceived"]);
      orderPart2.SetBuyPrice = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["BuyPrice"]);
      orderPart2.SetSellPrice = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SellPrice"]);
      orderPart2.SetDispatchSiteID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["DispatchSiteID"]);
      orderPart2.SetDispatchWarehouseID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["DispatchWarehouseID"]);
      orderPart2.SetDeleted = Conversions.ToBoolean(dataTable.Rows[0]["Deleted"]);
      orderPart2.SetChildSupplierID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ChildSupplierID"]);
      orderPart2.SetSpecialDescription = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SpecialDescription"]);
      orderPart2.SetSpecialPartNumber = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SpecialPartNumber"]);
      orderPart1.Exists = true;
      return orderPart1;
    }

    public DataView OrderPart_GetAll()
    {
      this._database.ClearParameter();
      DataTable table = this._database.ExecuteSP_DataTable(nameof (OrderPart_GetAll), true);
      table.TableName = Enums.TableNames.tblOrderPart.ToString();
      return new DataView(table);
    }

    public OrderPart Insert(OrderPart oOrderPart, bool DoConsolidation)
    {
      this._database.ClearParameter();
      this.AddOrderPartParametersToCommand(ref oOrderPart);
      oOrderPart.SetOrderPartID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("OrderPart_Insert", true)));
      oOrderPart.Exists = true;
      if (DoConsolidation)
        App.DB.OrderConsolidations.Create_And_Insert_Supplier(oOrderPart.PartSupplierID, 0, oOrderPart.OrderID);
      return oOrderPart;
    }

    public OrderPart Insert(
      OrderPart oOrderPart,
      bool DoConsolidation,
      SqlTransaction trans)
    {
      SqlCommand sqlCommand = new SqlCommand();
      sqlCommand.CommandText = "OrderPart_Insert";
      sqlCommand.CommandType = CommandType.StoredProcedure;
      sqlCommand.Transaction = trans;
      sqlCommand.Connection = trans.Connection;
      sqlCommand.Parameters.AddWithValue("@PartSupplierID", (object) oOrderPart.PartSupplierID);
      sqlCommand.Parameters.AddWithValue("@Quantity", (object) oOrderPart.Quantity);
      sqlCommand.Parameters.AddWithValue("@QuantityReceived", (object) oOrderPart.QuantityReceived);
      sqlCommand.Parameters.AddWithValue("@BuyPrice", (object) oOrderPart.BuyPrice);
      sqlCommand.Parameters.AddWithValue("@SellPrice", (object) oOrderPart.SellPrice);
      sqlCommand.Parameters.AddWithValue("@OrderID", (object) oOrderPart.OrderID);
      sqlCommand.Parameters.AddWithValue("@DispatchSiteID", (object) oOrderPart.DispatchSiteID);
      sqlCommand.Parameters.AddWithValue("@DispatchWarehouseID", (object) oOrderPart.DispatchWarehouseID);
      sqlCommand.Parameters.AddWithValue("@ChildSupplierID", (object) oOrderPart.ChildSupplierID);
      sqlCommand.Parameters.AddWithValue("@SpecialDescription", (object) oOrderPart.SpecialDescription);
      sqlCommand.Parameters.AddWithValue("@SpecialPartNumber", (object) oOrderPart.SpecialPartNumber);
      oOrderPart.SetOrderPartID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(sqlCommand.ExecuteScalar()));
      oOrderPart.Exists = true;
      if (DoConsolidation)
        App.DB.OrderConsolidations.Create_And_Insert_Supplier(oOrderPart.PartSupplierID, 0, oOrderPart.OrderID, trans);
      return oOrderPart;
    }

    public void Update(OrderPart oOrderPart)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@OrderPartID", (object) oOrderPart.OrderPartID, true);
      this.AddOrderPartParametersToCommand(ref oOrderPart);
      this._database.ExecuteSP_NO_Return("OrderPart_Update", true);
    }

    public void MarkOrderQuantityReceived(int OrderPartID, int QuantityReceived)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@OrderPartID", (object) OrderPartID, true);
      this._database.AddParameter("@QuantityReceived", (object) QuantityReceived, true);
      this._database.ExecuteSP_NO_Return("OrderPart_MarkOrderQuantityReceived", true);
    }

    private void AddOrderPartParametersToCommand(ref OrderPart oOrderPart)
    {
      Database database = this._database;
      database.AddParameter("@OrderID", (object) oOrderPart.OrderID, true);
      database.AddParameter("@PartSupplierID", (object) oOrderPart.PartSupplierID, true);
      database.AddParameter("@Quantity", (object) oOrderPart.Quantity, true);
      database.AddParameter("@QuantityReceived", (object) oOrderPart.QuantityReceived, true);
      database.AddParameter("@BuyPrice", (object) oOrderPart.BuyPrice, true);
      database.AddParameter("@SellPrice", (object) oOrderPart.SellPrice, true);
      database.AddParameter("@DispatchSiteID", (object) oOrderPart.DispatchSiteID, true);
      database.AddParameter("@DispatchWarehouseID", (object) oOrderPart.DispatchWarehouseID, true);
      database.AddParameter("@ChildSupplierID", (object) oOrderPart.ChildSupplierID, true);
      database.AddParameter("@SpecialDescription", (object) oOrderPart.SpecialDescription, true);
      database.AddParameter("@SpecialPartNumber", (object) oOrderPart.SpecialPartNumber, true);
    }

    public void EngineerReceived(int OrderPartID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@OrderPartID", (object) OrderPartID, true);
      this._database.ExecuteSP_NO_Return("OrderPart_EngineerReceived", true);
    }
  }
}
