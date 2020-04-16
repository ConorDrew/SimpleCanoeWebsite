// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Customers.CustomerAlertSql
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using System.Collections.Generic;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM.Entity.Customers
{
  public class CustomerAlertSql
  {
    private Database _database;

    public CustomerAlertSql(Database database)
    {
      this._database = database;
    }

    public List<CustomerAlert> Get(int Id)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@Id", (object) Id, false);
      DataTable table = this._database.ExecuteSP_DataTable("CustomerAlert_Get", true);
      return table != null && table.Rows.Count > 0 ? ObjectMap.DataTableToList<CustomerAlert>(table) : (List<CustomerAlert>) null;
    }

    public List<CustomerAlert> Get_ForCustomer(int customerId)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@CustomerId", (object) customerId, false);
      DataTable table = this._database.ExecuteSP_DataTable("CustomerAlert_Get_ForCustomer", true);
      return table != null && table.Rows.Count > 0 ? ObjectMap.DataTableToList<CustomerAlert>(table) : (List<CustomerAlert>) null;
    }

    public CustomerAlert Insert(CustomerAlert customerAlert)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@CustomerId", (object) customerAlert.CustomerId, true);
      this._database.AddParameter("@AlertTypeId", (object) customerAlert.AlertTypeId, true);
      this._database.AddParameter("@EmailAddress", (object) customerAlert.EmailAddress, true);
      customerAlert.Id = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("CustomerAlert_Insert", true)));
      return customerAlert;
    }

    public void Update(CustomerAlert customerAlert)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@Id", (object) customerAlert.Id, true);
      this._database.AddParameter("@EmailAddress", (object) customerAlert.EmailAddress, true);
      this._database.ExecuteSP_NO_Return("CustomerAlert_Update", true);
    }

    public void Delete(CustomerAlert customerAlert)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@Id", (object) customerAlert.Id, true);
      this._database.ExecuteSP_NO_Return("CustomerAlert_Delete", true);
    }
  }
}
