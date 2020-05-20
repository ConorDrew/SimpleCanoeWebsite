using System.Data;
using System.Data.SqlClient;

namespace FSM.Entity
{
    namespace EngineerVisitOrders
    {
        public class EngineerVisitOrderSQL
        {
            private Sys.Database _database;

            public EngineerVisitOrderSQL(Sys.Database database)
            {
                _database = database;
            }

            public void EngineerVisitOrder_DeleteForOrder(int OrderID)
            {
                _database.ClearParameter();
                _database.AddParameter("@OrderID", OrderID, true);
                _database.ExecuteSP_NO_Return("EngineerVisitOrder_DeleteForOrder");
            }

            public void Delete(int EngineerVisitOrderID)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerVisitOrderID", EngineerVisitOrderID, true);
                _database.ExecuteSP_NO_Return("EngineerVistOrder_Delete");
            }

            public EngineerVisitOrder EngineerVisitOrder_GetForOrder(int OrderID)
            {
                _database.ClearParameter();
                _database.AddParameter("@OrderID", OrderID);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("EngineerVisitOrder_GetForOrder");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oEngineerVisitOrder = new EngineerVisitOrder();
                        oEngineerVisitOrder.IgnoreExceptionsOnSetMethods = true;
                        oEngineerVisitOrder.SetEngineerVisitOrderID = dt.Rows[0]["EngineerVisitOrderID"];
                        oEngineerVisitOrder.SetOrderID = dt.Rows[0]["OrderID"];
                        oEngineerVisitOrder.SetEngineerVisitID = dt.Rows[0]["EngineerVisitID"];
                        oEngineerVisitOrder.SetWarehouseID = dt.Rows[0]["WarehouseID"];
                        oEngineerVisitOrder.Exists = true;
                        return oEngineerVisitOrder;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }

            public EngineerVisitOrder Insert(EngineerVisitOrder oEngineerVisitOrder)
            {
                _database.ClearParameter();
                AddEngineerVisitOrderParametersToCommand(ref oEngineerVisitOrder);
                oEngineerVisitOrder.SetEngineerVisitOrderID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("EngineerVisitOrder_Insert"));
                oEngineerVisitOrder.Exists = true;
                return oEngineerVisitOrder;
            }

            public EngineerVisitOrder Insert(EngineerVisitOrder oEngineerVisitOrder, SqlTransaction trans)
            {
                var Command = new SqlCommand();
                Command.CommandText = "EngineerVisitOrder_Insert";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Transaction = trans;
                Command.Connection = trans.Connection;
                Command.Parameters.AddWithValue("@OrderID", oEngineerVisitOrder.OrderID);
                Command.Parameters.AddWithValue("@EngineerVisitID", oEngineerVisitOrder.EngineerVisitID);
                Command.Parameters.AddWithValue("@WarehouseID", oEngineerVisitOrder.WarehouseID);
                oEngineerVisitOrder.SetEngineerVisitOrderID = Sys.Helper.MakeIntegerValid(Command.ExecuteScalar());
                oEngineerVisitOrder.Exists = true;
                return oEngineerVisitOrder;
            }

            public void Update(EngineerVisitOrder oEngineerVisitOrder)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerVisitOrderID", oEngineerVisitOrder.EngineerVisitOrderID, true);
                AddEngineerVisitOrderParametersToCommand(ref oEngineerVisitOrder);
                _database.ExecuteSP_NO_Return("EngineerVisitOrder_Update");
            }

            private void AddEngineerVisitOrderParametersToCommand(ref EngineerVisitOrder oEngineerVisitOrder)
            {
                {
                    var withBlock = _database;
                    withBlock.AddParameter("@OrderID", oEngineerVisitOrder.OrderID, true);
                    withBlock.AddParameter("@EngineerVisitID", oEngineerVisitOrder.EngineerVisitID, true);
                    withBlock.AddParameter("@WarehouseID", oEngineerVisitOrder.WarehouseID, true);
                }
            }
        }
    }
}