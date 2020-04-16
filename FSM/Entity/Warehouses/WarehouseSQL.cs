// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Warehouses.WarehouseSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Locationss;
using FSM.Entity.Sys;
using FSM.Entity.Vans;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace FSM.Entity.Warehouses
{
  public class WarehouseSQL
  {
    private Database _database;

    public WarehouseSQL(Database database)
    {
      this._database = database;
    }

    public void Delete(int WarehouseID)
    {
      string Right = this.Warehouse_Get(WarehouseID).Name.Trim();
      this._database.ClearParameter();
      this._database.AddParameter("@WarehouseID", (object) WarehouseID, true);
      this._database.ExecuteSP_NO_Return("Warehouse_Delete", true);
      IEnumerator enumerator;
      try
      {
        enumerator = App.DB.Van.Van_GetAll(false).Table.Rows.GetEnumerator();
        while (enumerator.MoveNext())
        {
          DataRow current = (DataRow) enumerator.Current;
          if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(current["Registration"])).Split('*')[1].Trim(), Right, false) == 0)
            App.DB.Van.Delete(Conversions.ToInteger(current["VanID"]), true);
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
    }

    public DataView Warehouse_GetDV(int WarehouseID, SqlTransaction trans)
    {
      SqlCommand selectCommand = new SqlCommand();
      selectCommand.CommandText = "Warehouse_Get";
      selectCommand.CommandType = CommandType.StoredProcedure;
      selectCommand.Transaction = trans;
      selectCommand.Connection = trans.Connection;
      selectCommand.Parameters.AddWithValue("@WarehouseID", (object) WarehouseID);
      SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
      DataSet dataSet = new DataSet();
      sqlDataAdapter.Fill(dataSet);
      DataTable table = dataSet.Tables[0];
      table.TableName = Enums.TableNames.tblWarehouse.ToString();
      return new DataView(table);
    }

    public DataView Warehouse_GetDV(int WarehouseID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@WarehouseID", (object) WarehouseID, false);
      DataTable table = this._database.ExecuteSP_DataTable("Warehouse_Get", true);
      table.TableName = Enums.TableNames.tblWarehouse.ToString();
      return new DataView(table);
    }

    public Warehouse Warehouse_Get(int WarehouseID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@WarehouseID", (object) WarehouseID, false);
      DataTable dataTable = this._database.ExecuteSP_DataTable(nameof (Warehouse_Get), true);
      if (dataTable == null || dataTable.Rows.Count <= 0)
        return (Warehouse) null;
      Warehouse warehouse1 = new Warehouse();
      Warehouse warehouse2 = warehouse1;
      warehouse2.IgnoreExceptionsOnSetMethods = true;
      warehouse2.SetWarehouseID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0][nameof (WarehouseID)]);
      warehouse2.SetName = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["warehouseName"]);
      warehouse2.SetSize = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Size"]);
      warehouse2.SetNotes = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Notes"]);
      warehouse2.SetAddress1 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Address1"]);
      warehouse2.SetAddress2 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Address2"]);
      warehouse2.SetAddress3 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Address3"]);
      warehouse2.SetAddress4 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Address4"]);
      warehouse2.SetAddress5 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Address5"]);
      warehouse2.SetPostcode = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Postcode"]);
      warehouse2.SetTelephoneNum = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["TelephoneNum"]);
      warehouse2.SetFaxNum = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["FaxNum"]);
      warehouse2.SetEmailAddress = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["EmailAddress"]);
      warehouse2.SetActive = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Active"]);
      warehouse2.SetDeleted = Conversions.ToBoolean(dataTable.Rows[0]["Deleted"]);
      warehouse1.Exists = true;
      return warehouse1;
    }

    public Warehouse Warehouse_Get(int WarehouseID, SqlTransaction trans)
    {
      SqlCommand selectCommand = new SqlCommand();
      selectCommand.CommandText = nameof (Warehouse_Get);
      selectCommand.CommandType = CommandType.StoredProcedure;
      selectCommand.Transaction = trans;
      selectCommand.Connection = trans.Connection;
      selectCommand.Parameters.AddWithValue("@WarehouseID", (object) WarehouseID);
      SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
      DataSet dataSet = new DataSet();
      sqlDataAdapter.Fill(dataSet);
      DataTable table = dataSet.Tables[0];
      if (table == null || table.Rows.Count <= 0)
        return (Warehouse) null;
      Warehouse warehouse1 = new Warehouse();
      Warehouse warehouse2 = warehouse1;
      warehouse2.IgnoreExceptionsOnSetMethods = true;
      warehouse2.SetWarehouseID = RuntimeHelpers.GetObjectValue(table.Rows[0][nameof (WarehouseID)]);
      warehouse2.SetName = RuntimeHelpers.GetObjectValue(table.Rows[0]["warehouseName"]);
      warehouse2.SetSize = RuntimeHelpers.GetObjectValue(table.Rows[0]["Size"]);
      warehouse2.SetNotes = RuntimeHelpers.GetObjectValue(table.Rows[0]["Notes"]);
      warehouse2.SetAddress1 = RuntimeHelpers.GetObjectValue(table.Rows[0]["Address1"]);
      warehouse2.SetAddress2 = RuntimeHelpers.GetObjectValue(table.Rows[0]["Address2"]);
      warehouse2.SetAddress3 = RuntimeHelpers.GetObjectValue(table.Rows[0]["Address3"]);
      warehouse2.SetAddress4 = RuntimeHelpers.GetObjectValue(table.Rows[0]["Address4"]);
      warehouse2.SetAddress5 = RuntimeHelpers.GetObjectValue(table.Rows[0]["Address5"]);
      warehouse2.SetPostcode = RuntimeHelpers.GetObjectValue(table.Rows[0]["Postcode"]);
      warehouse2.SetTelephoneNum = RuntimeHelpers.GetObjectValue(table.Rows[0]["TelephoneNum"]);
      warehouse2.SetFaxNum = RuntimeHelpers.GetObjectValue(table.Rows[0]["FaxNum"]);
      warehouse2.SetEmailAddress = RuntimeHelpers.GetObjectValue(table.Rows[0]["EmailAddress"]);
      warehouse2.SetActive = RuntimeHelpers.GetObjectValue(table.Rows[0]["Active"]);
      warehouse2.SetDeleted = Conversions.ToBoolean(table.Rows[0]["Deleted"]);
      warehouse1.Exists = true;
      return warehouse1;
    }

    public Warehouse Warehouse_GetByLocationID(int LocationID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@LocationID", (object) LocationID, false);
      DataTable dataTable = this._database.ExecuteSP_DataTable(nameof (Warehouse_GetByLocationID), true);
      if (dataTable == null || dataTable.Rows.Count <= 0)
        return (Warehouse) null;
      Warehouse warehouse1 = new Warehouse();
      Warehouse warehouse2 = warehouse1;
      warehouse2.IgnoreExceptionsOnSetMethods = true;
      warehouse2.SetWarehouseID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["WarehouseID"]);
      warehouse2.SetName = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["warehouseName"]);
      warehouse2.SetSize = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Size"]);
      warehouse2.SetNotes = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Notes"]);
      warehouse2.SetAddress1 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Address1"]);
      warehouse2.SetAddress2 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Address2"]);
      warehouse2.SetAddress3 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Address3"]);
      warehouse2.SetAddress4 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Address4"]);
      warehouse2.SetAddress5 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Address5"]);
      warehouse2.SetPostcode = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Postcode"]);
      warehouse2.SetTelephoneNum = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["TelephoneNum"]);
      warehouse2.SetFaxNum = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["FaxNum"]);
      warehouse2.SetEmailAddress = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["EmailAddress"]);
      warehouse2.SetActive = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Active"]);
      warehouse2.SetDeleted = Conversions.ToBoolean(dataTable.Rows[0]["Deleted"]);
      warehouse1.Exists = true;
      return warehouse1;
    }

    public Warehouse Warehouse_GetByLocationID(int LocationID, SqlTransaction trans)
    {
      SqlCommand selectCommand = new SqlCommand();
      selectCommand.CommandText = nameof (Warehouse_GetByLocationID);
      selectCommand.CommandType = CommandType.StoredProcedure;
      selectCommand.Transaction = trans;
      selectCommand.Connection = trans.Connection;
      selectCommand.Parameters.AddWithValue("@LocationID", (object) LocationID);
      SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
      DataSet dataSet = new DataSet();
      sqlDataAdapter.Fill(dataSet);
      DataTable table = dataSet.Tables[0];
      if (table == null || table.Rows.Count <= 0)
        return (Warehouse) null;
      Warehouse warehouse1 = new Warehouse();
      Warehouse warehouse2 = warehouse1;
      warehouse2.IgnoreExceptionsOnSetMethods = true;
      warehouse2.SetWarehouseID = RuntimeHelpers.GetObjectValue(table.Rows[0]["WarehouseID"]);
      warehouse2.SetName = RuntimeHelpers.GetObjectValue(table.Rows[0]["warehouseName"]);
      warehouse2.SetSize = RuntimeHelpers.GetObjectValue(table.Rows[0]["Size"]);
      warehouse2.SetNotes = RuntimeHelpers.GetObjectValue(table.Rows[0]["Notes"]);
      warehouse2.SetAddress1 = RuntimeHelpers.GetObjectValue(table.Rows[0]["Address1"]);
      warehouse2.SetAddress2 = RuntimeHelpers.GetObjectValue(table.Rows[0]["Address2"]);
      warehouse2.SetAddress3 = RuntimeHelpers.GetObjectValue(table.Rows[0]["Address3"]);
      warehouse2.SetAddress4 = RuntimeHelpers.GetObjectValue(table.Rows[0]["Address4"]);
      warehouse2.SetAddress5 = RuntimeHelpers.GetObjectValue(table.Rows[0]["Address5"]);
      warehouse2.SetPostcode = RuntimeHelpers.GetObjectValue(table.Rows[0]["Postcode"]);
      warehouse2.SetTelephoneNum = RuntimeHelpers.GetObjectValue(table.Rows[0]["TelephoneNum"]);
      warehouse2.SetFaxNum = RuntimeHelpers.GetObjectValue(table.Rows[0]["FaxNum"]);
      warehouse2.SetEmailAddress = RuntimeHelpers.GetObjectValue(table.Rows[0]["EmailAddress"]);
      warehouse2.SetActive = RuntimeHelpers.GetObjectValue(table.Rows[0]["Active"]);
      warehouse2.SetDeleted = Conversions.ToBoolean(table.Rows[0]["Deleted"]);
      warehouse1.Exists = true;
      return warehouse1;
    }

    public DataView Warehouse_GetAll()
    {
      this._database.ClearParameter();
      DataTable table = this._database.ExecuteSP_DataTable(nameof (Warehouse_GetAll), true);
      table.TableName = Enums.TableNames.tblWarehouse.ToString();
      return new DataView(table);
    }

    public DataView Warehouse_GetAll_For_Van2(int VanID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@VanID", (object) VanID, false);
      DataTable table = this._database.ExecuteSP_DataTable(nameof (Warehouse_GetAll_For_Van2), true);
      table.TableName = Enums.TableNames.tblWarehouse.ToString();
      return new DataView(table);
    }

    public DataView Warehouse_GetAll(SqlTransaction trans)
    {
      SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(new SqlCommand()
      {
        CommandText = nameof (Warehouse_GetAll),
        CommandType = CommandType.StoredProcedure,
        Transaction = trans,
        Connection = trans.Connection
      });
      DataSet dataSet = new DataSet();
      sqlDataAdapter.Fill(dataSet);
      DataTable table = dataSet.Tables[0];
      table.TableName = Enums.TableNames.tblWarehouse.ToString();
      return new DataView(table);
    }

    public Warehouse Insert(Warehouse oWarehouse, DataView LocationsDataView)
    {
      this._database.ClearParameter();
      this.AddWarehouseParametersToCommand(ref oWarehouse);
      oWarehouse.SetWarehouseID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("Warehouse_Insert", true)));
      oWarehouse.Exists = true;
      App.DB.Location.Insert(new Locations()
      {
        SetDeleted = false,
        SetVanID = (object) null,
        SetWarehouseID = (object) oWarehouse.WarehouseID
      });
      IEnumerator enumerator1;
      try
      {
        enumerator1 = App.DB.Van.Van_GetAll(true).Table.Rows.GetEnumerator();
        while (enumerator1.MoveNext())
        {
          DataRow current = (DataRow) enumerator1.Current;
          App.DB.Van.Insert(new Van()
          {
            SetRegistration = Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(current["Registration"], (object) " * "), (object) oWarehouse.Name),
            SetNotes = RuntimeHelpers.GetObjectValue(current["Notes"]),
            InsuranceDue = Conversions.ToDate(current["InsuranceDue"]),
            MOTDue = Conversions.ToDate(current["MOTDue"]),
            TaxDue = Conversions.ToDate(current["TaxDue"]),
            ServiceDue = Conversions.ToDate(current["ServiceDue"]),
            SetMileageLimit = RuntimeHelpers.GetObjectValue(current["MileageLimit"]),
            SetPeriodValue = RuntimeHelpers.GetObjectValue(current["PeriodValue"]),
            SetPeriodType = RuntimeHelpers.GetObjectValue(current["PeriodType"])
          }, "", (DataView) null, true);
        }
      }
      finally
      {
        if (enumerator1 is IDisposable)
          (enumerator1 as IDisposable).Dispose();
      }
      IEnumerator enumerator2;
      try
      {
        enumerator2 = App.DB.Van.Van_GetAll(true).Table.Rows.GetEnumerator();
        while (enumerator2.MoveNext())
        {
          DataRow current1 = (DataRow) enumerator2.Current;
          IEnumerator enumerator3;
          try
          {
            enumerator3 = LocationsDataView.Table.Rows.GetEnumerator();
            while (enumerator3.MoveNext())
            {
              DataRow current2 = (DataRow) enumerator3.Current;
              if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current1["Registration"], current2["Registration"], false))
              {
                int integer = Conversions.ToInteger(App.DB.Van.Van_GetAll_For_Warehouse(oWarehouse.WarehouseID).Table.Select(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "Registration = '", current1["Registration"]), (object) "'")))[0]["LocationID"]);
                App.DB.Location.Update(integer, Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.NotObject(current2["Tick"])));
              }
            }
          }
          finally
          {
            if (enumerator3 is IDisposable)
              (enumerator3 as IDisposable).Dispose();
          }
        }
      }
      finally
      {
        if (enumerator2 is IDisposable)
          (enumerator2 as IDisposable).Dispose();
      }
      return oWarehouse;
    }

    public DataView Warehouse_Search(string criteria, string SearchOnField)
    {
      if (SearchOnField.Trim().Length > 0)
        criteria = "'%" + criteria + "%'";
      this._database.ClearParameter();
      this._database.AddParameter("@SearchString", (object) criteria, true);
      this._database.AddParameter("@SearchOnField", (object) SearchOnField, true);
      DataTable table = this._database.ExecuteSP_DataTable(nameof (Warehouse_Search), true);
      table.TableName = Enums.TableNames.tblWarehouse.ToString();
      return new DataView(table);
    }

    public void Update(Warehouse oWarehouse, DataView LocationsDataView)
    {
      string Right = this.Warehouse_Get(oWarehouse.WarehouseID).Name.Trim();
      this._database.ClearParameter();
      this._database.AddParameter("@WarehouseID", (object) oWarehouse.WarehouseID, true);
      this.AddWarehouseParametersToCommand(ref oWarehouse);
      this._database.ExecuteSP_NO_Return("Warehouse_Update", true);
      IEnumerator enumerator;
      try
      {
        enumerator = App.DB.Van.Van_GetAll(false).Table.Rows.GetEnumerator();
        while (enumerator.MoveNext())
        {
          DataRow current = (DataRow) enumerator.Current;
          if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(current["Registration"])).Split('*')[1].Trim(), Right, false) == 0)
            App.DB.Van.Update(new Van()
            {
              SetVanID = RuntimeHelpers.GetObjectValue(current["VanID"]),
              SetRegistration = (object) (Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(current["Registration"])).Split('*')[0].Trim() + " * " + oWarehouse.Name),
              SetNotes = RuntimeHelpers.GetObjectValue(current["Notes"]),
              InsuranceDue = Conversions.ToDate(current["InsuranceDue"]),
              MOTDue = Conversions.ToDate(current["MOTDue"]),
              TaxDue = Conversions.ToDate(current["TaxDue"]),
              ServiceDue = Conversions.ToDate(current["ServiceDue"]),
              SetMileageLimit = RuntimeHelpers.GetObjectValue(current["MileageLimit"]),
              SetPeriodValue = RuntimeHelpers.GetObjectValue(current["PeriodValue"]),
              SetPeriodType = RuntimeHelpers.GetObjectValue(current["PeriodType"])
            }, LocationsDataView, true);
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
    }

    private void AddWarehouseParametersToCommand(ref Warehouse oWarehouse)
    {
      Database database = this._database;
      database.AddParameter("@Name", (object) oWarehouse.Name, true);
      database.AddParameter("@Size", (object) oWarehouse.Size, true);
      database.AddParameter("@Notes", (object) oWarehouse.Notes, true);
      database.AddParameter("@Address1", (object) oWarehouse.Address1, true);
      database.AddParameter("@Address2", (object) oWarehouse.Address2, true);
      database.AddParameter("@Address3", (object) oWarehouse.Address3, true);
      database.AddParameter("@Address4", (object) oWarehouse.Address4, true);
      database.AddParameter("@Address5", (object) oWarehouse.Address5, true);
      database.AddParameter("@Postcode", (object) oWarehouse.Postcode, true);
      database.AddParameter("@TelephoneNum", (object) oWarehouse.TelephoneNum, true);
      database.AddParameter("@FaxNum", (object) oWarehouse.FaxNum, true);
      database.AddParameter("@EmailAddress", (object) oWarehouse.EmailAddress, true);
      database.AddParameter("@Active", (object) oWarehouse.Active, true);
    }

    public DataView Warehouse_GetWithProduct(int ProductID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@ProductID", (object) ProductID, false);
      return new DataView(this._database.ExecuteSP_DataTable(nameof (Warehouse_GetWithProduct), true));
    }

    public DataView Warehouse_GetWithProduct(int ProductID, SqlTransaction trans)
    {
      SqlCommand selectCommand = new SqlCommand();
      selectCommand.CommandText = nameof (Warehouse_GetWithProduct);
      selectCommand.CommandType = CommandType.StoredProcedure;
      selectCommand.Transaction = trans;
      selectCommand.Connection = trans.Connection;
      selectCommand.Parameters.AddWithValue("@ProductID", (object) ProductID);
      SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
      DataSet dataSet = new DataSet();
      sqlDataAdapter.Fill(dataSet);
      return new DataView(dataSet.Tables[0]);
    }

    public DataView Warehouse_GetWithPart(int PartID, SqlTransaction trans)
    {
      SqlCommand selectCommand = new SqlCommand();
      selectCommand.CommandText = nameof (Warehouse_GetWithPart);
      selectCommand.CommandType = CommandType.StoredProcedure;
      selectCommand.Transaction = trans;
      selectCommand.Connection = trans.Connection;
      selectCommand.Parameters.AddWithValue("@PartID", (object) PartID);
      SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
      DataSet dataSet = new DataSet();
      sqlDataAdapter.Fill(dataSet);
      return new DataView(dataSet.Tables[0]);
    }

    public DataView Warehouse_GetWithPart(int PartID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@PartID", (object) PartID, false);
      return new DataView(this._database.ExecuteSP_DataTable(nameof (Warehouse_GetWithPart), true));
    }
  }
}
