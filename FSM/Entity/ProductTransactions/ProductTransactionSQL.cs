// Decompiled with JetBrains decompiler
// Type: FSM.Entity.ProductTransactions.ProductTransactionSQL
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

namespace FSM.Entity.ProductTransactions
{
    public class ProductTransactionSQL
    {
        private Database _database;

        public ProductTransactionSQL(Database database)
        {
            this._database = database;
        }

        public ProductTransaction ProductTransaction_GetByOrderLocationProduct(
          int OrderLocationProductID,
          SqlTransaction trans)
        {
            SqlCommand selectCommand = new SqlCommand();
            selectCommand.CommandText = nameof(ProductTransaction_GetByOrderLocationProduct);
            selectCommand.CommandType = CommandType.StoredProcedure;
            selectCommand.Transaction = trans;
            selectCommand.Connection = trans.Connection;
            selectCommand.Parameters.AddWithValue("@OrderLocationProductID", (object)OrderLocationProductID);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            DataTable table = dataSet.Tables[0];
            if (table == null || table.Rows.Count <= 0)
                return (ProductTransaction)null;
            ProductTransaction productTransaction1 = new ProductTransaction();
            ProductTransaction productTransaction2 = productTransaction1;
            productTransaction2.IgnoreExceptionsOnSetMethods = true;
            productTransaction2.SetProductTransactionID = RuntimeHelpers.GetObjectValue(table.Rows[0]["ProductTransactionID"]);
            productTransaction2.SetProductID = RuntimeHelpers.GetObjectValue(table.Rows[0]["ProductID"]);
            productTransaction2.SetAmount = RuntimeHelpers.GetObjectValue(table.Rows[0]["Amount"]);
            productTransaction2.TransactionDate = Conversions.ToDate(table.Rows[0]["TransactionDate"]);
            productTransaction2.SetUserID = RuntimeHelpers.GetObjectValue(table.Rows[0]["UserID"]);
            productTransaction2.SetTransactionTypeID = RuntimeHelpers.GetObjectValue(table.Rows[0]["TransactionTypeID"]);
            productTransaction2.SetLocationID = RuntimeHelpers.GetObjectValue(table.Rows[0]["LocationID"]);
            productTransaction2.SetOrderProductID = RuntimeHelpers.GetObjectValue(table.Rows[0]["OrderProductID"]);
            productTransaction2.SetOrderLocationProductID = RuntimeHelpers.GetObjectValue(table.Rows[0][nameof(OrderLocationProductID)]);
            productTransaction2.SetDeleted = Conversions.ToBoolean(table.Rows[0]["Deleted"]);
            productTransaction1.Exists = true;
            return productTransaction1;
        }

