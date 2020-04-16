// Decompiled with JetBrains decompiler
// Type: FSM.Entity.EngineerVisitOrders.EngineerVisitOrderSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace FSM.Entity.EngineerVisitOrders
{
    public class EngineerVisitOrderSQL
    {
        private Database _database;

        public EngineerVisitOrderSQL(Database database)
        {
            this._database = database;
        }

        public void EngineerVisitOrder_DeleteForOrder(int OrderID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@OrderID", (object)OrderID, true);
            this._database.ExecuteSP_NO_Return(nameof(EngineerVisitOrder_DeleteForOrder), true);
        }

        public void Delete(int EngineerVisitOrderID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@EngineerVisitOrderID", (object)EngineerVisitOrderID, true);
            this._database.ExecuteSP_NO_Return("EngineerVistOrder_Delete", true);
        }

        public DataView EngineerVisitOrder_Get(int EngineerVisitID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@EngineerVisitID", (object)EngineerVisitID, false);
            return new DataView(this._database.ExecuteSP_DataTable(nameof(EngineerVisitOrder_Get), true));
        }

        public EngineerVisitOrder EngineerVisitOrder_GetForOrder(int OrderID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@OrderID", (object)OrderID, false);
            DataTable dataTable = this._database.ExecuteSP_DataTable(nameof(EngineerVisitOrder_GetForOrder), true);
            if (dataTable == null || dataTable.Rows.Count <= 0)
                return (EngineerVisitOrder)null;
            EngineerVisitOrder engineerVisitOrder1 = new EngineerVisitOrder();
            EngineerVisitOrder engineerVisitOrder2 = engineerVisitOrder1;
            engineerVisitOrder2.IgnoreExceptionsOnSetMethods = true;
            engineerVisitOrder2.SetEngineerVisitOrderID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["EngineerVisitOrderID"]);
            engineerVisitOrder2.SetOrderID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0][nameof(OrderID)]);
            engineerVisitOrder2.SetEngineerVisitID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["EngineerVisitID"]);
            engineerVisitOrder2.SetWarehouseID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["WarehouseID"]);
            engineerVisitOrder2.Exists = true;
            return engineerVisitOrder1;
        }

        public EngineerVisitOrder Insert(EngineerVisitOrder oEngineerVisitOrder)
        {
            this._database.ClearParameter();
            this.AddEngineerVisitOrderParametersToCommand(ref oEngineerVisitOrder);
            oEngineerVisitOrder.SetEngineerVisitOrderID = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("EngineerVisitOrder_Insert", true)));
            oEngineerVisitOrder.Exists = true;
            return oEngineerVisitOrder;
        }

        public EngineerVisitOrder Insert(
          EngineerVisitOrder oEngineerVisitOrder,
          SqlTransaction trans)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "EngineerVisitOrder_Insert";
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Transaction = trans;
            sqlCommand.Connection = trans.Connection;
            sqlCommand.Parameters.AddWithValue("@OrderID", (object)oEngineerVisitOrder.OrderID);
            sqlCommand.Parameters.AddWithValue("@EngineerVisitID", (object)oEngineerVisitOrder.EngineerVisitID);
            sqlCommand.Parameters.AddWithValue("@WarehouseID", (object)oEngineerVisitOrder.WarehouseID);
            oEngineerVisitOrder.SetEngineerVisitOrderID = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(sqlCommand.ExecuteScalar()));
            oEngineerVisitOrder.Exists = true;
            return oEngineerVisitOrder;
        }

        public void Update(EngineerVisitOrder oEngineerVisitOrder)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@EngineerVisitOrderID", (object)oEngineerVisitOrder.EngineerVisitOrderID, true);
            this.AddEngineerVisitOrderParametersToCommand(ref oEngineerVisitOrder);
            this._database.ExecuteSP_NO_Return("EngineerVisitOrder_Update", true);
        }

        private void AddEngineerVisitOrderParametersToCommand(ref EngineerVisitOrder oEngineerVisitOrder)
        {
            Database database = this._database;
            database.AddParameter("@OrderID", (object)oEngineerVisitOrder.OrderID, true);
            database.AddParameter("@EngineerVisitID", (object)oEngineerVisitOrder.EngineerVisitID, true);
            database.AddParameter("@WarehouseID", (object)oEngineerVisitOrder.WarehouseID, true);
        }
    }
}