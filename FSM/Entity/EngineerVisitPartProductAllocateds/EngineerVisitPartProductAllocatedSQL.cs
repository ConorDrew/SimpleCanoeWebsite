// Decompiled with JetBrains decompiler
// Type: FSM.Entity.EngineerVisitPartProductAllocateds.EngineerVisitPartProductAllocatedSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.OrderParts;
using FSM.Entity.PartsToBeCrediteds;
using FSM.Entity.PartSuppliers;
using FSM.Entity.PartTransactions;
using FSM.Entity.ProductTransactions;
using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM.Entity.EngineerVisitPartProductAllocateds
{
  public class EngineerVisitPartProductAllocatedSQL
  {
    private Database _database;

    public EngineerVisitPartProductAllocatedSQL(Database database)
    {
      this._database = database;
    }

    public DataView EngineerVisitPartAndProductsAllocated_GetAll_For_Engineer_Visit(
      int EngineerVisitID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@EngineerVisitID", (object) EngineerVisitID, true);
      this._database.AddParameter("@OrderLocationSupplierEnumValue", (object) Enums.LocationType.Supplier, true);
      DataTable table = this._database.ExecuteSP_DataTable("EngineerVisitPartsAndProductsAllocated_GetAll_For_Engineer_Visit2", true);
      table.TableName = Enums.TableNames.NOT_IN_DATABASE_tblEngineerVisitPartAndProductAllocated.ToString();
      return new DataView(table);
    }

    public DataView EngineerVisitPartAndProductsAllocated_GetAll_For_Engineer_Visit(
      int EngineerVisitID,
      SqlTransaction trans)
    {
      SqlCommand selectCommand = new SqlCommand();
      selectCommand.CommandText = "EngineerVisitPartsAndProductsAllocated_GetAll_For_Engineer_Visit";
      selectCommand.CommandType = CommandType.StoredProcedure;
      selectCommand.Transaction = trans;
      selectCommand.Connection = trans.Connection;
      selectCommand.Parameters.AddWithValue("@EngineerVisitID", (object) EngineerVisitID);
      selectCommand.Parameters.AddWithValue("@OrderLocationSupplierEnumValue", (object) Enums.LocationType.Supplier);
      SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
      DataSet dataSet = new DataSet();
      sqlDataAdapter.Fill(dataSet);
      DataTable table = dataSet.Tables[0];
      table.TableName = Enums.TableNames.NOT_IN_DATABASE_tblEngineerVisitPartAndProductAllocated.ToString();
      return new DataView(table);
    }

    public DataTable EngineerVisitPartAllocated_MoveVisit(
      int OldEngineerVisitID,
      int NewEngineerVisitID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@OldEngineerVisitID", (object) OldEngineerVisitID, true);
      this._database.AddParameter("@NewEngineerVisitID", (object) NewEngineerVisitID, true);
      return this._database.ExecuteSP_DataTable(nameof (EngineerVisitPartAllocated_MoveVisit), true);
    }

    public void Insert(
      DataView PartsAndProducts,
      int EngineerVisitID,
      int JobID,
      SqlTransaction trans)
    {
      if (PartsAndProducts.Table == null)
        return;
      DataTable table = new DataTable();
      table.Columns.Add("Type");
      table.Columns.Add("ID");
      table.Columns.Add(nameof (EngineerVisitID));
      table.Columns.Add("PartProductID");
      table.Columns.Add("Name");
      table.Columns.Add("Number");
      table.Columns.Add("Quantity");
      table.Columns.Add("OrderItemID");
      table.Columns.Add("OrderLocationTypeID");
      table.Columns.Add("SellPrice");
      DataTable dataTable = new DataTable();
      dataTable.Columns.Add("Type");
      dataTable.Columns.Add("ID");
      dataTable.Columns.Add(nameof (EngineerVisitID));
      dataTable.Columns.Add("PartProductID");
      dataTable.Columns.Add("Name");
      dataTable.Columns.Add("Number");
      dataTable.Columns.Add("Quantity");
      dataTable.Columns.Add("OrderItemID");
      dataTable.Columns.Add("OrderLocationTypeID");
      dataTable.Columns.Add("SellPrice");
      string str = "";
      IEnumerator enumerator1;
      try
      {
        enumerator1 = PartsAndProducts.Table.Rows.GetEnumerator();
        while (enumerator1.MoveNext())
        {
          DataRow current = (DataRow) enumerator1.Current;
          if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current["OrderItemID"], (object) 0, false))
          {
            str = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object) str, Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) " * ", current["Name"]), (object) ", "), current["Number"]), (object) ", "), current["Quantity"]), (object) "\r\n")));
            DataRow row = table.NewRow();
            row["Type"] = RuntimeHelpers.GetObjectValue(current["Type"]);
            row["ID"] = RuntimeHelpers.GetObjectValue(current["ID"]);
            row[nameof (EngineerVisitID)] = (object) EngineerVisitID;
            row["PartProductID"] = RuntimeHelpers.GetObjectValue(current["PartProductID"]);
            row["Name"] = RuntimeHelpers.GetObjectValue(current["Name"]);
            row["Number"] = RuntimeHelpers.GetObjectValue(current["Number"]);
            row["Quantity"] = RuntimeHelpers.GetObjectValue(current["Quantity"]);
            row["OrderItemID"] = RuntimeHelpers.GetObjectValue(current["OrderItemID"]);
            row["OrderLocationTypeID"] = RuntimeHelpers.GetObjectValue(current["OrderLocationTypeID"]);
            row["SellPrice"] = RuntimeHelpers.GetObjectValue(current["SellPrice"]);
            table.Rows.Add(row);
          }
          else
          {
            DataRow row = dataTable.NewRow();
            row["Type"] = RuntimeHelpers.GetObjectValue(current["Type"]);
            row["ID"] = RuntimeHelpers.GetObjectValue(current["ID"]);
            row[nameof (EngineerVisitID)] = (object) EngineerVisitID;
            row["PartProductID"] = RuntimeHelpers.GetObjectValue(current["PartProductID"]);
            row["Name"] = RuntimeHelpers.GetObjectValue(current["Name"]);
            row["Number"] = RuntimeHelpers.GetObjectValue(current["Number"]);
            row["Quantity"] = RuntimeHelpers.GetObjectValue(current["Quantity"]);
            row["OrderItemID"] = RuntimeHelpers.GetObjectValue(current["OrderItemID"]);
            row["OrderLocationTypeID"] = RuntimeHelpers.GetObjectValue(current["OrderLocationTypeID"]);
            row["SellPrice"] = RuntimeHelpers.GetObjectValue(current["SellPrice"]);
            dataTable.Rows.Add(row);
          }
        }
      }
      finally
      {
        if (enumerator1 is IDisposable)
          (enumerator1 as IDisposable).Dispose();
      }
      if (str.Length > 0 && MessageBox.Show("The following Parts/Products have been allocated to a visit and have not been ordered: \r\n" + str + "\r\n Would you like to create an order now?", "Order", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        App.ShowForm(typeof (FRMConvertToAnOrder), true, new object[6]
        {
          (object) 4,
          (object) JobID,
          (object) new DataView(table),
          (object) 0,
          (object) EngineerVisitID,
          (object) trans
        }, false);
      new SqlCommand()
      {
        CommandText = "EngineerVisitPartsAndProductsAllocated_Delete",
        CommandType = CommandType.StoredProcedure,
        Transaction = trans,
        Connection = trans.Connection,
        Parameters = {
          new SqlParameter("@EngineerVisitID", (object) EngineerVisitID)
        }
      }.ExecuteNonQuery();
      IEnumerator enumerator2;
      try
      {
        enumerator2 = dataTable.Rows.GetEnumerator();
        while (enumerator2.MoveNext())
        {
          DataRow current = (DataRow) enumerator2.Current;
          this.InsertOne(EngineerVisitID, Conversions.ToString(current["Type"]), Conversions.ToInteger(current["Quantity"]), Conversions.ToInteger(current["OrderItemID"]), Conversions.ToInteger(current["PartProductID"]), Conversions.ToInteger(current["OrderLocationTypeID"]), trans);
        }
      }
      finally
      {
        if (enumerator2 is IDisposable)
          (enumerator2 as IDisposable).Dispose();
      }
      IEnumerator enumerator3;
      try
      {
        enumerator3 = table.Rows.GetEnumerator();
        while (enumerator3.MoveNext())
        {
          DataRow current = (DataRow) enumerator3.Current;
          current.AcceptChanges();
          if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(current["Quantity"])))
            current["Quantity"] = RuntimeHelpers.GetObjectValue(current["QuantityToOrder"]);
          this.InsertOne(EngineerVisitID, Conversions.ToString(current["Type"]), Conversions.ToInteger(current["Quantity"]), Conversions.ToInteger(current["OrderItemID"]), Conversions.ToInteger(current["PartProductID"]), Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(current["OrderLocationTypeID"])), trans);
        }
      }
      finally
      {
        if (enumerator3 is IDisposable)
          (enumerator3 as IDisposable).Dispose();
      }
    }

    public void NewInsert(
      DataView PartsAndProducts,
      int EngineerVisitID,
      int JobID,
      SqlTransaction trans)
    {
      if (PartsAndProducts.Table == null)
        return;
      IEnumerator enumerator;
      try
      {
        enumerator = PartsAndProducts.Table.Rows.GetEnumerator();
        while (enumerator.MoveNext())
        {
          DataRow current = (DataRow) enumerator.Current;
          int num = this.InsertOne(EngineerVisitID, Conversions.ToString(current["Type"]), Conversions.ToInteger(current["Quantity"]), 0, Conversions.ToInteger(current["PartProductID"]), 0, trans);
          current["ID"] = (object) num;
          current.AcceptChanges();
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
    }

    public void SplitToOrder(DataView PartsAndProducts, int EngineerVisitID, int JobID)
    {
      if (PartsAndProducts.Table == null)
        return;
      DataTable table = new DataTable();
      table.Columns.Add("Type");
      table.Columns.Add("ID");
      table.Columns.Add(nameof (EngineerVisitID));
      table.Columns.Add("PartProductID");
      table.Columns.Add("Name");
      table.Columns.Add("Number");
      table.Columns.Add("Quantity");
      table.Columns.Add("OrderItemID");
      table.Columns.Add("OrderLocationTypeID");
      table.Columns.Add("SellPrice");
      DataTable dataTable = new DataTable();
      dataTable.Columns.Add("Type");
      dataTable.Columns.Add("ID");
      dataTable.Columns.Add(nameof (EngineerVisitID));
      dataTable.Columns.Add("PartProductID");
      dataTable.Columns.Add("Name");
      dataTable.Columns.Add("Number");
      dataTable.Columns.Add("Quantity");
      dataTable.Columns.Add("OrderItemID");
      dataTable.Columns.Add("OrderLocationTypeID");
      dataTable.Columns.Add("SellPrice");
      string str = "";
      IEnumerator enumerator;
      try
      {
        enumerator = PartsAndProducts.Table.Rows.GetEnumerator();
        while (enumerator.MoveNext())
        {
          DataRow current = (DataRow) enumerator.Current;
          if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current["OrderItemID"], (object) 0, false))
          {
            str = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object) str, Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) " * ", current["Name"]), (object) ", "), current["Number"]), (object) ", "), current["Quantity"]), (object) "\r\n")));
            DataRow row = table.NewRow();
            row["Type"] = RuntimeHelpers.GetObjectValue(current["Type"]);
            row["ID"] = RuntimeHelpers.GetObjectValue(current["ID"]);
            row[nameof (EngineerVisitID)] = (object) EngineerVisitID;
            row["PartProductID"] = RuntimeHelpers.GetObjectValue(current["PartProductID"]);
            row["Name"] = RuntimeHelpers.GetObjectValue(current["Name"]);
            row["Number"] = RuntimeHelpers.GetObjectValue(current["Number"]);
            row["Quantity"] = RuntimeHelpers.GetObjectValue(current["Quantity"]);
            row["OrderItemID"] = RuntimeHelpers.GetObjectValue(current["OrderItemID"]);
            row["OrderLocationTypeID"] = RuntimeHelpers.GetObjectValue(current["OrderLocationTypeID"]);
            row["SellPrice"] = RuntimeHelpers.GetObjectValue(current["SellPrice"]);
            table.Rows.Add(row);
          }
          else
          {
            DataRow row = dataTable.NewRow();
            row["Type"] = RuntimeHelpers.GetObjectValue(current["Type"]);
            row["ID"] = RuntimeHelpers.GetObjectValue(current["ID"]);
            row[nameof (EngineerVisitID)] = (object) EngineerVisitID;
            row["PartProductID"] = RuntimeHelpers.GetObjectValue(current["PartProductID"]);
            row["Name"] = RuntimeHelpers.GetObjectValue(current["Name"]);
            row["Number"] = RuntimeHelpers.GetObjectValue(current["Number"]);
            row["Quantity"] = RuntimeHelpers.GetObjectValue(current["Quantity"]);
            row["OrderItemID"] = RuntimeHelpers.GetObjectValue(current["OrderItemID"]);
            row["OrderLocationTypeID"] = RuntimeHelpers.GetObjectValue(current["OrderLocationTypeID"]);
            row["SellPrice"] = RuntimeHelpers.GetObjectValue(current["SellPrice"]);
            dataTable.Rows.Add(row);
          }
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      if (str.Length > 0 && MessageBox.Show("The following Parts/Products have been allocated to a visit and have not been ordered: \r\n" + str + "\r\n Would you like to create an order now?", "Order", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        App.ShowForm(typeof (FRMConvertToAnOrder), true, new object[6]
        {
          (object) 4,
          (object) JobID,
          (object) new DataView(table),
          (object) 0,
          (object) EngineerVisitID,
          (object) true
        }, false);
    }

    public void Insert(DataView PartsAndProducts, int EngineerVisitID, int JobID)
    {
      if (PartsAndProducts.Table == null)
        return;
      DataTable table = new DataTable();
      table.Columns.Add("Type");
      table.Columns.Add("ID");
      table.Columns.Add(nameof (EngineerVisitID));
      table.Columns.Add("PartProductID");
      table.Columns.Add("Name");
      table.Columns.Add("Number");
      table.Columns.Add("Quantity");
      table.Columns.Add("OrderItemID");
      table.Columns.Add("OrderLocationTypeID");
      table.Columns.Add("SellPrice");
      DataTable dataTable = new DataTable();
      dataTable.Columns.Add("Type");
      dataTable.Columns.Add("ID");
      dataTable.Columns.Add(nameof (EngineerVisitID));
      dataTable.Columns.Add("PartProductID");
      dataTable.Columns.Add("Name");
      dataTable.Columns.Add("Number");
      dataTable.Columns.Add("Quantity");
      dataTable.Columns.Add("OrderItemID");
      dataTable.Columns.Add("OrderLocationTypeID");
      dataTable.Columns.Add("SellPrice");
      string str = "";
      IEnumerator enumerator1;
      try
      {
        enumerator1 = PartsAndProducts.Table.Rows.GetEnumerator();
        while (enumerator1.MoveNext())
        {
          DataRow current = (DataRow) enumerator1.Current;
          if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current["OrderItemID"], (object) 0, false))
          {
            str = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object) str, Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) " * ", current["Name"]), (object) ", "), current["Number"]), (object) ", "), current["Quantity"]), (object) "\r\n")));
            DataRow row = table.NewRow();
            row["Type"] = RuntimeHelpers.GetObjectValue(current["Type"]);
            row["ID"] = RuntimeHelpers.GetObjectValue(current["ID"]);
            row[nameof (EngineerVisitID)] = (object) EngineerVisitID;
            row["PartProductID"] = RuntimeHelpers.GetObjectValue(current["PartProductID"]);
            row["Name"] = RuntimeHelpers.GetObjectValue(current["Name"]);
            row["Number"] = RuntimeHelpers.GetObjectValue(current["Number"]);
            row["Quantity"] = RuntimeHelpers.GetObjectValue(current["Quantity"]);
            row["OrderItemID"] = RuntimeHelpers.GetObjectValue(current["OrderItemID"]);
            row["OrderLocationTypeID"] = RuntimeHelpers.GetObjectValue(current["OrderLocationTypeID"]);
            row["SellPrice"] = RuntimeHelpers.GetObjectValue(current["SellPrice"]);
            table.Rows.Add(row);
          }
          else
          {
            DataRow row = dataTable.NewRow();
            row["Type"] = RuntimeHelpers.GetObjectValue(current["Type"]);
            row["ID"] = RuntimeHelpers.GetObjectValue(current["ID"]);
            row[nameof (EngineerVisitID)] = (object) EngineerVisitID;
            row["PartProductID"] = RuntimeHelpers.GetObjectValue(current["PartProductID"]);
            row["Name"] = RuntimeHelpers.GetObjectValue(current["Name"]);
            row["Number"] = RuntimeHelpers.GetObjectValue(current["Number"]);
            row["Quantity"] = RuntimeHelpers.GetObjectValue(current["Quantity"]);
            row["OrderItemID"] = RuntimeHelpers.GetObjectValue(current["OrderItemID"]);
            row["OrderLocationTypeID"] = RuntimeHelpers.GetObjectValue(current["OrderLocationTypeID"]);
            row["SellPrice"] = RuntimeHelpers.GetObjectValue(current["SellPrice"]);
            dataTable.Rows.Add(row);
          }
        }
      }
      finally
      {
        if (enumerator1 is IDisposable)
          (enumerator1 as IDisposable).Dispose();
      }
      if (str.Length > 0 && MessageBox.Show("The following Parts/Products have been allocated to a visit and have not been ordered: \r\n" + str + "\r\n Would you like to create an order now?", "Order", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        App.ShowForm(typeof (FRMConvertToAnOrder), true, new object[5]
        {
          (object) 4,
          (object) JobID,
          (object) new DataView(table),
          (object) 0,
          (object) EngineerVisitID
        }, false);
      this._database.ClearParameter();
      this._database.AddParameter("@EngineerVisitID", (object) EngineerVisitID, true);
      this._database.ExecuteSP_OBJECT("EngineerVisitPartsAndProductsAllocated_Delete", true);
      IEnumerator enumerator2;
      try
      {
        enumerator2 = dataTable.Rows.GetEnumerator();
        while (enumerator2.MoveNext())
        {
          DataRow current = (DataRow) enumerator2.Current;
          this.InsertOne(EngineerVisitID, Conversions.ToString(current["Type"]), Conversions.ToInteger(current["Quantity"]), Conversions.ToInteger(current["OrderItemID"]), Conversions.ToInteger(current["PartProductID"]), Conversions.ToInteger(current["OrderLocationTypeID"]));
        }
      }
      finally
      {
        if (enumerator2 is IDisposable)
          (enumerator2 as IDisposable).Dispose();
      }
      IEnumerator enumerator3;
      try
      {
        enumerator3 = table.Rows.GetEnumerator();
        while (enumerator3.MoveNext())
        {
          DataRow current = (DataRow) enumerator3.Current;
          current.AcceptChanges();
          if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(current["Quantity"])))
            current["Quantity"] = RuntimeHelpers.GetObjectValue(current["QuantityToOrder"]);
          this.InsertOne(EngineerVisitID, Conversions.ToString(current["Type"]), Conversions.ToInteger(current["Quantity"]), Conversions.ToInteger(current["OrderItemID"]), Conversions.ToInteger(current["PartProductID"]), Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(current["OrderLocationTypeID"])));
        }
      }
      finally
      {
        if (enumerator3 is IDisposable)
          (enumerator3 as IDisposable).Dispose();
      }
    }

    public void InsertOne(
      int EngineerVisitID,
      string type,
      int Quantity,
      int OrderItemID,
      int PartProductID,
      int OrderLocationTypeID)
    {
      string SPName = "";
      this._database.ClearParameter();
      this._database.AddParameter("@EngineerVisitID", (object) EngineerVisitID, true);
      this._database.AddParameter("@Quantity", (object) Quantity, true);
      this._database.AddParameter("@OrderLocationTypeID", (object) OrderLocationTypeID, true);
      string Left = type;
      if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "Part", false) != 0)
      {
        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "Product", false) == 0)
        {
          this._database.AddParameter("@ProductID", (object) PartProductID, true);
          this._database.AddParameter("@OrderProductID", (object) OrderItemID, true);
          SPName = "EngineerVisitProductAllocated_Insert";
        }
      }
      else
      {
        this._database.AddParameter("@PartID", (object) PartProductID, true);
        this._database.AddParameter("@OrderPartID", (object) OrderItemID, true);
        SPName = "EngineerVisitPartAllocated_Insert";
      }
      this._database.ExecuteSP_OBJECT(SPName, true);
    }

    public int InsertOne(
      int EngineerVisitID,
      string type,
      int Quantity,
      int OrderItemID,
      int PartProductID,
      int OrderLocationTypeID,
      SqlTransaction trans)
    {
      SqlCommand sqlCommand = new SqlCommand();
      sqlCommand.CommandType = CommandType.StoredProcedure;
      string Left = type;
      if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "Part", false) != 0)
      {
        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "Product", false) == 0)
        {
          sqlCommand.CommandText = "EngineerVisitProductAllocated_Insert";
          sqlCommand.Parameters.Add(new SqlParameter("@ProductID", (object) PartProductID));
          sqlCommand.Parameters.Add(new SqlParameter("@OrderProductID", (object) OrderItemID));
        }
      }
      else
      {
        sqlCommand.CommandText = "EngineerVisitPartAllocated_Insert";
        sqlCommand.Parameters.Add(new SqlParameter("@PartID", (object) PartProductID));
        sqlCommand.Parameters.Add(new SqlParameter("@OrderPartID", (object) OrderItemID));
      }
      sqlCommand.Transaction = trans;
      sqlCommand.Connection = trans.Connection;
      sqlCommand.Parameters.Add(new SqlParameter("@EngineerVisitID", (object) EngineerVisitID));
      sqlCommand.Parameters.Add(new SqlParameter("@Quantity", (object) Quantity));
      sqlCommand.Parameters.Add(new SqlParameter("@OrderLocationTypeID", (object) OrderLocationTypeID));
      return Conversions.ToInteger(sqlCommand.ExecuteScalar());
    }

    public void UpdateOne(
      int AllocationID,
      int EngineerVisitID,
      string type,
      int Quantity,
      int OrderItemID,
      int PartProductID,
      int OrderLocationTypeID)
    {
      string SPName = "";
      this._database.ClearParameter();
      this._database.AddParameter("@EngineerVisitID", (object) EngineerVisitID, true);
      this._database.AddParameter("@Quantity", (object) Quantity, true);
      this._database.AddParameter("@OrderLocationTypeID", (object) OrderLocationTypeID, true);
      string Left = type;
      if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "Part", false) != 0)
      {
        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "Product", false) == 0)
        {
          this._database.AddParameter("@EngineerVisitProductAllocatedID", (object) AllocationID, true);
          this._database.AddParameter("@ProductID", (object) PartProductID, true);
          this._database.AddParameter("@OrderProductID", (object) OrderItemID, true);
          SPName = "EngineerVisitProductAllocated_Update";
        }
      }
      else
      {
        this._database.AddParameter("@EngineerVisitPartAllocatedID", (object) AllocationID, true);
        this._database.AddParameter("@PartID", (object) PartProductID, true);
        this._database.AddParameter("@OrderPartID", (object) OrderItemID, true);
        SPName = "EngineerVisitPartAllocated_Update";
      }
      this._database.ExecuteSP_OBJECT(SPName, true);
    }

    public void UpdateOne(
      int AllocationID,
      int EngineerVisitID,
      string type,
      int Quantity,
      int OrderItemID,
      int PartProductID,
      int OrderLocationTypeID,
      SqlTransaction trans)
    {
      SqlCommand sqlCommand = new SqlCommand();
      sqlCommand.CommandType = CommandType.StoredProcedure;
      string Left = type;
      if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "Part", false) != 0)
      {
        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "Product", false) == 0)
        {
          sqlCommand.CommandText = "EngineerVisitProductAllocated_Update";
          sqlCommand.Parameters.Add(new SqlParameter("@EngineerVisitProductAllocatedID", (object) AllocationID));
          sqlCommand.Parameters.Add(new SqlParameter("@ProductID", (object) PartProductID));
          sqlCommand.Parameters.Add(new SqlParameter("@OrderProductID", (object) OrderItemID));
        }
      }
      else
      {
        sqlCommand.CommandText = "EngineerVisitPartAllocated_Update";
        sqlCommand.Parameters.Add(new SqlParameter("@EngineerVisitPartAllocatedID", (object) AllocationID));
        sqlCommand.Parameters.Add(new SqlParameter("@PartID", (object) PartProductID));
        sqlCommand.Parameters.Add(new SqlParameter("@OrderPartID", (object) OrderItemID));
      }
      sqlCommand.Transaction = trans;
      sqlCommand.Connection = trans.Connection;
      sqlCommand.Parameters.Add(new SqlParameter("@EngineerVisitID", (object) EngineerVisitID));
      sqlCommand.Parameters.Add(new SqlParameter("@Quantity", (object) Quantity));
      sqlCommand.Parameters.Add(new SqlParameter("@OrderLocationTypeID", (object) OrderLocationTypeID));
      sqlCommand.ExecuteNonQuery();
    }

    public void EngineerVisitProductAllocated_Delete(int OrderLocationTypeID, int OrderProductID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@OrderProductID", (object) OrderProductID, true);
      this._database.AddParameter("@OrderLocationTypeID", (object) OrderLocationTypeID, true);
      this._database.AddParameter("@SupplierOrderLocationEnumValue", (object) 1, true);
      App.DB.ExecuteSP_NO_Return(nameof (EngineerVisitProductAllocated_Delete), true);
    }

    public void EngineerVisitPartAllocated_Delete(int OrderLocationTypeID, int OrderPartID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@OrderPartID", (object) OrderPartID, true);
      this._database.AddParameter("@OrderLocationTypeID", (object) OrderLocationTypeID, true);
      this._database.AddParameter("@SupplierOrderLocationEnumValue", (object) 1, true);
      App.DB.ExecuteSP_NO_Return(nameof (EngineerVisitPartAllocated_Delete), true);
    }

    public void EngineerVisitPartAllocated_DeleteByID(
      int EngineerVisitPartAllocatedID,
      DataView PartsAndProductsDistribution)
    {
      IEnumerator enumerator;
      try
      {
        enumerator = PartsAndProductsDistribution.Table.Rows.GetEnumerator();
        while (enumerator.MoveNext())
        {
          DataRow current = (DataRow) enumerator.Current;
          if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current["StockTransactionType"], (object) -1, false))
          {
            PartsToBeCredited oPartsToBeCredited = new PartsToBeCredited();
            oPartsToBeCredited.IgnoreExceptionsOnSetMethods = true;
            OrderPart orderPart = App.DB.OrderPart.OrderPart_Get(Conversions.ToInteger(current["OrderPartProductID"]));
            PartSupplier partSupplier = App.DB.PartSupplier.PartSupplier_Get(orderPart.PartSupplierID);
            oPartsToBeCredited.SetOrderID = (object) orderPart.OrderID;
            oPartsToBeCredited.SetSupplierID = (object) partSupplier.SupplierID;
            oPartsToBeCredited.SetPartID = RuntimeHelpers.GetObjectValue(current["PartProductID"]);
            oPartsToBeCredited.SetQty = RuntimeHelpers.GetObjectValue(current["Quantity"]);
            oPartsToBeCredited.SetStatusID = (object) 1;
            oPartsToBeCredited.SetManuallyAdded = (object) false;
            oPartsToBeCredited.SetOrderReference = (object) App.DB.Order.Order_Get(orderPart.OrderID).OrderReference;
            App.DB.PartsToBeCredited.Insert(oPartsToBeCredited);
          }
          if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.AndObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectGreater(current["LocationID"], (object) 0, false), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectGreater(current["StockTransactionType"], (object) 0, false))))
          {
            object Left = current["Type"];
            if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(Left, (object) "Part", false))
              App.DB.PartTransaction.Insert(new PartTransaction()
              {
                SetLocationID = RuntimeHelpers.GetObjectValue(current["LocationID"]),
                SetPartID = RuntimeHelpers.GetObjectValue(current["PartProductID"]),
                SetOrderPartID = RuntimeHelpers.GetObjectValue(current["OrderPartProductID"]),
                SetAmount = Conversions.ToInteger(current["StockTransactionType"]) != 3 ? RuntimeHelpers.GetObjectValue(current["Quantity"]) : Microsoft.VisualBasic.CompilerServices.Operators.MultiplyObject(current["Quantity"], (object) -1),
                SetTransactionTypeID = RuntimeHelpers.GetObjectValue(current["StockTransactionType"])
              });
            else if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(Left, (object) "Product", false))
              App.DB.ProductTransaction.Insert(new ProductTransaction()
              {
                SetLocationID = RuntimeHelpers.GetObjectValue(current["LocationID"]),
                SetProductID = RuntimeHelpers.GetObjectValue(current["PartProductID"]),
                SetOrderProductID = RuntimeHelpers.GetObjectValue(current["OrderPartProductID"]),
                SetAmount = Conversions.ToInteger(current["StockTransactionType"]) != 3 ? RuntimeHelpers.GetObjectValue(current["Quantity"]) : Microsoft.VisualBasic.CompilerServices.Operators.MultiplyObject(current["Quantity"], (object) -1),
                SetTransactionTypeID = RuntimeHelpers.GetObjectValue(current["StockTransactionType"])
              });
          }
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      this._database.ClearParameter();
      this._database.AddParameter("@EngineerVisitPartAllocatedID", (object) EngineerVisitPartAllocatedID, true);
      App.DB.ExecuteSP_NO_Return(nameof (EngineerVisitPartAllocated_DeleteByID), true);
    }

    public void EngineerVisitPartAllocated_RemoveFromOrder(int OrderLocationTypeID, int OrderPartID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@OrderPartID", (object) OrderPartID, true);
      this._database.AddParameter("@OrderLocationTypeID", (object) OrderLocationTypeID, true);
      this._database.AddParameter("@SupplierOrderLocationEnumValue", (object) 1, true);
      App.DB.ExecuteSP_NO_Return(nameof (EngineerVisitPartAllocated_RemoveFromOrder), true);
    }

    public DataView Get_ByJobId(int jobId)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@JobID", (object) jobId, true);
      DataTable table = this._database.ExecuteSP_DataTable("EngineerVisitPartAllocated_Get_ByJobId", true);
      table.TableName = Enums.TableNames.NOT_IN_DATABASE_PartsAndProducts.ToString();
      return new DataView(table);
    }
  }
}
