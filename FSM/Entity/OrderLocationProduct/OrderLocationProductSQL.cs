// Decompiled with JetBrains decompiler
// Type: FSM.Entity.OrderLocationProduct.OrderLocationProductSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace FSM.Entity.OrderLocationProduct
{
    public class OrderLocationProductSQL
    {
        private Database _database;

        public OrderLocationProductSQL(Database database)
        {
            this._database = database;
        }

        public void Delete(int OrderLocationProductID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@OrderLocationProductID", (object)OrderLocationProductID, true);
            this._database.ExecuteSP_NO_Return("OrderLocationProduct_Delete", true);
        }

        public void Delete(int OrderLocationProductID, SqlTransaction trans)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "OrderLocationProduct_Delete";
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Transaction = trans;
            sqlCommand.Connection = trans.Connection;
            sqlCommand.Parameters.AddWithValue("@OrderLocationProductID", (object)OrderLocationProductID);
            sqlCommand.ExecuteNonQuery();
        }

        public void DeleteForOrder(int OrderID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@OrderID", (object)OrderID, true);
            this._database.ExecuteSP_NO_Return("OrderLocationProduct_DeleteForOrder", true);
        }

        public FSM.Entity.OrderLocationProduct.OrderLocationProduct OrderLocationProduct_Get(
          int OrderLocationProductID,
          SqlTransaction trans)
        {
            SqlCommand selectCommand = new SqlCommand();
            selectCommand.CommandText = nameof(OrderLocationProduct_Get);
            selectCommand.CommandType = CommandType.StoredProcedure;
            selectCommand.Transaction = trans;
            selectCommand.Connection = trans.Connection;
            selectCommand.Parameters.AddWithValue("@OrderLocationProductID", (object)OrderLocationProductID);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            DataTable table = dataSet.Tables[0];
            if (table == null || table.Rows.Count <= 0)
                return (FSM.Entity.OrderLocationProduct.OrderLocationProduct)null;
            FSM.Entity.OrderLocationProduct.OrderLocationProduct orderLocationProduct1 = new FSM.Entity.OrderLocationProduct.OrderLocationProduct();
            FSM.Entity.OrderLocationProduct.OrderLocationProduct orderLocationProduct2 = orderLocationProduct1;
            orderLocationProduct2.IgnoreExceptionsOnSetMethods = true;
            orderLocationProduct2.SetOrderLocationProductID = RuntimeHelpers.GetObjectValue(table.Rows[0][nameof(OrderLocationProductID)]);
            orderLocationProduct2.SetProductID = RuntimeHelpers.GetObjectValue(table.Rows[0]["ProductID"]);
            orderLocationProduct2.SetLocationID = RuntimeHelpers.GetObjectValue(table.Rows[0]["LocationID"]);
            orderLocationProduct2.SetQuantity = RuntimeHelpers.GetObjectValue(table.Rows[0]["Quantity"]);
            orderLocationProduct2.SetQuantityReceived = RuntimeHelpers.GetObjectValue(table.Rows[0]["QuantityReceived"]);
            orderLocationProduct2.SetOrderID = RuntimeHelpers.GetObjectValue(table.Rows[0]["OrderID"]);
            orderLocationProduct2.SetSellPrice = RuntimeHelpers.GetObjectValue(table.Rows[0]["SellPrice"]);
            orderLocationProduct2.SetDeleted = Conversions.ToBoolean(table.Rows[0]["Deleted"]);
            orderLocationProduct1.Exists = true;
            return orderLocationProduct1;
        }

        public FSM.Entity.OrderLocationProduct.OrderLocationProduct OrderLocationProduct_Get(
          int OrderLocationProductID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@OrderLocationProductID", (object)OrderLocationProductID, false);
            DataTable dataTable = this._database.ExecuteSP_DataTable(nameof(OrderLocationProduct_Get), true);
            if (dataTable == null || dataTable.Rows.Count <= 0)
                return (FSM.Entity.OrderLocationProduct.OrderLocationProduct)null;
            FSM.Entity.OrderLocationProduct.OrderLocationProduct orderLocationProduct1 = new FSM.Entity.OrderLocationProduct.OrderLocationProduct();
            FSM.Entity.OrderLocationProduct.OrderLocationProduct orderLocationProduct2 = orderLocationProduct1;
            orderLocationProduct2.IgnoreExceptionsOnSetMethods = true;
            orderLocationProduct2.SetOrderLocationProductID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0][nameof(OrderLocationProductID)]);
            orderLocationProduct2.SetProductID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ProductID"]);
            orderLocationProduct2.SetLocationID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["LocationID"]);
            orderLocationProduct2.SetQuantity = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Quantity"]);
            orderLocationProduct2.SetQuantityReceived = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["QuantityReceived"]);
            orderLocationProduct2.SetOrderID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["OrderID"]);
            orderLocationProduct2.SetSellPrice = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SellPrice"]);
            orderLocationProduct2.SetDeleted = Conversions.ToBoolean(dataTable.Rows[0]["Deleted"]);
            orderLocationProduct1.Exists = true;
            return orderLocationProduct1;
        }

        public DataView OrderLocationProduct_GetAll()
        {
            this._database.ClearParameter();
            DataTable table = this._database.ExecuteSP_DataTable(nameof(OrderLocationProduct_GetAll), true);
            table.TableName = Enums.TableNames.tblOrderLocationProduct.ToString();
            return new DataView(table);
        }

        public FSM.Entity.OrderLocationProduct.OrderLocationProduct Insert(
          FSM.Entity.OrderLocationProduct.OrderLocationProduct oOrderLocationProduct,
          bool DoConsolidation)
        {
            this._database.ClearParameter();
            this.AddOrderLocationProductParametersToCommand(ref oOrderLocationProduct);
            oOrderLocationProduct.SetOrderLocationProductID = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("OrderLocationProduct_Insert", true)));
            oOrderLocationProduct.Exists = true;
            if (DoConsolidation)
                App.DB.OrderConsolidations.Create_And_Insert_Location(oOrderLocationProduct.LocationID, oOrderLocationProduct.OrderID);
            return oOrderLocationProduct;
        }

        public FSM.Entity.OrderLocationProduct.OrderLocationProduct Insert(
          FSM.Entity.OrderLocationProduct.OrderLocationProduct oOrderLocationProduct,
          bool DoConsolidation,
          SqlTransaction trans)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "OrderLocationProduct_Insert";
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Transaction = trans;
            sqlCommand.Connection = trans.Connection;
            sqlCommand.Parameters.AddWithValue("@ProductID", (object)oOrderLocationProduct.ProductID);
            sqlCommand.Parameters.AddWithValue("@LocationID", (object)oOrderLocationProduct.LocationID);
            sqlCommand.Parameters.AddWithValue("@Quantity", (object)oOrderLocationProduct.Quantity);
            sqlCommand.Parameters.AddWithValue("@QuantityReceived", (object)oOrderLocationProduct.QuantityReceived);
            sqlCommand.Parameters.AddWithValue("@OrderID", (object)oOrderLocationProduct.OrderID);
            sqlCommand.Parameters.AddWithValue("@SellPrice", (object)oOrderLocationProduct.SellPrice);
            oOrderLocationProduct.SetOrderLocationProductID = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(sqlCommand.ExecuteScalar()));
            oOrderLocationProduct.Exists = true;
            if (DoConsolidation)
                App.DB.OrderConsolidations.Create_And_Insert_Location(oOrderLocationProduct.LocationID, oOrderLocationProduct.OrderID, trans);
            return oOrderLocationProduct;
        }

        public void Update(FSM.Entity.OrderLocationProduct.OrderLocationProduct oOrderLocationProduct)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@OrderLocationProductID", (object)oOrderLocationProduct.OrderLocationProductID, true);
            this.AddOrderLocationProductParametersToCommand(ref oOrderLocationProduct);
            this._database.ExecuteSP_NO_Return("OrderLocationProduct_Update", true);
        }

        private void AddOrderLocationProductParametersToCommand(
          ref FSM.Entity.OrderLocationProduct.OrderLocationProduct oOrderLocationProduct)
        {
            Database database = this._database;
            database.AddParameter("@ProductID", (object)oOrderLocationProduct.ProductID, true);
            database.AddParameter("@LocationID", (object)oOrderLocationProduct.LocationID, true);
            database.AddParameter("@Quantity", (object)oOrderLocationProduct.Quantity, true);
            database.AddParameter("@QuantityReceived", (object)oOrderLocationProduct.QuantityReceived, true);
            database.AddParameter("@OrderID", (object)oOrderLocationProduct.OrderID, true);
            database.AddParameter("@SellPrice", (object)oOrderLocationProduct.SellPrice, true);
        }

        public void MarkOrderQuantityReceived(int OrderLocationProductID, int QuantityReceived)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@OrderLocationProductID", (object)OrderLocationProductID, true);
            this._database.AddParameter("@QuantityRecieved", (object)QuantityReceived, true);
            this._database.ExecuteSP_NO_Return("OrderLocationProduct_MarkOrderQuantityReceived", true);
        }
    }
}