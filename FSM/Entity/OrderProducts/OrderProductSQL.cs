// Decompiled with JetBrains decompiler
// Type: FSM.Entity.OrderProducts.OrderProductSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace FSM.Entity.OrderProducts
{
  public class OrderProductSQL
  {
    private Database _database;

    public OrderProductSQL(Database database)
    {
      this._database = database;
    }

    public void Delete(int OrderProductID, SqlTransaction trans)
    {
      SqlCommand sqlCommand = new SqlCommand();
      sqlCommand.CommandText = "OrderProduct_Delete";
      sqlCommand.CommandType = CommandType.StoredProcedure;
      sqlCommand.Transaction = trans;
      sqlCommand.Connection = trans.Connection;
      sqlCommand.Parameters.AddWithValue("@OrderProductID", (object) OrderProductID);
      sqlCommand.ExecuteNonQuery();
    }

    public void Delete(int OrderProductID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@OrderProductID", (object) OrderProductID, true);
      this._database.ExecuteSP_NO_Return("OrderProduct_Delete", true);
    }

    public void DeleteForOrder(int OrderID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@OrderID", (object) OrderID, true);
      this._database.ExecuteSP_NO_Return("OrderProduct_DeleteForOrder", true);
    }

    public OrderProduct OrderProduct_Get(int OrderProductID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@OrderProductID", (object) OrderProductID, false);
      DataTable dataTable = this._database.ExecuteSP_DataTable(nameof (OrderProduct_Get), true);
      if (dataTable == null || dataTable.Rows.Count <= 0)
        return (OrderProduct) null;
      OrderProduct orderProduct1 = new OrderProduct();
      OrderProduct orderProduct2 = orderProduct1;
      orderProduct2.IgnoreExceptionsOnSetMethods = true;
      orderProduct2.SetOrderProductID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0][nameof (OrderProductID)]);
      orderProduct2.SetProductSupplierID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ProductSupplierID"]);
      orderProduct2.SetQuantity = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Quantity"]);
      orderProduct2.SetQuantityReceived = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["QuantityReceived"]);
      orderProduct2.SetBuyPrice = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["BuyPrice"]);
      orderProduct2.SetSellPrice = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SellPrice"]);
      orderProduct2.SetOrderID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["OrderID"]);
      orderProduct2.SetDispatchSiteID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["DispatchSiteID"]);
      orderProduct2.SetDispatchWarehouseID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["DispatchWarehouseID"]);
      orderProduct2.SetDeleted = Conversions.ToBoolean(dataTable.Rows[0]["Deleted"]);
      orderProduct1.Exists = true;
      return orderProduct1;
    }

    public DataView OrderProduct_GetAll()
    {
      this._database.ClearParameter();
      DataTable table = this._database.ExecuteSP_DataTable(nameof (OrderProduct_GetAll), true);
      table.TableName = Enums.TableNames.tblOrderProduct.ToString();
      return new DataView(table);
    }

    public OrderProduct Insert(
      OrderProduct oOrderProduct,
      bool DoConsolidation,
      SqlTransaction trans)
    {
      SqlCommand sqlCommand = new SqlCommand();
      sqlCommand.CommandText = "OrderProduct_Insert";
      sqlCommand.CommandType = CommandType.StoredProcedure;
      sqlCommand.Transaction = trans;
      sqlCommand.Connection = trans.Connection;
      sqlCommand.Parameters.AddWithValue("@ProductSupplierID", (object) oOrderProduct.ProductSupplierID);
      sqlCommand.Parameters.AddWithValue("@Quantity", (object) oOrderProduct.Quantity);
      sqlCommand.Parameters.AddWithValue("@QuantityReceived", (object) oOrderProduct.QuantityReceived);
      sqlCommand.Parameters.AddWithValue("@BuyPrice", (object) oOrderProduct.BuyPrice);
      sqlCommand.Parameters.AddWithValue("@SellPrice", (object) oOrderProduct.SellPrice);
      sqlCommand.Parameters.AddWithValue("@OrderID", (object) oOrderProduct.OrderID);
      sqlCommand.Parameters.AddWithValue("@DispatchSiteID", (object) oOrderProduct.DispatchSiteID);
      sqlCommand.Parameters.AddWithValue("@DispatchWarehouseID", (object) oOrderProduct.DispatchWarehouseID);
      oOrderProduct.SetOrderProductID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(sqlCommand.ExecuteScalar()));
      oOrderProduct.Exists = true;
      if (DoConsolidation)
        App.DB.OrderConsolidations.Create_And_Insert_Supplier(0, oOrderProduct.ProductSupplierID, oOrderProduct.OrderID, trans);
      return oOrderProduct;
    }

    public OrderProduct Insert(OrderProduct oOrderProduct, bool DoConsolidation)
    {
      this._database.ClearParameter();
      this.AddOrderProductParametersToCommand(ref oOrderProduct);
      oOrderProduct.SetOrderProductID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("OrderProduct_Insert", true)));
      oOrderProduct.Exists = true;
      if (DoConsolidation)
        App.DB.OrderConsolidations.Create_And_Insert_Supplier(0, oOrderProduct.ProductSupplierID, oOrderProduct.OrderID);
      return oOrderProduct;
    }

    public void Update(OrderProduct oOrderProduct)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@OrderProductID", (object) oOrderProduct.OrderProductID, true);
      this.AddOrderProductParametersToCommand(ref oOrderProduct);
      this._database.ExecuteSP_NO_Return("OrderProduct_Update", true);
    }

    public void MarkOrderQuantityReceived(int OrderProductID, int QuantityReceived)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@OrderProductID", (object) OrderProductID, true);
      this._database.AddParameter("@QuantityReceived", (object) QuantityReceived, true);
      this._database.ExecuteSP_NO_Return("OrderProduct_MarkOrderQuantityReceived", true);
    }

    private void AddOrderProductParametersToCommand(ref OrderProduct oOrderProduct)
    {
      Database database = this._database;
      database.AddParameter("@ProductSupplierID", (object) oOrderProduct.ProductSupplierID, true);
      database.AddParameter("@Quantity", (object) oOrderProduct.Quantity, true);
      database.AddParameter("@QuantityReceived", (object) oOrderProduct.QuantityReceived, true);
      database.AddParameter("@BuyPrice", (object) oOrderProduct.BuyPrice, true);
      database.AddParameter("@SellPrice", (object) oOrderProduct.SellPrice, true);
      database.AddParameter("@OrderID", (object) oOrderProduct.OrderID, true);
      database.AddParameter("@DispatchSiteID", (object) oOrderProduct.DispatchSiteID, true);
      database.AddParameter("@DispatchWarehouseID", (object) oOrderProduct.DispatchWarehouseID, true);
    }
  }
}
