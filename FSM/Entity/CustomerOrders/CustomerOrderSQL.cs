// Decompiled with JetBrains decompiler
// Type: FSM.Entity.CustomerOrders.CustomerOrderSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace FSM.Entity.CustomerOrders
{
  public class CustomerOrderSQL
  {
    private Database _database;

    public CustomerOrderSQL(Database database)
    {
      this._database = database;
    }

    public void Delete(int CustomerOrderID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@CustomerOrderID", (object) CustomerOrderID, true);
      this._database.ExecuteSP_NO_Return("CustomerOrder_Delete", true);
    }

    public void DeleteForOrder(int OrderID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@OrderID", (object) OrderID, true);
      this._database.ExecuteSP_NO_Return("CustomerOrder_DeleteForOrder", true);
    }

    public DataView CustomerOrder_GetForOrder(int OrderID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@OrderID", (object) OrderID, true);
      DataTable table = this._database.ExecuteSP_DataTable(nameof (CustomerOrder_GetForOrder), true);
      table.TableName = Enums.TableNames.tblCustomer.ToString();
      return new DataView(table);
    }

    public CustomerOrder Insert(CustomerOrder oCustomerOrder)
    {
      this._database.ClearParameter();
      this.AddCustomerOrderParametersToCommand(ref oCustomerOrder);
      oCustomerOrder.SetCustomerOrderID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("CustomerOrder_Insert", true)));
      oCustomerOrder.Exists = true;
      return oCustomerOrder;
    }

    public CustomerOrder Insert(CustomerOrder oCustomerOrder, SqlTransaction trans)
    {
      SqlCommand sqlCommand = new SqlCommand();
      sqlCommand.CommandText = "CustomerOrder_Insert";
      sqlCommand.CommandType = CommandType.StoredProcedure;
      sqlCommand.Transaction = trans;
      sqlCommand.Connection = trans.Connection;
      sqlCommand.Parameters.AddWithValue("@OrderID", (object) oCustomerOrder.OrderID);
      sqlCommand.Parameters.AddWithValue("@CustomerID", (object) oCustomerOrder.CustomerID);
      oCustomerOrder.SetCustomerOrderID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(sqlCommand.ExecuteScalar()));
      oCustomerOrder.Exists = true;
      return oCustomerOrder;
    }

    public void Update(CustomerOrder oCustomerOrder)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@CustomerOrderID", (object) oCustomerOrder.CustomerOrderID, true);
      this.AddCustomerOrderParametersToCommand(ref oCustomerOrder);
      this._database.ExecuteSP_NO_Return("CustomerOrder_Update", true);
    }

    private void AddCustomerOrderParametersToCommand(ref CustomerOrder oCustomerOrder)
    {
      Database database = this._database;
      database.AddParameter("@OrderID", (object) oCustomerOrder.OrderID, true);
      database.AddParameter("@CustomerID", (object) oCustomerOrder.CustomerID, true);
    }
  }
}
