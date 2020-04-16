// Decompiled with JetBrains decompiler
// Type: FSM.Entity.PartTransactions.PartTransactionSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace FSM.Entity.PartTransactions
{
  public class PartTransactionSQL
  {
    private Database _database;

    public PartTransactionSQL(Database database)
    {
      this._database = database;
    }

    public PartTransaction PartTransaction_GetByOrderLocationPart(
      int OrderLocationPartID,
      SqlTransaction trans)
    {
      SqlCommand selectCommand = new SqlCommand();
      selectCommand.CommandText = nameof (PartTransaction_GetByOrderLocationPart);
      selectCommand.CommandType = CommandType.StoredProcedure;
      if (trans != null)
      {
        selectCommand.Transaction = trans;
        selectCommand.Connection = trans.Connection;
      }
      selectCommand.Parameters.AddWithValue("@OrderLocationPartID", (object) OrderLocationPartID);
      SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
      DataSet dataSet = new DataSet();
      sqlDataAdapter.Fill(dataSet);
      DataTable table = dataSet.Tables[0];
      if (table == null || table.Rows.Count <= 0)
        return (PartTransaction) null;
      PartTransaction partTransaction1 = new PartTransaction();
      PartTransaction partTransaction2 = partTransaction1;
      partTransaction2.IgnoreExceptionsOnSetMethods = true;
      partTransaction2.SetPartTransactionID = RuntimeHelpers.GetObjectValue(table.Rows[0]["PartTransactionID"]);
      partTransaction2.SetPartID = RuntimeHelpers.GetObjectValue(table.Rows[0]["PartID"]);
      partTransaction2.SetAmount = RuntimeHelpers.GetObjectValue(table.Rows[0]["Amount"]);
      partTransaction2.TransactionDate = Conversions.ToDate(table.Rows[0]["TransactionDate"]);
      partTransaction2.SetUserID = RuntimeHelpers.GetObjectValue(table.Rows[0]["UserID"]);
      partTransaction2.SetTransactionTypeID = RuntimeHelpers.GetObjectValue(table.Rows[0]["TransactionTypeID"]);
      partTransaction2.SetLocationID = RuntimeHelpers.GetObjectValue(table.Rows[0]["LocationID"]);
      partTransaction2.SetOrderPartID = RuntimeHelpers.GetObjectValue(table.Rows[0]["OrderPartID"]);
      partTransaction2.SetOrderLocationPartID = RuntimeHelpers.GetObjectValue(table.Rows[0][nameof (OrderLocationPartID)]);
      partTransaction2.SetDeleted = Conversions.ToBoolean(table.Rows[0]["Deleted"]);
      partTransaction1.Exists = true;
      return partTransaction1;
    }

    public PartTransaction PartTransaction_GetByOrderLocationPart(
      int OrderLocationPartID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@OrderLocationPartID", (object) OrderLocationPartID, false);
      DataTable dataTable = this._database.ExecuteSP_DataTable(nameof (PartTransaction_GetByOrderLocationPart), true);
      if (dataTable == null || dataTable.Rows.Count <= 0)
        return (PartTransaction) null;
      PartTransaction partTransaction1 = new PartTransaction();
      PartTransaction partTransaction2 = partTransaction1;
      partTransaction2.IgnoreExceptionsOnSetMethods = true;
      partTransaction2.SetPartTransactionID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["PartTransactionID"]);
      partTransaction2.SetPartID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["PartID"]);
      partTransaction2.SetAmount = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Amount"]);
      partTransaction2.TransactionDate = Conversions.ToDate(dataTable.Rows[0]["TransactionDate"]);
      partTransaction2.SetUserID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["UserID"]);
      partTransaction2.SetTransactionTypeID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["TransactionTypeID"]);
      partTransaction2.SetLocationID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["LocationID"]);
      partTransaction2.SetOrderPartID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["OrderPartID"]);
      partTransaction2.SetOrderLocationPartID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0][nameof (OrderLocationPartID)]);
      partTransaction2.SetDeleted = Conversions.ToBoolean(dataTable.Rows[0]["Deleted"]);
      partTransaction1.Exists = true;
      return partTransaction1;
    }

    public object PartTransaction_Consolidate_All(int LocationID, int PartID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@LocationID", (object) LocationID, true);
      this._database.AddParameter("@PartID", (object) PartID, true);
      this._database.ExecuteSP_NO_Return(nameof (PartTransaction_Consolidate_All), true);
      object obj;
      return obj;
    }

    public DataView SearchByVan(string SearchString, int LocationID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@SearchString", (object) SearchString, true);
      this._database.AddParameter("@LocationID", (object) LocationID, true);
      DataTable table = this._database.ExecuteSP_DataTable("Part_SearchByVan", true);
      table.TableName = Enums.TableNames.tblPart.ToString();
      return new DataView(table);
    }

    public DataView GetByVan4(int VanID, bool WithLocation = false, bool ForIPT = false, int SupplierID = 0)
    {
      if (WithLocation)
      {
        string Right = App.DB.Van.Van_Get(VanID).Registration.Split('*')[0].Trim();
        DataTable table = new DataTable();
        table.Columns.Add(new DataColumn("Location"));
        table.Columns.Add(new DataColumn("PartID", Type.GetType("System.Int32")));
        table.Columns.Add(new DataColumn("PartName"));
        table.Columns.Add(new DataColumn("PartNumber"));
        table.Columns.Add(new DataColumn("Reference"));
        table.Columns.Add(new DataColumn("Amount", Type.GetType("System.Int32")));
        table.Columns.Add(new DataColumn("CategoryID", Type.GetType("System.Int32")));
        table.Columns.Add(new DataColumn("LocationID", Type.GetType("System.Int32")));
        table.Columns.Add(new DataColumn("Min", Type.GetType("System.Int32")));
        table.Columns.Add(new DataColumn("Max", Type.GetType("System.Int32")));
        table.Columns.Add(new DataColumn("MinMaxID", Type.GetType("System.Int32")));
        table.Columns.Add(new DataColumn("SPN"));
        IEnumerator enumerator1;
        try
        {
          enumerator1 = App.DB.Van.Van_GetAll(false).Table.Rows.GetEnumerator();
          while (enumerator1.MoveNext())
          {
            DataRow current1 = (DataRow) enumerator1.Current;
            if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(current1["Registration"])).Split('*')[0].Trim(), Right, false) == 0)
            {
              this._database.ClearParameter();
              this._database.AddParameter("@VanID", RuntimeHelpers.GetObjectValue(current1[nameof (VanID)]), true);
              if (ForIPT)
                this._database.AddParameter("@ForIPT", (object) 1, true);
              else
                this._database.AddParameter("@ForIPT", (object) 0, true);
              DataTable dataTable1 = this._database.ExecuteSP_DataTable("Part_GetByVan", true);
              IEnumerator enumerator2;
              try
              {
                enumerator2 = dataTable1.Rows.GetEnumerator();
                while (enumerator2.MoveNext())
                {
                  DataRow current2 = (DataRow) enumerator2.Current;
                  DataRow row = table.NewRow();
                  row["Location"] = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(current1["Registration"])).Split('*')[1].Trim();
                  row["PartID"] = RuntimeHelpers.GetObjectValue(current2["PartID"]);
                  row["PartName"] = RuntimeHelpers.GetObjectValue(current2["PartName"]);
                  row["PartNumber"] = RuntimeHelpers.GetObjectValue(current2["PartNumber"]);
                  row["Reference"] = RuntimeHelpers.GetObjectValue(current2["Reference"]);
                  row["Amount"] = RuntimeHelpers.GetObjectValue(current2["Amount"]);
                  row["CategoryID"] = RuntimeHelpers.GetObjectValue(current2["CategoryID"]);
                  row["LocationID"] = RuntimeHelpers.GetObjectValue(current2["LocationID"]);
                  this._database.ClearParameter();
                  this._database.AddParameter("@PartID", RuntimeHelpers.GetObjectValue(current2["PartID"]), true);
                  DataTable dataTable2 = this._database.ExecuteSP_DataTable("PartLocations_GetAll", true);
                  if (dataTable2 != null)
                  {
                    if (dataTable2.Rows.Count == 0)
                    {
                      row["Min"] = (object) 0;
                      row["Max"] = (object) 0;
                      row["MinMaxID"] = (object) 0;
                      row["SPN"] = (object) "";
                    }
                    else
                    {
                      bool flag = false;
                      IEnumerator enumerator3;
                      try
                      {
                        enumerator3 = dataTable2.Rows.GetEnumerator();
                        while (enumerator3.MoveNext())
                        {
                          DataRow current3 = (DataRow) enumerator3.Current;
                          if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current3[nameof (VanID)], current1[nameof (VanID)], false))
                          {
                            row["Min"] = RuntimeHelpers.GetObjectValue(current3["MinQty"]);
                            row["Max"] = RuntimeHelpers.GetObjectValue(current3["RecQty"]);
                            row["MinMaxID"] = RuntimeHelpers.GetObjectValue(current3["PartLocationID"]);
                            this._database.ClearParameter();
                            this._database.AddParameter("@PartID", RuntimeHelpers.GetObjectValue(current2["PartID"]), true);
                            this._database.AddParameter("@SupplierID", (object) SupplierID, true);
                            DataTable dataTable3 = this._database.ExecuteSP_DataTable("PartSupplier_GetByPartAndSupplier", true);
                            row["SPN"] = dataTable3.Rows.Count != 0 ? (dataTable3.Rows.Count <= 1 ? (object) dataTable3.Rows[0]["PartCode"].ToString() : (object) "Multi") : (object) "";
                            flag = true;
                          }
                        }
                      }
                      finally
                      {
                        if (enumerator3 is IDisposable)
                          (enumerator3 as IDisposable).Dispose();
                      }
                      if (!flag)
                      {
                        row["Min"] = (object) 0;
                        row["Max"] = (object) 0;
                        row["MinMaxID"] = (object) 0;
                        row["SPN"] = (object) "";
                      }
                    }
                  }
                  else
                  {
                    row["Min"] = (object) 0;
                    row["Max"] = (object) 0;
                    row["MinMaxID"] = (object) 0;
                    row["SPN"] = (object) "";
                  }
                  table.Rows.Add(row);
                }
              }
              finally
              {
                if (enumerator2 is IDisposable)
                  (enumerator2 as IDisposable).Dispose();
              }
            }
          }
        }
        finally
        {
          if (enumerator1 is IDisposable)
            (enumerator1 as IDisposable).Dispose();
        }
        table.TableName = Enums.TableNames.tblPart.ToString();
        return new DataView(table);
      }
      this._database.ClearParameter();
      this._database.AddParameter("@VanID", (object) VanID, true);
      if (ForIPT)
        this._database.AddParameter("@ForIPT", (object) 1, true);
      else
        this._database.AddParameter("@ForIPT", (object) 0, true);
      DataTable table1 = this._database.ExecuteSP_DataTable("Part_GetByVan", true);
      table1.TableName = Enums.TableNames.tblPart.ToString();
      return new DataView(table1);
    }

    public DataTable GetByVan2(int VanID, bool WithLocation = false, bool ForIPT = false, int SupplierID = 0)
    {
      int childSupplier = App.DB.Supplier.GetChildSupplier(SupplierID);
      if ((uint) childSupplier > 0U & childSupplier != SupplierID)
        SupplierID = childSupplier;
      if (WithLocation)
      {
        string Right = App.DB.Van.Van_Get(VanID).Registration.Split('*')[0].Trim();
        DataTable table1 = new DataTable();
        DataTable dataTable = new DataTable();
        int num = 0;
        IEnumerator enumerator;
        try
        {
          enumerator = App.DB.Van.Van_GetAll(false).Table.Rows.GetEnumerator();
          while (enumerator.MoveNext())
          {
            DataRow current = (DataRow) enumerator.Current;
            if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(current["Registration"])).Split('*')[0].Trim(), Right, false) == 0)
            {
              this._database.ClearParameter();
              this._database.AddParameter("@VanID", RuntimeHelpers.GetObjectValue(current[nameof (VanID)]), true);
              this._database.AddParameter("@SupplierID", (object) SupplierID, true);
              this._database.AddParameter("@Location", (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(current["Registration"])).Split('*')[1].Trim(), true);
              if (num == 0)
              {
                table1 = this._database.ExecuteSP_DataTable("Part_VanProfile", true);
              }
              else
              {
                DataTable table2 = this._database.ExecuteSP_DataTable("Part_VanProfile", true);
                table1.Merge(table2);
              }
              checked { ++num; }
            }
          }
        }
        finally
        {
          if (enumerator is IDisposable)
            (enumerator as IDisposable).Dispose();
        }
        table1.TableName = Enums.TableNames.tblPart.ToString();
        return new DataView(table1) { Sort = "Amount ASC" }.Table;
      }
      this._database.ClearParameter();
      this._database.AddParameter("@VanID", (object) VanID, true);
      if (ForIPT)
        this._database.AddParameter("@ForIPT", (object) 1, true);
      else
        this._database.AddParameter("@ForIPT", (object) 0, true);
      DataTable dataTable1 = this._database.ExecuteSP_DataTable("Part_GetByVan", true);
      dataTable1.TableName = Enums.TableNames.tblPart.ToString();
      return dataTable1;
    }

    public DataView GetByWarehouse(int WarehouseID, bool ForIPT = false)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@WarehouseID", (object) WarehouseID, true);
      if (ForIPT)
        this._database.AddParameter("@ForIPT", (object) 1, true);
      else
        this._database.AddParameter("@ForIPT", (object) 0, true);
      DataTable table = this._database.ExecuteSP_DataTable("Part_GetByWarehouse", true);
      table.TableName = Enums.TableNames.tblPart.ToString();
      return new DataView(table);
    }

    public DataView SearchByWarehouse(string SearchString, int LocationID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@SearchString", (object) SearchString, true);
      this._database.AddParameter("@LocationID", (object) LocationID, true);
      DataTable table = this._database.ExecuteSP_DataTable("Part_SearchByWarehouse", true);
      table.TableName = Enums.TableNames.tblPart.ToString();
      return new DataView(table);
    }

    public void Delete(int PartTransactionID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@PartTransactionID", (object) PartTransactionID, true);
      this._database.ExecuteSP_NO_Return("PartTransaction_Delete", true);
    }

    public void Delete(int PartTransactionID, SqlTransaction trans)
    {
      SqlCommand sqlCommand = new SqlCommand();
      sqlCommand.CommandText = "PartTransaction_Delete";
      sqlCommand.CommandType = CommandType.StoredProcedure;
      sqlCommand.Transaction = trans;
      sqlCommand.Connection = trans.Connection;
      sqlCommand.Parameters.AddWithValue("@PartTransactionID", (object) PartTransactionID);
      sqlCommand.ExecuteNonQuery();
    }

    public void DeleteForOrder(int OrderID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@OrderID", (object) OrderID, true);
      this._database.ExecuteSP_NO_Return("PartTransactions_DeleteForOrder", true);
    }

    public void DeleteByPartAndLocation(int PartID, int LocationID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@PartID", (object) PartID, true);
      this._database.AddParameter("@LocationID", (object) LocationID, true);
      this._database.ExecuteSP_NO_Return("PartTransaction_DeleteByPartAndLocation", true);
    }

    public PartTransaction PartTransaction_Get(int PartTransactionID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@PartTransactionID", (object) PartTransactionID, false);
      DataTable dataTable = this._database.ExecuteSP_DataTable(nameof (PartTransaction_Get), true);
      if (dataTable == null || dataTable.Rows.Count <= 0)
        return (PartTransaction) null;
      PartTransaction partTransaction1 = new PartTransaction();
      PartTransaction partTransaction2 = partTransaction1;
      partTransaction2.IgnoreExceptionsOnSetMethods = true;
      partTransaction2.SetPartTransactionID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0][nameof (PartTransactionID)]);
      partTransaction2.SetPartID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["PartID"]);
      partTransaction2.SetAmount = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Amount"]);
      partTransaction2.TransactionDate = Conversions.ToDate(dataTable.Rows[0]["TransactionDate"]);
      partTransaction2.SetUserID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["UserID"]);
      partTransaction2.SetTransactionTypeID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["TransactionTypeID"]);
      partTransaction2.SetLocationID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["LocationID"]);
      partTransaction2.SetOrderPartID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["OrderPartID"]);
      partTransaction2.SetOrderLocationPartID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["OrderLocationPartID"]);
      partTransaction2.SetDeleted = Conversions.ToBoolean(dataTable.Rows[0]["Deleted"]);
      partTransaction1.Exists = true;
      return partTransaction1;
    }

    public DataView PartTransaction_GetAll()
    {
      this._database.ClearParameter();
      DataTable table = this._database.ExecuteSP_DataTable(nameof (PartTransaction_GetAll), true);
      table.TableName = Enums.TableNames.tblPartTransaction.ToString();
      return new DataView(table);
    }

    public PartTransaction Insert(PartTransaction oPartTransaction)
    {
      this._database.ClearParameter();
      this.AddPartTransactionParametersToCommand(oPartTransaction);
      oPartTransaction.SetPartTransactionID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("PartTransaction_Insert", true)));
      oPartTransaction.Exists = true;
      return oPartTransaction;
    }

    public PartTransaction Insert(
      PartTransaction oPartTransaction,
      SqlTransaction trans)
    {
      oPartTransaction.SetPartTransactionID = RuntimeHelpers.GetObjectValue(new SqlCommand()
      {
        CommandText = "PartTransaction_Insert",
        CommandType = CommandType.StoredProcedure,
        Transaction = trans,
        Connection = trans.Connection,
        Parameters = {
          new SqlParameter("@PartID", (object) oPartTransaction.PartID),
          new SqlParameter("@Amount", (object) oPartTransaction.Amount),
          new SqlParameter("@UserID", (object) App.loggedInUser.UserID),
          new SqlParameter("@TransactionTypeID", (object) oPartTransaction.TransactionTypeID),
          new SqlParameter("@LocationID", (object) oPartTransaction.LocationID),
          new SqlParameter("@OrderPartID", (object) oPartTransaction.OrderPartID),
          new SqlParameter("@OrderLocationPartID", (object) oPartTransaction.OrderLocationPartID)
        }
      }.ExecuteScalar());
      oPartTransaction.Exists = true;
      return oPartTransaction;
    }

    public void Update(PartTransaction oPartTransaction)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@PartTransactionID", (object) oPartTransaction.PartTransactionID, true);
      this.AddPartTransactionParametersToCommand(oPartTransaction);
      this._database.ExecuteSP_NO_Return("PartTransaction_Update", true);
    }

    private void AddPartTransactionParametersToCommand(PartTransaction oPartTransaction)
    {
      this._database.AddParameter("@PartID", (object) oPartTransaction.PartID, true);
      this._database.AddParameter("@Amount", (object) oPartTransaction.Amount, true);
      this._database.AddParameter("@UserID", (object) App.loggedInUser.UserID, true);
      this._database.AddParameter("@TransactionTypeID", (object) oPartTransaction.TransactionTypeID, true);
      this._database.AddParameter("@LocationID", (object) oPartTransaction.LocationID, true);
      this._database.AddParameter("@OrderPartID", (object) oPartTransaction.OrderPartID, true);
      this._database.AddParameter("@OrderLocationPartID", (object) oPartTransaction.OrderLocationPartID, true);
    }

    public void UpdateMinMaxValues(int PartLocationID, int MinValue, int MaxValue)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@PartLocationID", (object) PartLocationID, true);
      this._database.AddParameter("@MinQty", (object) MinValue, true);
      this._database.AddParameter("@MaxQty", (object) MaxValue, true);
      this._database.ExecuteSP_NO_Return("PartLocations_UpdateMinMax", true);
    }

    public void PartLocations_Insert(int PartID, int LocationID, int MinValue, int MaxValue)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@PartID", (object) PartID, true);
      this._database.AddParameter("@LocationID", (object) LocationID, true);
      this._database.AddParameter("@MinQty", (object) MinValue, true);
      this._database.AddParameter("@RecQty", (object) MaxValue, true);
      this._database.ExecuteSP_NO_Return(nameof (PartLocations_Insert), true);
    }

    public int PartLocations_Insert2(int PartID, int LocationID, int MinValue, int MaxValue)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@PartID", (object) PartID, true);
      this._database.AddParameter("@LocationID", (object) LocationID, true);
      this._database.AddParameter("@MinQty", (object) MinValue, true);
      this._database.AddParameter("@RecQty", (object) MaxValue, true);
      return Conversions.ToInteger(this._database.ExecuteSP_OBJECT("PartLocations_Insert_WithPartLocationReturn", true));
    }
  }
}
