using System.Data;
using System.Data.SqlClient;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace OrderLocations
    {
        public class OrderLocationSQL
        {
            private Sys.Database _database;

            public OrderLocationSQL(Sys.Database database)
            {
                _database = database;
            }

            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            public void Delete(int OrderLocationID)
            {
                _database.ClearParameter();
                _database.AddParameter("@OrderLocationID", OrderLocationID, true);
                _database.ExecuteSP_NO_Return("OrderLocation_Delete");
            }

            public void DeleteForOrder(int OrderID)
            {
                _database.ClearParameter();
                _database.AddParameter("@OrderID", OrderID, true);
                _database.ExecuteSP_NO_Return("OrderLocation_DeleteForOrder");
            }

            public OrderLocation OrderLocation_GetForOrder(int OrderID)
            {
                _database.ClearParameter();
                _database.AddParameter("@OrderID", OrderID);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("OrderLocation_GetForOrder");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oOrderLocation = new OrderLocation();
                        oOrderLocation.IgnoreExceptionsOnSetMethods = true;
                        oOrderLocation.SetOrderLocationID = dt.Rows[0]["OrderLocationID"];
                        oOrderLocation.SetOrderID = dt.Rows[0]["OrderID"];
                        oOrderLocation.SetLocationID = dt.Rows[0]["LocationID"];
                        oOrderLocation.SetDeliveryAddressID = Sys.Helper.MakeIntegerValid(dt.Rows[0]["DeliveryAddressID"]);
                        oOrderLocation.SetDeleted = Conversions.ToBoolean(dt.Rows[0]["Deleted"]);
                        oOrderLocation.Exists = true;
                        return oOrderLocation;
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

            public OrderLocation OrderLocation_Get(int OrderLocationID)
            {
                _database.ClearParameter();
                _database.AddParameter("@OrderLocationID", OrderLocationID);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("OrderLocation_Get");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oOrderLocation = new OrderLocation();
                        oOrderLocation.IgnoreExceptionsOnSetMethods = true;
                        oOrderLocation.SetOrderLocationID = dt.Rows[0]["OrderLocationID"];
                        oOrderLocation.SetOrderID = dt.Rows[0]["OrderID"];
                        oOrderLocation.SetLocationID = dt.Rows[0]["LocationID"];
                        oOrderLocation.SetDeliveryAddressID = Sys.Helper.MakeIntegerValid(dt.Rows[0]["DeliveryAddressID"]);
                        oOrderLocation.SetDeleted = Conversions.ToBoolean(dt.Rows[0]["Deleted"]);
                        oOrderLocation.Exists = true;
                        return oOrderLocation;
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

            public DataView OrderLocation_GetAll()
            {
                _database.ClearParameter();
                var dt = _database.ExecuteSP_DataTable("OrderLocation_GetAll");
                dt.TableName = Sys.Enums.TableNames.tblOrderLocation.ToString();
                return new DataView(dt);
            }

            public OrderLocation Insert(OrderLocation oOrderLocation, SqlTransaction trans)
            {
                var Command = new SqlCommand();
                Command.CommandText = "OrderLocation_Insert";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Transaction = trans;
                Command.Connection = trans.Connection;
                Command.Parameters.AddWithValue("@OrderID", oOrderLocation.OrderID);
                Command.Parameters.AddWithValue("@LocationID", oOrderLocation.LocationID);
                Command.Parameters.AddWithValue("@DeliveryAddressID", oOrderLocation.DeliveryAddressID);
                oOrderLocation.SetOrderLocationID = Sys.Helper.MakeIntegerValid(Command.ExecuteScalar());
                oOrderLocation.Exists = true;
                return oOrderLocation;
            }

            public OrderLocation Insert(OrderLocation oOrderLocation)
            {
                _database.ClearParameter();
                AddOrderLocationParametersToCommand(ref oOrderLocation);
                oOrderLocation.SetOrderLocationID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("OrderLocation_Insert"));
                oOrderLocation.Exists = true;
                return oOrderLocation;
            }

            public void Update(OrderLocation oOrderLocation)
            {
                _database.ClearParameter();
                _database.AddParameter("@OrderLocationID", oOrderLocation.OrderLocationID, true);
                AddOrderLocationParametersToCommand(ref oOrderLocation);
                _database.ExecuteSP_NO_Return("OrderLocation_Update");
            }

            private void AddOrderLocationParametersToCommand(ref OrderLocation oOrderLocation)
            {
                {
                    var withBlock = _database;
                    withBlock.AddParameter("@OrderID", oOrderLocation.OrderID, true);
                    withBlock.AddParameter("@LocationID", oOrderLocation.LocationID, true);
                    withBlock.AddParameter("@DeliveryAddressID", oOrderLocation.DeliveryAddressID, true);
                }
            }

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}