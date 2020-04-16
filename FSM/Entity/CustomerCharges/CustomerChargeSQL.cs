// Decompiled with JetBrains decompiler
// Type: FSM.Entity.CustomerCharges.CustomerChargeSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM.Entity.CustomerCharges
{
  public class CustomerChargeSQL
  {
    private Database _database;

    public CustomerChargeSQL(Database database)
    {
      this._database = database;
    }

    public void Delete(int CustomerChargeID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@CustomerChargeID", (object) CustomerChargeID, true);
      this._database.ExecuteSP_NO_Return("CustomerCharge_Delete", true);
    }

    public CustomerCharge CustomerCharge_Get(int CustomerChargeID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@CustomerChargeID", (object) CustomerChargeID, false);
      DataTable dataTable = this._database.ExecuteSP_DataTable(nameof (CustomerCharge_Get), true);
      if (dataTable == null || dataTable.Rows.Count <= 0)
        return (CustomerCharge) null;
      CustomerCharge customerCharge1 = new CustomerCharge();
      CustomerCharge customerCharge2 = customerCharge1;
      customerCharge2.IgnoreExceptionsOnSetMethods = true;
      customerCharge2.SetCustomerChargeID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0][nameof (CustomerChargeID)]);
      customerCharge2.SetCustomerID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CustomerID"]);
      customerCharge2.SetMileageRate = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["MileageRate"]);
      customerCharge2.SetPartsMarkup = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["PartsMarkup"]);
      customerCharge2.SetRatesMarkup = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["RatesMarkup"]);
      customerCharge2.SetDeleted = Conversions.ToBoolean(dataTable.Rows[0]["Deleted"]);
      customerCharge1.Exists = true;
      return customerCharge1;
    }

    public CustomerCharge CustomerCharge_GetForCustomer(int CustomerID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@CustomerID", (object) CustomerID, false);
      DataTable dataTable = this._database.ExecuteSP_DataTable(nameof (CustomerCharge_GetForCustomer), true);
      if (dataTable == null || dataTable.Rows.Count <= 0)
        return (CustomerCharge) null;
      CustomerCharge customerCharge1 = new CustomerCharge();
      CustomerCharge customerCharge2 = customerCharge1;
      customerCharge2.IgnoreExceptionsOnSetMethods = true;
      customerCharge2.SetCustomerChargeID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CustomerChargeID"]);
      customerCharge2.SetCustomerID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0][nameof (CustomerID)]);
      customerCharge2.SetMileageRate = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["MileageRate"]);
      customerCharge2.SetPartsMarkup = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["PartsMarkup"]);
      customerCharge2.SetRatesMarkup = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["RatesMarkup"]);
      customerCharge2.SetDeleted = Conversions.ToBoolean(dataTable.Rows[0]["Deleted"]);
      customerCharge1.Exists = true;
      return customerCharge1;
    }

    public CustomerCharge CustomerCharge_GetForSite(int siteId)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@SiteID", (object) siteId, false);
      DataTable dataTable = this._database.ExecuteSP_DataTable(nameof (CustomerCharge_GetForSite), true);
      if (dataTable == null || dataTable.Rows.Count <= 0)
        return (CustomerCharge) null;
      CustomerCharge customerCharge1 = new CustomerCharge();
      CustomerCharge customerCharge2 = customerCharge1;
      customerCharge2.IgnoreExceptionsOnSetMethods = true;
      customerCharge2.SetCustomerChargeID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CustomerChargeID"]);
      customerCharge2.SetCustomerID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CustomerID"]);
      customerCharge2.SetMileageRate = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["MileageRate"]);
      customerCharge2.SetPartsMarkup = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["PartsMarkup"]);
      customerCharge2.SetRatesMarkup = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["RatesMarkup"]);
      customerCharge2.SetDeleted = Conversions.ToBoolean(dataTable.Rows[0]["Deleted"]);
      customerCharge1.Exists = true;
      return customerCharge1;
    }

    public DataView CustomerCharge_GetAll()
    {
      this._database.ClearParameter();
      DataTable table = this._database.ExecuteSP_DataTable(nameof (CustomerCharge_GetAll), true);
      table.TableName = Enums.TableNames.tblCustomerCharge.ToString();
      return new DataView(table);
    }

    public CustomerCharge Insert(CustomerCharge oCustomerCharge)
    {
      this._database.ClearParameter();
      this.AddCustomerChargeParametersToCommand(ref oCustomerCharge);
      oCustomerCharge.SetCustomerChargeID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("CustomerCharge_Insert", true)));
      oCustomerCharge.Exists = true;
      return oCustomerCharge;
    }

    public void Update(CustomerCharge oCustomerCharge)
    {
      this._database.ClearParameter();
      this.AddCustomerChargeParametersToCommand(ref oCustomerCharge);
      this._database.ExecuteSP_NO_Return("CustomerCharge_Update", true);
    }

    public void UpdateALL(double MileageRate, double PartsMarkup, double RatesMarkup)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@MileageRate", (object) MileageRate, true);
      this._database.AddParameter("@PartsMarkup", (object) PartsMarkup, true);
      this._database.AddParameter("@RatesMarkup", (object) RatesMarkup, true);
      this._database.ExecuteSP_NO_Return("CustomerCharge_UpdateALL", true);
    }

    private void AddCustomerChargeParametersToCommand(ref CustomerCharge oCustomerCharge)
    {
      Database database = this._database;
      database.AddParameter("@CustomerID", (object) oCustomerCharge.CustomerID, true);
      database.AddParameter("@MileageRate", (object) oCustomerCharge.MileageRate, true);
      database.AddParameter("@PartsMarkup", (object) oCustomerCharge.PartsMarkup, true);
      database.AddParameter("@RatesMarkup", (object) oCustomerCharge.RatesMarkup, true);
    }
  }
}
