// Decompiled with JetBrains decompiler
// Type: FSM.Entity.ProductSuppliers.ProductSupplierSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace FSM.Entity.ProductSuppliers
{
    public class ProductSupplierSQL
    {
        private Database _database;

        public ProductSupplierSQL(Database database)
        {
            this._database = database;
        }

        public object ProductSupplier_Search(string SearchString, int SupplierID = 0)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@SearchString", (object)SearchString, true);
            this._database.AddParameter("@SupplierID", (object)SupplierID, true);
            DataTable table = this._database.ExecuteSP_DataTable(nameof(ProductSupplier_Search), true);
            table.TableName = Enums.TableNames.tblProduct.ToString();
            return (object)new DataView(table);
        }

        public ProductSupplier ProductSupplier_Get(
          int ProductSupplierID,
          SqlTransaction trans)
        {
            SqlCommand selectCommand = new SqlCommand();
            selectCommand.CommandText = nameof(ProductSupplier_Get);
            selectCommand.CommandType = CommandType.StoredProcedure;
            selectCommand.Transaction = trans;
            selectCommand.Connection = trans.Connection;
            selectCommand.Parameters.AddWithValue("@ProductSupplierID", (object)ProductSupplierID);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            DataTable table = dataSet.Tables[0];
            if (table == null || table.Rows.Count <= 0)
                return (ProductSupplier)null;
            ProductSupplier productSupplier1 = new ProductSupplier();
            ProductSupplier productSupplier2 = productSupplier1;
            productSupplier2.IgnoreExceptionsOnSetMethods = true;
            productSupplier2.SetProductID = RuntimeHelpers.GetObjectValue(table.Rows[0]["ProductID"]);
            productSupplier2.SetProductSupplierID = RuntimeHelpers.GetObjectValue(table.Rows[0][nameof(ProductSupplierID)]);
            productSupplier2.SetProductCode = RuntimeHelpers.GetObjectValue(table.Rows[0]["ProductCode"]);
            productSupplier2.SetPrice = RuntimeHelpers.GetObjectValue(table.Rows[0]["Price"]);
            productSupplier2.SetSupplierID = RuntimeHelpers.GetObjectValue(table.Rows[0]["SupplierID"]);
            productSupplier2.SetQuantityInPack = RuntimeHelpers.GetObjectValue(table.Rows[0]["QuantityInPack"]);
            productSupplier1.Exists = true;
            return productSupplier1;
        }

        public ProductSupplier ProductSupplier_Get(int ProductSupplierID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@ProductSupplierID", (object)ProductSupplierID, false);
            DataTable dataTable = this._database.ExecuteSP_DataTable(nameof(ProductSupplier_Get), true);
            if (dataTable == null || dataTable.Rows.Count <= 0)
                return (ProductSupplier)null;
            ProductSupplier productSupplier1 = new ProductSupplier();
            ProductSupplier productSupplier2 = productSupplier1;
            productSupplier2.IgnoreExceptionsOnSetMethods = true;
            productSupplier2.SetProductID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ProductID"]);
            productSupplier2.SetProductSupplierID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0][nameof(ProductSupplierID)]);
            productSupplier2.SetProductCode = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ProductCode"]);
            productSupplier2.SetPrice = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Price"]);
            productSupplier2.SetSupplierID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SupplierID"]);
            productSupplier2.SetQuantityInPack = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["QuantityInPack"]);
            productSupplier1.Exists = true;
            return productSupplier1;
        }

        public DataView ProductSupplierPacks_Get(int ProductID, int SupplierID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@ProductID", (object)ProductID, true);
            this._database.AddParameter("@SupplierID", (object)SupplierID, true);
            DataTable table = this._database.ExecuteSP_DataTable(nameof(ProductSupplierPacks_Get), true);
            table.TableName = Enums.TableNames.tblProductSupplier.ToString();
            return new DataView(table);
        }

        public DataView ProductSupplierPacks_Get(
          int ProductID,
          int SupplierID,
          SqlTransaction trans)
        {
            SqlCommand selectCommand = new SqlCommand();
            selectCommand.CommandText = nameof(ProductSupplierPacks_Get);
            selectCommand.CommandType = CommandType.StoredProcedure;
            selectCommand.Transaction = trans;
            selectCommand.Connection = trans.Connection;
            selectCommand.Parameters.AddWithValue("@ProductID", (object)ProductID);
            selectCommand.Parameters.AddWithValue("@SupplierID", (object)SupplierID);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            DataTable table = dataSet.Tables[0];
            table.TableName = Enums.TableNames.tblProductSupplier.ToString();
            return new DataView(table);
        }

        public DataView ProductSupplierGet_All()
        {
            this._database.ClearParameter();
            DataTable table = this._database.ExecuteSP_DataTable("ProductSupplier_GetAll", true);
            table.TableName = Enums.TableNames.tblProductSupplier.ToString();
            return new DataView(table);
        }

        public DataView Get_ByProductID(int ProductID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@ProductID", (object)ProductID, true);
            DataTable table = this._database.ExecuteSP_DataTable("ProductSupplier_GetByProduct", true);
            table.TableName = Enums.TableNames.tblProductSupplier.ToString();
            return new DataView(table);
        }

        public void Delete(int ProductSupplierID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@ProductSupplierID", (object)ProductSupplierID, true);
            this._database.ExecuteSP_NO_Return("ProductSupplier_Delete", true);
        }

        public ProductSupplier Insert(ProductSupplier oProductSupplier)
        {
            this._database.ClearParameter();
            this.AddProductSupplierParametersToCommand(ref oProductSupplier);
            oProductSupplier.SetProductSupplierID = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("ProductSupplier_Insert", true)));
            oProductSupplier.Exists = true;
            return oProductSupplier;
        }

        public void Update(ProductSupplier oProductSupplier)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@ProductSupplierID", (object)oProductSupplier.ProductSupplierID, true);
            this.AddProductSupplierParametersToCommand(ref oProductSupplier);
            this._database.ExecuteSP_NO_Return("ProductSupplier_Update", true);
        }

        private void AddProductSupplierParametersToCommand(ref ProductSupplier oProductSupplier)
        {
            Database database = this._database;
            database.AddParameter("@ProductID", (object)oProductSupplier.ProductID, true);
            database.AddParameter("@SupplierID", (object)oProductSupplier.SupplierID, true);
            database.AddParameter("@ProductCode", (object)oProductSupplier.ProductCode, true);
            database.AddParameter("@Price", (object)oProductSupplier.Price, true);
            database.AddParameter("@QuantityInPack", (object)oProductSupplier.QuantityInPack, true);
        }
    }
}