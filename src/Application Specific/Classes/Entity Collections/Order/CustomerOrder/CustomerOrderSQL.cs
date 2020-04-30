using System.Data;
using System.Data.SqlClient;

namespace FSM.Entity
{
    namespace CustomerOrders
    {
        public class CustomerOrderSQL
        {
            private Sys.Database _database;

            public CustomerOrderSQL(Sys.Database database)
            {
                _database = database;
            }

            
            public void Delete(int CustomerOrderID)
            {
                _database.ClearParameter();
                _database.AddParameter("@CustomerOrderID", CustomerOrderID, true);
                _database.ExecuteSP_NO_Return("CustomerOrder_Delete");
            }

            public void DeleteForOrder(int OrderID)
            {
                _database.ClearParameter();
                _database.AddParameter("@OrderID", OrderID, true);
                _database.ExecuteSP_NO_Return("CustomerOrder_DeleteForOrder");
            }

            public DataView CustomerOrder_GetForOrder(int OrderID)
            {
                _database.ClearParameter();
                _database.AddParameter("@OrderID", OrderID, true);
                var dt = _database.ExecuteSP_DataTable("CustomerOrder_GetForOrder");
                dt.TableName = Sys.Enums.TableNames.tblCustomer.ToString();
                return new DataView(dt);
            }

            public CustomerOrder Insert(CustomerOrder oCustomerOrder)
            {
                _database.ClearParameter();
                AddCustomerOrderParametersToCommand(ref oCustomerOrder);
                oCustomerOrder.SetCustomerOrderID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("CustomerOrder_Insert"));
                oCustomerOrder.Exists = true;
                return oCustomerOrder;
            }

            public CustomerOrder Insert(CustomerOrder oCustomerOrder, SqlTransaction trans)
            {
                var Command = new SqlCommand();
                Command.CommandText = "CustomerOrder_Insert";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Transaction = trans;
                Command.Connection = trans.Connection;
                Command.Parameters.AddWithValue("@OrderID", oCustomerOrder.OrderID);
                Command.Parameters.AddWithValue("@CustomerID", oCustomerOrder.CustomerID);
                oCustomerOrder.SetCustomerOrderID = Sys.Helper.MakeIntegerValid(Command.ExecuteScalar());
                oCustomerOrder.Exists = true;
                return oCustomerOrder;
            }

            public void Update(CustomerOrder oCustomerOrder)
            {
                _database.ClearParameter();
                _database.AddParameter("@CustomerOrderID", oCustomerOrder.CustomerOrderID, true);
                AddCustomerOrderParametersToCommand(ref oCustomerOrder);
                _database.ExecuteSP_NO_Return("CustomerOrder_Update");
            }

            private void AddCustomerOrderParametersToCommand(ref CustomerOrder oCustomerOrder)
            {
                {
                    var withBlock = _database;
                    withBlock.AddParameter("@OrderID", oCustomerOrder.OrderID, true);
                    withBlock.AddParameter("@CustomerID", oCustomerOrder.CustomerID, true);
                }
            }

            
        }
    }
}