        public ProductTransaction ProductTransaction_GetByOrderLocationProduct(
          int OrderLocationProductID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@OrderLocationProductID", (object)OrderLocationProductID, false);
            DataTable dataTable = this._database.ExecuteSP_DataTable(nameof(ProductTransaction_GetByOrderLocationProduct), true);
            if (dataTable == null || dataTable.Rows.Count <= 0)
                return (ProductTransaction)null;
            ProductTransaction productTransaction1 = new ProductTransaction();
            ProductTransaction productTransaction2 = productTransaction1;
            productTransaction2.IgnoreExceptionsOnSetMethods = true;
            productTransaction2.SetProductTransactionID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ProductTransactionID"]);
            productTransaction2.SetProductID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ProductID"]);
            productTransaction2.SetAmount = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Amount"]);
            productTransaction2.TransactionDate = Conversions.ToDate(dataTable.Rows[0]["TransactionDate"]);
            productTransaction2.SetUserID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["UserID"]);
            productTransaction2.SetTransactionTypeID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["TransactionTypeID"]);
            productTransaction2.SetLocationID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["LocationID"]);
            productTransaction2.SetOrderProductID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["OrderProductID"]);
            productTransaction2.SetOrderLocationProductID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0][nameof(OrderLocationProductID)]);
            productTransaction2.SetDeleted = Conversions.ToBoolean(dataTable.Rows[0]["Deleted"]);
            productTransaction1.Exists = true;
            return productTransaction1;
        }

        public object ProductTransaction_Consolidate_All(int LocationID, int ProductID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@LocationID", (object)LocationID, true);
            this._database.AddParameter("@ProductID", (object)ProductID, true);
            this._database.ExecuteSP_NO_Return(nameof(ProductTransaction_Consolidate_All), true);
            object obj = null;
            return obj;
        }

        public DataView SearchByVan(string SearchString, int LocationID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@SearchString", (object)SearchString, true);
            this._database.AddParameter("@LocationID", (object)LocationID, true);
            DataTable table = this._database.ExecuteSP_DataTable("Product_SearchByVan", true);
            table.TableName = Enums.TableNames.tblProduct.ToString();
            return new DataView(table);
        }

        public DataView GetByVan(int VanID, bool WithLocation = false)
        {
            if (WithLocation)
            {
                string Right = App.DB.Van.Van_Get(VanID).Registration.Split('*')[0].Trim();
                DataTable table = new DataTable();
                table.Columns.Add(new DataColumn("Location"));
                table.Columns.Add(new DataColumn("ProductID", Type.GetType("System.Int32")));
                table.Columns.Add(new DataColumn("typemakemodel"));
                table.Columns.Add(new DataColumn("ProductNumber"));
                table.Columns.Add(new DataColumn("Amount", Type.GetType("System.Int32")));
                table.Columns.Add(new DataColumn("LocationID", Type.GetType("System.Int32")));

                foreach (DataRow current1 in App.DB.Van.Van_GetAll(false).Table.Rows)
                {
                    if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(current1["Registration"])).Split('*')[0].Trim(), Right, false) == 0)
                    {
                        this._database.ClearParameter();
                        this._database.AddParameter("@VanID", RuntimeHelpers.GetObjectValue(current1[nameof(VanID)]), true);

                        foreach (DataRow current2 in this._database.ExecuteSP_DataTable("Product_GetByVan", true).Rows)
                        {
                            DataRow row = table.NewRow();
                            row["Location"] = (object)Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(current1["Registration"])).Split('*')[1].Trim();
                            row["ProductID"] = RuntimeHelpers.GetObjectValue(current2["ProductID"]);
                            row["typemakemodel"] = RuntimeHelpers.GetObjectValue(current2["typemakemodel"]);
                            row["ProductNumber"] = RuntimeHelpers.GetObjectValue(current2["ProductNumber"]);
                            row["Amount"] = RuntimeHelpers.GetObjectValue(current2["Amount"]);
                            row["LocationID"] = RuntimeHelpers.GetObjectValue(current2["LocationID"]);
                            table.Rows.Add(row);
                        }
                    }
                }
                table.TableName = Enums.TableNames.tblProduct.ToString();
                return new DataView(table);
            }
            this._database.ClearParameter();
            this._database.AddParameter("@VanID", (object)VanID, true);
            DataTable table1 = this._database.ExecuteSP_DataTable("Product_GetByVan", true);
            table1.TableName = Enums.TableNames.tblProduct.ToString();
            return new DataView(table1);
        }

        public DataView GetByWarehouse(int WarehouseID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@WarehouseID", (object)WarehouseID, true);
            DataTable table = this._database.ExecuteSP_DataTable("Product_GetByWarehouse", true);
            table.TableName = Enums.TableNames.tblProduct.ToString();
            return new DataView(table);
        }

        public DataView SearchByWarehouse(string SearchString, int LocationID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@SearchString", (object)SearchString, true);
            this._database.AddParameter("@LocationID", (object)LocationID, true);
            DataTable table = this._database.ExecuteSP_DataTable("Product_SearchByWarehouse", true);
            table.TableName = Enums.TableNames.tblProduct.ToString();
            return new DataView(table);
        }

        public void DeleteForOrder(int OrderID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@OrderID", (object)OrderID, true);
            this._database.ExecuteSP_NO_Return("ProductTransactions_DeleteForOrder", true);
        }

        public void Delete(int ProductTransactionID, SqlTransaction trans)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "ProductTransaction_Delete";
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Transaction = trans;
            sqlCommand.Connection = trans.Connection;
            sqlCommand.Parameters.AddWithValue("@ProductTransactionID", (object)ProductTransactionID);
            sqlCommand.ExecuteNonQuery();
        }

        public void Delete(int ProductTransactionID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@ProductTransactionID", (object)ProductTransactionID, true);
            this._database.ExecuteSP_NO_Return("ProductTransaction_Delete", true);
        }

        public ProductTransaction ProductTransaction_Get(int ProductTransactionID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@ProductTransactionID", (object)ProductTransactionID, false);
            DataTable dataTable = this._database.ExecuteSP_DataTable(nameof(ProductTransaction_Get), true);
            if (dataTable == null || dataTable.Rows.Count <= 0)
                return (ProductTransaction)null;
            ProductTransaction productTransaction1 = new ProductTransaction();
            ProductTransaction productTransaction2 = productTransaction1;
            productTransaction2.IgnoreExceptionsOnSetMethods = true;
            productTransaction2.SetProductTransactionID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0][nameof(ProductTransactionID)]);
            productTransaction2.SetProductID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ProductID"]);
            productTransaction2.SetAmount = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Amount"]);
            productTransaction2.TransactionDate = Conversions.ToDate(dataTable.Rows[0]["TransactionDate"]);
            productTransaction2.SetUserID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["UserID"]);
            productTransaction2.SetTransactionTypeID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["TransactionTypeID"]);
            productTransaction2.SetLocationID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["LocationID"]);
            productTransaction2.SetOrderProductID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["OrderProductID"]);
            productTransaction2.SetOrderLocationProductID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["OrderLocationProductID"]);
            productTransaction2.SetDeleted = Conversions.ToBoolean(dataTable.Rows[0]["Deleted"]);
            productTransaction1.Exists = true;
            return productTransaction1;
        }

        public DataView ProductTransaction_GetAll()
        {
            this._database.ClearParameter();
            DataTable table = this._database.ExecuteSP_DataTable(nameof(ProductTransaction_GetAll), true);
            table.TableName = Enums.TableNames.tblProductTransaction.ToString();
            return new DataView(table);
        }

        public ProductTransaction Insert(
          ProductTransaction oProductTransaction,
          SqlTransaction trans)
        {
            oProductTransaction.SetProductTransactionID = RuntimeHelpers.GetObjectValue(new SqlCommand()
            {
                CommandText = "ProductTransaction_Insert",
                CommandType = CommandType.StoredProcedure,
                Transaction = trans,
                Connection = trans.Connection,
                Parameters = {
          new SqlParameter("@ProductID", (object) oProductTransaction.ProductID),
          new SqlParameter("@Amount", (object) oProductTransaction.Amount),
          new SqlParameter("@UserID", (object) App.loggedInUser.UserID),
          new SqlParameter("@TransactionTypeID", (object) oProductTransaction.TransactionTypeID),
          new SqlParameter("@LocationID", (object) oProductTransaction.LocationID),
          new SqlParameter("@OrderProductID", (object) oProductTransaction.OrderProductID),
          new SqlParameter("@OrderLocationProductID", (object) oProductTransaction.OrderLocationProductID)
        }
            }.ExecuteScalar());
            oProductTransaction.Exists = true;
            return oProductTransaction;
        }

        public ProductTransaction Insert(ProductTransaction oProductTransaction)
        {
            this._database.ClearParameter();
            this.AddProductTransactionParametersToCommand(oProductTransaction);
            oProductTransaction.SetProductTransactionID = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("ProductTransaction_Insert", true)));
            oProductTransaction.Exists = true;
            return oProductTransaction;
        }

        public void Update(ProductTransaction oProductTransaction)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@ProductTransactionID", (object)oProductTransaction.ProductTransactionID, true);
            this.AddProductTransactionParametersToCommand(oProductTransaction);
            this._database.ExecuteSP_NO_Return("ProductTransaction_Update", true);
        }

        private void AddProductTransactionParametersToCommand(ProductTransaction oProductTransaction)
        {
            this._database.AddParameter("@ProductID", (object)oProductTransaction.ProductID, true);
            this._database.AddParameter("@Amount", (object)oProductTransaction.Amount, true);
            this._database.AddParameter("@UserID", (object)App.loggedInUser.UserID, true);
            this._database.AddParameter("@TransactionTypeID", (object)oProductTransaction.TransactionTypeID, true);
            this._database.AddParameter("@LocationID", (object)oProductTransaction.LocationID, true);
            this._database.AddParameter("@OrderProductID", (object)oProductTransaction.OrderProductID, true);
            this._database.AddParameter("@OrderLocationProductID", (object)oProductTransaction.OrderLocationProductID, true);
        }
    }
}