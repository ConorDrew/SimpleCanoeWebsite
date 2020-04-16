// Decompiled with JetBrains decompiler
// Type: FSM.Entity.CustomerScheduleOfRates.CustomerScheduleOfRateSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM.Entity.CustomerScheduleOfRates
{
  public class CustomerScheduleOfRateSQL
  {
    private Database _database;

    public CustomerScheduleOfRateSQL(Database database)
    {
      this._database = database;
    }

    public void Delete(int CustomerScheduleOfRateID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@CustomerScheduleOfRateID", (object) CustomerScheduleOfRateID, true);
      this._database.ExecuteSP_NO_Return("CustomerScheduleOfRate_Delete", true);
    }

    public CustomerScheduleOfRate Get(int CustomerScheduleOfRateID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@CustomerScheduleOfRateID", (object) CustomerScheduleOfRateID, false);
      DataTable dataTable = this._database.ExecuteSP_DataTable("CustomerScheduleOfRate_Get", true);
      if (dataTable == null || dataTable.Rows.Count <= 0)
        return (CustomerScheduleOfRate) null;
      CustomerScheduleOfRate customerScheduleOfRate1 = new CustomerScheduleOfRate();
      CustomerScheduleOfRate customerScheduleOfRate2 = customerScheduleOfRate1;
      customerScheduleOfRate2.IgnoreExceptionsOnSetMethods = true;
      customerScheduleOfRate2.SetCustomerScheduleOfRateID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0][nameof (CustomerScheduleOfRateID)]);
      customerScheduleOfRate2.SetCustomerID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CustomerID"]);
      customerScheduleOfRate2.SetScheduleOfRatesCategoryID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ScheduleOfRatesCategoryID"]);
      customerScheduleOfRate2.SetCode = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Code"]);
      customerScheduleOfRate2.SetDescription = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Description"]);
      customerScheduleOfRate2.SetPrice = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Price"]);
      customerScheduleOfRate2.SetTimeInMins = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["TimeInMins"]));
      customerScheduleOfRate2.SetAllowDeleted = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["AllowDeleted"]);
      customerScheduleOfRate2.SetDeleted = Conversions.ToBoolean(dataTable.Rows[0]["Deleted"]);
      customerScheduleOfRate1.Exists = true;
      return customerScheduleOfRate1;
    }

    public DataView GetAll_For_CustomerID(int CustomerID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@CustomerID", (object) CustomerID, true);
      DataTable table = this._database.ExecuteSP_DataTable("CustomerScheduleOfRate_GetAll_For_CustomerID", true);
      table.TableName = Enums.TableNames.tblCustomerScheduleOfRate.ToString();
      return new DataView(table);
    }

    public DataView GetAll_For_SiteID(int siteId)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@SiteID", (object) siteId, true);
      DataTable table = this._database.ExecuteSP_DataTable("CustomerScheduleOfRate_GetAll_For_SiteID", true);
      table.TableName = Enums.TableNames.tblCustomerScheduleOfRate.ToString();
      return new DataView(table);
    }

    public DataView GetAll_WithoutDefaults(int CustomerID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@CustomerID", (object) CustomerID, true);
      DataTable table = this._database.ExecuteSP_DataTable("CustomerScheduleOfRate_GetAll_WithoutDefaults", true);
      table.TableName = Enums.TableNames.tblSystemScheduleOfRate.ToString();
      return new DataView(table);
    }

    public DataView Customer_Jobtype_Sor_Get(int CustomerID, int JobTypeID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@CustomerID", (object) CustomerID, true);
      this._database.AddParameter("@JobTypeID", (object) JobTypeID, true);
      DataTable table = this._database.ExecuteSP_DataTable("Customer_JobType_Sor_Get", true);
      table.TableName = Enums.TableNames.tblSystemScheduleOfRate.ToString();
      return new DataView(table);
    }

    public DataView Customer_Jobtype_Sor_GetAll()
    {
      this._database.ClearParameter();
      DataTable table = this._database.ExecuteSP_DataTable("Customer_JobType_Sor_GetALL", true);
      table.TableName = Enums.TableNames.tblSystemScheduleOfRate.ToString();
      return new DataView(table);
    }

    public DataView Customer_Jobtype_Sor_Insert(
      int CustomerID,
      int JobTypeID,
      int CustomerScheduleOfRateID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@CustomerID", (object) CustomerID, true);
      this._database.AddParameter("@JobTypeID", (object) JobTypeID, true);
      this._database.AddParameter("@CustomerScheduleOfRateID", (object) CustomerScheduleOfRateID, true);
      DataTable table = this._database.ExecuteSP_DataTable("Customer_JobType_Sor_Insert", true);
      table.TableName = Enums.TableNames.tblSystemScheduleOfRate.ToString();
      return new DataView(table);
    }

    public DataView Customer_Jobtype_Sor_Delete(int CustomerJobTypeSORID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@CustomerJobTypeSORID", (object) CustomerJobTypeSORID, true);
      DataTable table = this._database.ExecuteSP_DataTable("Customer_JobType_Sor_Delete", true);
      table.TableName = Enums.TableNames.tblSystemScheduleOfRate.ToString();
      return new DataView(table);
    }

    public CustomerScheduleOfRate Insert(
      CustomerScheduleOfRate oCustomerScheduleOfRate)
    {
      this._database.ClearParameter();
      this.AddCustomerScheduleOfRateParametersToCommand(ref oCustomerScheduleOfRate);
      oCustomerScheduleOfRate.SetCustomerScheduleOfRateID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("CustomerScheduleOfRate_Insert", true)));
      oCustomerScheduleOfRate.Exists = true;
      return oCustomerScheduleOfRate;
    }

    public void Update(CustomerScheduleOfRate oCustomerScheduleOfRate)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@CustomerScheduleOfRateID", (object) oCustomerScheduleOfRate.CustomerScheduleOfRateID, true);
      this.AddCustomerScheduleOfRateParametersToCommand(ref oCustomerScheduleOfRate);
      this._database.ExecuteSP_NO_Return("CustomerScheduleOfRate_Update", true);
    }

    private void AddCustomerScheduleOfRateParametersToCommand(
      ref CustomerScheduleOfRate oCustomerScheduleOfRate)
    {
      Database database = this._database;
      database.AddParameter("@CustomerID", (object) oCustomerScheduleOfRate.CustomerID, true);
      database.AddParameter("@ScheduleOfRatesCategoryID", (object) oCustomerScheduleOfRate.ScheduleOfRatesCategoryID, true);
      database.AddParameter("@Code", (object) oCustomerScheduleOfRate.Code, true);
      database.AddParameter("@Description", (object) oCustomerScheduleOfRate.Description, true);
      database.AddParameter("@Price", (object) oCustomerScheduleOfRate.Price, true);
      database.AddParameter("@TimeInMins", (object) oCustomerScheduleOfRate.TimeInMins, true);
      database.AddParameter("@AllowDeleted", (object) oCustomerScheduleOfRate.AllowDeleted, true);
    }

    public void Insert_Defaults(int CustomerID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@CustomerID", (object) CustomerID, true);
      this._database.ExecuteSP_NO_Return("CustomerScheduleOfRate_Insert_Defaults", true);
    }

    public void CustomerScheduleOfRates_UpdateForALL(
      Decimal Price,
      string Description,
      string Code,
      int ScheduleOfRatesCategoryID,
      int TimeInMins)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@Price", (object) Price, true);
      this._database.AddParameter("@Description", (object) Description, true);
      this._database.AddParameter("@Code", (object) Code, true);
      this._database.AddParameter("@ScheduleOfRatesCategoryID", (object) ScheduleOfRatesCategoryID, true);
      this._database.AddParameter("@TimeInMins", (object) TimeInMins, true);
      this._database.ExecuteSP_NO_Return(nameof (CustomerScheduleOfRates_UpdateForALL), true);
    }

    public DataView CustomerScheduleOfRates_GetALL_Labour(int CustomerID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@CustomerID", (object) CustomerID, true);
      DataTable table = this._database.ExecuteSP_DataTable(nameof (CustomerScheduleOfRates_GetALL_Labour), true);
      table.TableName = Enums.TableNames.tblCustomerScheduleOfRate.ToString();
      return new DataView(table);
    }

    public DataTable Exists(
      int ScheduleOfRatesCategoryID,
      string Description,
      string Code,
      int customerId)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@ScheduleOfRatesCategoryID", (object) ScheduleOfRatesCategoryID, true);
      this._database.AddParameter("@Description", (object) Description, true);
      this._database.AddParameter("@Code", (object) Code, true);
      this._database.AddParameter("@CustomerID", (object) customerId, true);
      return this._database.ExecuteSP_DataTable("CustomerScheduleOfRate_Exists", true);
    }
  }
}
