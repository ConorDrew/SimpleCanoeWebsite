// Decompiled with JetBrains decompiler
// Type: FSM.Entity.OrderCharges.OrderChargeSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM.Entity.OrderCharges
{
    public class OrderChargeSQL
    {
        private Database _database;

        public OrderChargeSQL(Database database)
        {
            this._database = database;
        }

        public void Delete(int OrderChargeID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@OrderChargeID", (object)OrderChargeID, true);
            this._database.ExecuteSP_NO_Return("OrderCharge_Delete", true);
        }

        public DataView OrderCharge_GetForOrder(int OrderID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@OrderID", (object)OrderID, true);
            DataTable table = this._database.ExecuteSP_DataTable(nameof(OrderCharge_GetForOrder), true);
            table.TableName = Enums.TableNames.tblOrderCharge.ToString();
            return new DataView(table);
        }

        public OrderCharge OrderCharge_Get(int OrderChargeID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@OrderChargeID", (object)OrderChargeID, false);
            DataTable dataTable = this._database.ExecuteSP_DataTable(nameof(OrderCharge_Get), true);
            if (dataTable == null || dataTable.Rows.Count <= 0)
                return (OrderCharge)null;
            OrderCharge orderCharge1 = new OrderCharge();
            OrderCharge orderCharge2 = orderCharge1;
            orderCharge2.IgnoreExceptionsOnSetMethods = true;
            orderCharge2.SetOrderChargeID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0][nameof(OrderChargeID)]);
            orderCharge2.SetOrderID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["OrderID"]);
            orderCharge2.SetOrderChargeTypeID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["OrderChargeTypeID"]);
            orderCharge2.SetAmount = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Amount"]);
            orderCharge2.SetReference = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Reference"]);
            orderCharge2.SetDeleted = Conversions.ToBoolean(dataTable.Rows[0]["Deleted"]);
            orderCharge1.Exists = true;
            return orderCharge1;
        }

        public DataView OrderCharge_GetForConsolidatedOrder(int OrderConsolidationID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@OrderConsolidationID", (object)OrderConsolidationID, true);
            DataTable table = this._database.ExecuteSP_DataTable(nameof(OrderCharge_GetForConsolidatedOrder), true);
            table.TableName = Enums.TableNames.tblOrderCharge.ToString();
            return new DataView(table);
        }

        public DataView OrderCharge_GetAll()
        {
            this._database.ClearParameter();
            DataTable table = this._database.ExecuteSP_DataTable(nameof(OrderCharge_GetAll), true);
            table.TableName = Enums.TableNames.tblOrderCharge.ToString();
            return new DataView(table);
        }

        public OrderCharge Insert(OrderCharge oOrderCharge)
        {
            this._database.ClearParameter();
            this.AddOrderChargeParametersToCommand(ref oOrderCharge);
            oOrderCharge.SetOrderChargeID = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("OrderCharge_Insert", true)));
            oOrderCharge.Exists = true;
            return oOrderCharge;
        }

        public void Update(OrderCharge oOrderCharge)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@OrderChargeID", (object)oOrderCharge.OrderChargeID, true);
            this.AddOrderChargeParametersToCommand(ref oOrderCharge);
            this._database.ExecuteSP_NO_Return("OrderCharge_Update", true);
        }

        private void AddOrderChargeParametersToCommand(ref OrderCharge oOrderCharge)
        {
            Database database = this._database;
            database.AddParameter("@OrderID", (object)oOrderCharge.OrderID, true);
            database.AddParameter("@OrderChargeTypeID", (object)oOrderCharge.OrderChargeTypeID, true);
            database.AddParameter("@Amount", (object)oOrderCharge.Amount, true);
            database.AddParameter("@Reference", (object)oOrderCharge.Reference, true);
        }
    }
}