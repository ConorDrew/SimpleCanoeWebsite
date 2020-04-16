// Decompiled with JetBrains decompiler
// Type: FSM.Entity.OrderLocations.OrderLocationSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace FSM.Entity.OrderLocations
{
    public class OrderLocationSQL
    {
        private Database _database;

        public OrderLocationSQL(Database database)
        {
            this._database = database;
        }

        public void Delete(int OrderLocationID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@OrderLocationID", (object)OrderLocationID, true);
            this._database.ExecuteSP_NO_Return("OrderLocation_Delete", true);
        }

        public void DeleteForOrder(int OrderID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@OrderID", (object)OrderID, true);
            this._database.ExecuteSP_NO_Return("OrderLocation_DeleteForOrder", true);
        }

        public OrderLocation OrderLocation_GetForOrder(int OrderID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@OrderID", (object)OrderID, false);
            DataTable dataTable = this._database.ExecuteSP_DataTable(nameof(OrderLocation_GetForOrder), true);
            if (dataTable == null || dataTable.Rows.Count <= 0)
                return (OrderLocation)null;
            OrderLocation orderLocation1 = new OrderLocation();
            OrderLocation orderLocation2 = orderLocation1;
            orderLocation2.IgnoreExceptionsOnSetMethods = true;
            orderLocation2.SetOrderLocationID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["OrderLocationID"]);
            orderLocation2.SetOrderID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0][nameof(OrderID)]);
            orderLocation2.SetLocationID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["LocationID"]);
            orderLocation2.SetDeliveryAddressID = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["DeliveryAddressID"]));
            orderLocation2.SetDeleted = Conversions.ToBoolean(dataTable.Rows[0]["Deleted"]);
            orderLocation1.Exists = true;
            return orderLocation1;
        }

        public OrderLocation OrderLocation_Get(int OrderLocationID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@OrderLocationID", (object)OrderLocationID, false);
            DataTable dataTable = this._database.ExecuteSP_DataTable(nameof(OrderLocation_Get), true);
            if (dataTable == null || dataTable.Rows.Count <= 0)
                return (OrderLocation)null;
            OrderLocation orderLocation1 = new OrderLocation();
            OrderLocation orderLocation2 = orderLocation1;
            orderLocation2.IgnoreExceptionsOnSetMethods = true;
            orderLocation2.SetOrderLocationID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0][nameof(OrderLocationID)]);
            orderLocation2.SetOrderID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["OrderID"]);
            orderLocation2.SetLocationID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["LocationID"]);
            orderLocation2.SetDeliveryAddressID = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["DeliveryAddressID"]));
            orderLocation2.SetDeleted = Conversions.ToBoolean(dataTable.Rows[0]["Deleted"]);
            orderLocation1.Exists = true;
            return orderLocation1;
        }

        public DataView OrderLocation_GetAll()
        {
            this._database.ClearParameter();
            DataTable table = this._database.ExecuteSP_DataTable(nameof(OrderLocation_GetAll), true);
            table.TableName = Enums.TableNames.tblOrderLocation.ToString();
            return new DataView(table);
        }

        public OrderLocation Insert(OrderLocation oOrderLocation, SqlTransaction trans)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "OrderLocation_Insert";
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Transaction = trans;
            sqlCommand.Connection = trans.Connection;
            sqlCommand.Parameters.AddWithValue("@OrderID", (object)oOrderLocation.OrderID);
            sqlCommand.Parameters.AddWithValue("@LocationID", (object)oOrderLocation.LocationID);
            sqlCommand.Parameters.AddWithValue("@DeliveryAddressID", (object)oOrderLocation.DeliveryAddressID);
            oOrderLocation.SetOrderLocationID = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(sqlCommand.ExecuteScalar()));
            oOrderLocation.Exists = true;
            return oOrderLocation;
        }

        public OrderLocation Insert(OrderLocation oOrderLocation)
        {
            this._database.ClearParameter();
            this.AddOrderLocationParametersToCommand(ref oOrderLocation);
            oOrderLocation.SetOrderLocationID = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("OrderLocation_Insert", true)));
            oOrderLocation.Exists = true;
            return oOrderLocation;
        }

        public void Update(OrderLocation oOrderLocation)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@OrderLocationID", (object)oOrderLocation.OrderLocationID, true);
            this.AddOrderLocationParametersToCommand(ref oOrderLocation);
            this._database.ExecuteSP_NO_Return("OrderLocation_Update", true);
        }

        private void AddOrderLocationParametersToCommand(ref OrderLocation oOrderLocation)
        {
            Database database = this._database;
            database.AddParameter("@OrderID", (object)oOrderLocation.OrderID, true);
            database.AddParameter("@LocationID", (object)oOrderLocation.LocationID, true);
            database.AddParameter("@DeliveryAddressID", (object)oOrderLocation.DeliveryAddressID, true);
        }
    }
}