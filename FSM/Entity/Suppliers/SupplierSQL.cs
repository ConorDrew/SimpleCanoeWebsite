// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Suppliers.SupplierSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace FSM.Entity.Suppliers
{
  public class SupplierSQL
  {
    private Database _database;

    public SupplierSQL(Database database)
    {
      this._database = database;
    }

    public void Delete(int SupplierID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@SupplierID", (object) SupplierID, true);
      this._database.ExecuteSP_NO_Return("Supplier_Delete", true);
    }

    public Supplier Supplier_Get(int SupplierID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@SupplierID", (object) SupplierID, false);
      DataTable dataTable = this._database.ExecuteSP_DataTable(nameof (Supplier_Get), true);
      if (dataTable == null || dataTable.Rows.Count <= 0)
        return (Supplier) null;
      Supplier supplier1 = new Supplier();
      Supplier supplier2 = supplier1;
      supplier2.IgnoreExceptionsOnSetMethods = true;
      supplier2.SetSupplierID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0][nameof (SupplierID)]);
      supplier2.SetAccountNumber = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["AccountNumber"]);
      if (dataTable.Columns.Contains("SecondAccountNumber"))
        supplier2.SetSecondAccountNumber = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SecondAccountNumber"]);
      supplier2.SetName = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Name"]);
      supplier2.SetAddress1 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Address1"]);
      supplier2.SetAddress2 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Address2"]);
      supplier2.SetAddress3 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Address3"]);
      supplier2.SetAddress4 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Address4"]);
      supplier2.SetAddress5 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Address5"]);
      supplier2.SetPostcode = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Postcode"]);
      supplier2.SetTelephoneNum = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["TelephoneNum"]);
      supplier2.SetFaxNum = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["FaxNum"]);
      supplier2.SetEmailAddress = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["EmailAddress"]);
      supplier2.SetNotes = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Notes"]);
      supplier2.SetGaswayAccount = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["GaswayAccount"]));
      supplier2.SetMasterSupplierID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["MasterSupplierID"]));
      supplier2.SetReleaseToTablets = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ReleaseToTablets"]);
      supplier2.SetDeleted = Conversions.ToBoolean(dataTable.Rows[0]["Deleted"]);
      supplier2.SetSubContractor = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SubContractor"]);
      supplier2.SecondaryPrice = Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SecondaryPrice"]));
      supplier2.SetDefaultNominal = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["DefaultNominal"]);
      supplier1.Exists = true;
      return supplier1;
    }

    public Supplier Supplier_Get(int SupplierID, SqlTransaction trans)
    {
      SqlCommand selectCommand = new SqlCommand();
      selectCommand.CommandText = nameof (Supplier_Get);
      selectCommand.CommandType = CommandType.StoredProcedure;
      selectCommand.Transaction = trans;
      selectCommand.Connection = trans.Connection;
      selectCommand.Parameters.AddWithValue("@SupplierID", (object) SupplierID);
      SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
      DataSet dataSet = new DataSet();
      sqlDataAdapter.Fill(dataSet);
      DataTable table = dataSet.Tables[0];
      if (table == null || table.Rows.Count <= 0)
        return (Supplier) null;
      Supplier supplier1 = new Supplier();
      Supplier supplier2 = supplier1;
      supplier2.IgnoreExceptionsOnSetMethods = true;
      supplier2.SetSupplierID = RuntimeHelpers.GetObjectValue(table.Rows[0][nameof (SupplierID)]);
      supplier2.SetAccountNumber = RuntimeHelpers.GetObjectValue(table.Rows[0]["AccountNumber"]);
      if (table.Columns.Contains("SecondAccountNumber"))
        supplier2.SetSecondAccountNumber = RuntimeHelpers.GetObjectValue(table.Rows[0]["SecondAccountNumber"]);
      supplier2.SetName = RuntimeHelpers.GetObjectValue(table.Rows[0]["Name"]);
      supplier2.SetAddress1 = RuntimeHelpers.GetObjectValue(table.Rows[0]["Address1"]);
      supplier2.SetAddress2 = RuntimeHelpers.GetObjectValue(table.Rows[0]["Address2"]);
      supplier2.SetAddress3 = RuntimeHelpers.GetObjectValue(table.Rows[0]["Address3"]);
      supplier2.SetAddress4 = RuntimeHelpers.GetObjectValue(table.Rows[0]["Address4"]);
      supplier2.SetAddress5 = RuntimeHelpers.GetObjectValue(table.Rows[0]["Address5"]);
      supplier2.SetPostcode = RuntimeHelpers.GetObjectValue(table.Rows[0]["Postcode"]);
      supplier2.SetTelephoneNum = RuntimeHelpers.GetObjectValue(table.Rows[0]["TelephoneNum"]);
      supplier2.SetFaxNum = RuntimeHelpers.GetObjectValue(table.Rows[0]["FaxNum"]);
      supplier2.SetEmailAddress = RuntimeHelpers.GetObjectValue(table.Rows[0]["EmailAddress"]);
      supplier2.SetNotes = RuntimeHelpers.GetObjectValue(table.Rows[0]["Notes"]);
      supplier2.SetGaswayAccount = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(table.Rows[0]["GaswayAccount"]));
      supplier2.SetMasterSupplierID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(table.Rows[0]["MasterSupplierID"]));
      supplier2.SetReleaseToTablets = RuntimeHelpers.GetObjectValue(table.Rows[0]["ReleaseToTablets"]);
      supplier2.SetDeleted = Conversions.ToBoolean(table.Rows[0]["Deleted"]);
      supplier2.SetSubContractor = RuntimeHelpers.GetObjectValue(table.Rows[0]["SubContractor"]);
      supplier1.Exists = true;
      return supplier1;
    }

    public DataView Supplier_GetAll()
    {
      this._database.ClearParameter();
      DataTable table = this._database.ExecuteSP_DataTable(nameof (Supplier_GetAll), true);
      table.TableName = Enums.TableNames.tblSupplier.ToString();
      return new DataView(table);
    }

    public DataView Supplier_GetAll(SqlTransaction trans)
    {
      SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(new SqlCommand()
      {
        CommandText = nameof (Supplier_GetAll),
        CommandType = CommandType.StoredProcedure,
        Transaction = trans,
        Connection = trans.Connection
      });
      DataSet dataSet = new DataSet();
      sqlDataAdapter.Fill(dataSet);
      DataTable table = dataSet.Tables[0];
      table.TableName = Enums.TableNames.tblSupplier.ToString();
      return new DataView(table);
    }

    public int GetChildSupplier(int SupplierID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@SupplierID", (object) SupplierID, true);
      return Conversions.ToInteger(this._database.SP_ExecuteScalar("Supplier_GetChildSupplierID", true));
    }

    public DataView Supplier_Search(string criteria, string SearchOnField)
    {
      if (SearchOnField.Trim().Length > 0)
        criteria = "'%" + criteria + "%'";
      this._database.ClearParameter();
      this._database.AddParameter("@SearchString", (object) criteria, true);
      this._database.AddParameter("@SearchOnField", (object) SearchOnField, true);
      DataTable table = this._database.ExecuteSP_DataTable("Supplier_SearchList", true);
      table.TableName = Enums.TableNames.tblSupplier.ToString();
      return new DataView(table);
    }

    public Supplier Insert(Supplier oSupplier)
    {
      this._database.ClearParameter();
      this.AddSupplierParametersToCommand(ref oSupplier);
      oSupplier.SetSupplierID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("Supplier_Insert", true)));
      oSupplier.Exists = true;
      return oSupplier;
    }

    public void Update(Supplier oSupplier)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@SupplierID", (object) oSupplier.SupplierID, true);
      this.AddSupplierParametersToCommand(ref oSupplier);
      this._database.ExecuteSP_NO_Return("Supplier_Update", true);
    }

    private void AddSupplierParametersToCommand(ref Supplier oSupplier)
    {
      Database database = this._database;
      database.AddParameter("@AccountNumber", (object) oSupplier.AccountNumber, true);
      database.AddParameter("@SecondAccountNumber", (object) oSupplier.SecondAccountNumber, true);
      database.AddParameter("@Name", (object) oSupplier.Name, true);
      database.AddParameter("@Address1", (object) oSupplier.Address1, true);
      database.AddParameter("@Address2", (object) oSupplier.Address2, true);
      database.AddParameter("@Address3", (object) oSupplier.Address3, true);
      database.AddParameter("@Address4", (object) oSupplier.Address4, true);
      database.AddParameter("@Address5", (object) oSupplier.Address5, true);
      database.AddParameter("@Postcode", (object) oSupplier.Postcode, true);
      database.AddParameter("@TelephoneNum", (object) oSupplier.TelephoneNum, true);
      database.AddParameter("@FaxNum", (object) oSupplier.FaxNum, true);
      database.AddParameter("@EmailAddress", (object) oSupplier.EmailAddress, true);
      database.AddParameter("@Notes", (object) oSupplier.Notes, true);
      database.AddParameter("@GaswayAccount", (object) oSupplier.GaswayAccount, true);
      database.AddParameter("@MasterSupplierID", (object) oSupplier.MasterSupplierID, true);
      database.AddParameter("@ReleaseToTablets", (object) oSupplier.ReleaseToTablets, true);
      database.AddParameter("@SubContractor", (object) oSupplier.SubContractor, true);
      database.AddParameter("@SecondaryPrice", (object) oSupplier.SecondaryPrice, true);
      database.AddParameter("@DefaultNominal", (object) oSupplier.DefaultNominal, true);
    }

    public DataView Supplier_GetWithProduct(int ProductID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@ProductID", (object) ProductID, false);
      return new DataView(this._database.ExecuteSP_DataTable(nameof (Supplier_GetWithProduct), true));
    }

    public DataView Supplier_GetWithProduct(int ProductID, SqlTransaction trans)
    {
      SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(new SqlCommand()
      {
        CommandText = nameof (Supplier_GetWithProduct),
        CommandType = CommandType.StoredProcedure,
        Transaction = trans,
        Connection = trans.Connection,
        Parameters = {
          new SqlParameter("@ProductID", (object) ProductID)
        }
      });
      DataSet dataSet = new DataSet();
      sqlDataAdapter.Fill(dataSet);
      return new DataView(dataSet.Tables[0]);
    }

    public DataView Supplier_GetWithPart(int PartID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@PartID", (object) PartID, false);
      return new DataView(this._database.ExecuteSP_DataTable(nameof (Supplier_GetWithPart), true));
    }

    public DataView Supplier_GetWithPart(int PartID, SqlTransaction trans)
    {
      SqlCommand selectCommand = new SqlCommand();
      selectCommand.CommandText = nameof (Supplier_GetWithPart);
      selectCommand.CommandType = CommandType.StoredProcedure;
      selectCommand.Transaction = trans;
      selectCommand.Connection = trans.Connection;
      selectCommand.Parameters.AddWithValue("@PartID", (object) PartID);
      SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
      DataSet dataSet = new DataSet();
      sqlDataAdapter.Fill(dataSet);
      return new DataView(dataSet.Tables[0]);
    }

    public bool Supplier_GetSecondaryPrice(int SupplierID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@SupplierID", (object) SupplierID, true);
      return (uint) Conversions.ToInteger(this._database.SP_ExecuteScalar("Supplier_HasSecondaryPrice", true)) > 0U;
    }
  }
}
