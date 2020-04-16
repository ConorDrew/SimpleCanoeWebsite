// Decompiled with JetBrains decompiler
// Type: FSM.Entity.OrderLocationPart.OrderLocationPartSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace FSM.Entity.OrderLocationPart
{
  public class OrderLocationPartSQL
  {
    private Database _database;

    public OrderLocationPartSQL(Database database)
    {
      this._database = database;
    }

    public void Delete(int OrderLocationPartID, SqlTransaction trans)
    {
      SqlCommand sqlCommand = new SqlCommand();
      sqlCommand.CommandText = "OrderLocationPart_Delete";
      sqlCommand.CommandType = CommandType.StoredProcedure;
      sqlCommand.Transaction = trans;
      sqlCommand.Connection = trans.Connection;
      sqlCommand.Parameters.AddWithValue("@OrderLocationPartID", (object) OrderLocationPartID);
      sqlCommand.ExecuteNonQuery();
    }

    public void Delete(int OrderLocationPartID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@OrderLocationPartID", (object) OrderLocationPartID, true);
      this._database.ExecuteSP_NO_Return("OrderLocationPart_Delete", true);
    }

    public void DeleteForOrder(int OrderID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@OrderID", (object) OrderID, true);
      this._database.ExecuteSP_NO_Return("OrderLocationPart_DeleteForOrder", true);
    }

    public FSM.Entity.OrderLocationPart.OrderLocationPart OrderLocationPart_Get(
      int OrderLocationPartID,
      SqlTransaction trans)
    {
      SqlCommand selectCommand = new SqlCommand();
      selectCommand.CommandText = nameof (OrderLocationPart_Get);
      selectCommand.CommandType = CommandType.StoredProcedure;
      selectCommand.Transaction = trans;
      selectCommand.Connection = trans.Connection;
      selectCommand.Parameters.AddWithValue("@OrderLocationPartID", (object) OrderLocationPartID);
      SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
      DataSet dataSet = new DataSet();
      sqlDataAdapter.Fill(dataSet);
      DataTable table = dataSet.Tables[0];
      if (table == null || table.Rows.Count <= 0)
        return (FSM.Entity.OrderLocationPart.OrderLocationPart) null;
      FSM.Entity.OrderLocationPart.OrderLocationPart orderLocationPart1 = new FSM.Entity.OrderLocationPart.OrderLocationPart();
      FSM.Entity.OrderLocationPart.OrderLocationPart orderLocationPart2 = orderLocationPart1;
      orderLocationPart2.IgnoreExceptionsOnSetMethods = true;
      orderLocationPart2.SetOrderLocationPartID = RuntimeHelpers.GetObjectValue(table.Rows[0][nameof (OrderLocationPartID)]);
      orderLocationPart2.SetPartID = RuntimeHelpers.GetObjectValue(table.Rows[0]["PartID"]);
      orderLocationPart2.SetLocationID = RuntimeHelpers.GetObjectValue(table.Rows[0]["LocationID"]);
      orderLocationPart2.SetQuantity = RuntimeHelpers.GetObjectValue(table.Rows[0]["Quantity"]);
      orderLocationPart2.SetQuantityReceived = RuntimeHelpers.GetObjectValue(table.Rows[0]["QuantityReceived"]);
      orderLocationPart2.SetOrderID = RuntimeHelpers.GetObjectValue(table.Rows[0]["OrderID"]);
      orderLocationPart2.SetSellPrice = RuntimeHelpers.GetObjectValue(table.Rows[0]["SellPrice"]);
      orderLocationPart2.SetDeleted = Conversions.ToBoolean(table.Rows[0]["Deleted"]);
      orderLocationPart1.Exists = true;
      return orderLocationPart1;
    }

    public FSM.Entity.OrderLocationPart.OrderLocationPart OrderLocationPart_Get(
      int OrderLocationPartID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@OrderLocationPartID", (object) OrderLocationPartID, false);
      DataTable dataTable = this._database.ExecuteSP_DataTable(nameof (OrderLocationPart_Get), true);
      if (dataTable == null || dataTable.Rows.Count <= 0)
        return (FSM.Entity.OrderLocationPart.OrderLocationPart) null;
      FSM.Entity.OrderLocationPart.OrderLocationPart orderLocationPart1 = new FSM.Entity.OrderLocationPart.OrderLocationPart();
      FSM.Entity.OrderLocationPart.OrderLocationPart orderLocationPart2 = orderLocationPart1;
      orderLocationPart2.IgnoreExceptionsOnSetMethods = true;
      orderLocationPart2.SetOrderLocationPartID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0][nameof (OrderLocationPartID)]);
      orderLocationPart2.SetPartID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["PartID"]);
      orderLocationPart2.SetLocationID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["LocationID"]);
      orderLocationPart2.SetQuantity = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Quantity"]);
      orderLocationPart2.SetQuantityReceived = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["QuantityReceived"]);
      orderLocationPart2.SetOrderID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["OrderID"]);
      orderLocationPart2.SetSellPrice = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SellPrice"]);
      orderLocationPart2.SetDeleted = Conversions.ToBoolean(dataTable.Rows[0]["Deleted"]);
      orderLocationPart1.Exists = true;
      return orderLocationPart1;
    }

    public DataView OrderLocationPart_GetAll()
    {
      this._database.ClearParameter();
      DataTable table = this._database.ExecuteSP_DataTable(nameof (OrderLocationPart_GetAll), true);
      table.TableName = Enums.TableNames.tblOrderLocationPart.ToString();
      return new DataView(table);
    }

    public FSM.Entity.OrderLocationPart.OrderLocationPart Insert(
      FSM.Entity.OrderLocationPart.OrderLocationPart oOrderLocationPart,
      bool DoConsolidation)
    {
      this._database.ClearParameter();
      this.AddOrderLocationPartParametersToCommand(ref oOrderLocationPart);
      oOrderLocationPart.SetOrderLocationPartID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("OrderLocationPart_Insert", true)));
      oOrderLocationPart.Exists = true;
      if (DoConsolidation)
        App.DB.OrderConsolidations.Create_And_Insert_Location(oOrderLocationPart.LocationID, oOrderLocationPart.OrderID);
      return oOrderLocationPart;
    }

    public FSM.Entity.OrderLocationPart.OrderLocationPart Insert(
      FSM.Entity.OrderLocationPart.OrderLocationPart oOrderLocationPart,
      bool DoConsolidation,
      SqlTransaction trans)
    {
      SqlCommand sqlCommand = new SqlCommand();
      sqlCommand.CommandText = "OrderLocationPart_Insert";
      sqlCommand.CommandType = CommandType.StoredProcedure;
      sqlCommand.Transaction = trans;
      sqlCommand.Connection = trans.Connection;
      sqlCommand.Parameters.AddWithValue("@PartID", (object) oOrderLocationPart.PartID);
      sqlCommand.Parameters.AddWithValue("@LocationID", (object) oOrderLocationPart.LocationID);
      sqlCommand.Parameters.AddWithValue("@Quantity", (object) oOrderLocationPart.Quantity);
      sqlCommand.Parameters.AddWithValue("@QuantityReceived", (object) oOrderLocationPart.QuantityReceived);
      sqlCommand.Parameters.AddWithValue("@OrderID", (object) oOrderLocationPart.OrderID);
      sqlCommand.Parameters.AddWithValue("@SellPrice", (object) oOrderLocationPart.SellPrice);
      oOrderLocationPart.SetOrderLocationPartID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(sqlCommand.ExecuteScalar()));
      oOrderLocationPart.Exists = true;
      if (DoConsolidation)
        App.DB.OrderConsolidations.Create_And_Insert_Location(oOrderLocationPart.LocationID, oOrderLocationPart.OrderID, trans);
      return oOrderLocationPart;
    }

    public void Update(FSM.Entity.OrderLocationPart.OrderLocationPart oOrderLocationPart)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@OrderLocationPartID", (object) oOrderLocationPart.OrderLocationPartID, true);
      this.AddOrderLocationPartParametersToCommand(ref oOrderLocationPart);
      this._database.ExecuteSP_NO_Return("OrderLocationPart_Update", true);
    }

    private void AddOrderLocationPartParametersToCommand(ref FSM.Entity.OrderLocationPart.OrderLocationPart oOrderLocationPart)
    {
      Database database = this._database;
      database.AddParameter("@PartID", (object) oOrderLocationPart.PartID, true);
      database.AddParameter("@LocationID", (object) oOrderLocationPart.LocationID, true);
      database.AddParameter("@Quantity", (object) oOrderLocationPart.Quantity, true);
      database.AddParameter("@QuantityReceived", (object) oOrderLocationPart.QuantityReceived, true);
      database.AddParameter("@OrderID", (object) oOrderLocationPart.OrderID, true);
      database.AddParameter("@SellPrice", (object) oOrderLocationPart.SellPrice, true);
    }

    public void EngineerReceived(int OrderLocationPartID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@OrderLocationPartID", (object) OrderLocationPartID, true);
      this._database.ExecuteSP_NO_Return("OrderLocationPart_EngineerReceived", true);
    }

    public void MarkOrderQuantityReceived(int OrderLocationPartID, int OrderLocationQuantityOrdered)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@OrderLocationPartID", (object) OrderLocationPartID, true);
      this._database.AddParameter("@QuantityReceived", (object) OrderLocationQuantityOrdered, true);
      this._database.ExecuteSP_NO_Return("OrderLocationPart_MarkOrderQuantityReceived", true);
    }
  }
}
