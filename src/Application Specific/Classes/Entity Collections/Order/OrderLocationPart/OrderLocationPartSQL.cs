using System.Data;
using System.Data.SqlClient;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace OrderLocationPart
    {
        public class OrderLocationPartSQL
        {
            private Sys.Database _database;

            public OrderLocationPartSQL(Sys.Database database)
            {
                _database = database;
            }

            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            public void Delete(int OrderLocationPartID, SqlTransaction trans)
            {
                var Command = new SqlCommand();
                Command.CommandText = "OrderLocationPart_Delete";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Transaction = trans;
                Command.Connection = trans.Connection;
                Command.Parameters.AddWithValue("@OrderLocationPartID", OrderLocationPartID);
                Command.ExecuteNonQuery();
            }

            public void Delete(int OrderLocationPartID)
            {
                _database.ClearParameter();
                _database.AddParameter("@OrderLocationPartID", OrderLocationPartID, true);
                _database.ExecuteSP_NO_Return("OrderLocationPart_Delete");
            }

            public void DeleteForOrder(int OrderID)
            {
                _database.ClearParameter();
                _database.AddParameter("@OrderID", OrderID, true);
                _database.ExecuteSP_NO_Return("OrderLocationPart_DeleteForOrder");
            }

            public OrderLocationPart OrderLocationPart_Get(int OrderLocationPartID, SqlTransaction trans)
            {
                var Command = new SqlCommand();
                Command.CommandText = "OrderLocationPart_Get";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Transaction = trans;
                Command.Connection = trans.Connection;
                Command.Parameters.AddWithValue("@OrderLocationPartID", OrderLocationPartID);
                var Adapter = new SqlDataAdapter(Command);
                var returnDS = new DataSet();
                Adapter.Fill(returnDS);
                var dt = returnDS.Tables[0];
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oOrderLocationPart = new OrderLocationPart();
                        oOrderLocationPart.IgnoreExceptionsOnSetMethods = true;
                        oOrderLocationPart.SetOrderLocationPartID = dt.Rows[0]["OrderLocationPartID"];
                        oOrderLocationPart.SetPartID = dt.Rows[0]["PartID"];
                        oOrderLocationPart.SetLocationID = dt.Rows[0]["LocationID"];
                        oOrderLocationPart.SetQuantity = dt.Rows[0]["Quantity"];
                        oOrderLocationPart.SetQuantityReceived = dt.Rows[0]["QuantityReceived"];
                        oOrderLocationPart.SetOrderID = dt.Rows[0]["OrderID"];
                        oOrderLocationPart.SetSellPrice = dt.Rows[0]["SellPrice"];
                        oOrderLocationPart.SetDeleted = Conversions.ToBoolean(dt.Rows[0]["Deleted"]);
                        oOrderLocationPart.Exists = true;
                        return oOrderLocationPart;
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

            public OrderLocationPart OrderLocationPart_Get(int OrderLocationPartID)
            {
                _database.ClearParameter();
                _database.AddParameter("@OrderLocationPartID", OrderLocationPartID);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("OrderLocationPart_Get");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oOrderLocationPart = new OrderLocationPart();
                        oOrderLocationPart.IgnoreExceptionsOnSetMethods = true;
                        oOrderLocationPart.SetOrderLocationPartID = dt.Rows[0]["OrderLocationPartID"];
                        oOrderLocationPart.SetPartID = dt.Rows[0]["PartID"];
                        oOrderLocationPart.SetLocationID = dt.Rows[0]["LocationID"];
                        oOrderLocationPart.SetQuantity = dt.Rows[0]["Quantity"];
                        oOrderLocationPart.SetQuantityReceived = dt.Rows[0]["QuantityReceived"];
                        oOrderLocationPart.SetOrderID = dt.Rows[0]["OrderID"];
                        oOrderLocationPart.SetSellPrice = dt.Rows[0]["SellPrice"];
                        oOrderLocationPart.SetDeleted = Conversions.ToBoolean(dt.Rows[0]["Deleted"]);
                        oOrderLocationPart.Exists = true;
                        return oOrderLocationPart;
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

            public DataView OrderLocationPart_GetAll()
            {
                _database.ClearParameter();
                var dt = _database.ExecuteSP_DataTable("OrderLocationPart_GetAll");
                dt.TableName = Sys.Enums.TableNames.tblOrderLocationPart.ToString();
                return new DataView(dt);
            }

            public OrderLocationPart Insert(OrderLocationPart oOrderLocationPart, bool DoConsolidation)
            {
                _database.ClearParameter();
                AddOrderLocationPartParametersToCommand(ref oOrderLocationPart);
                oOrderLocationPart.SetOrderLocationPartID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("OrderLocationPart_Insert"));
                oOrderLocationPart.Exists = true;
                if (DoConsolidation)
                {
                    App.DB.OrderConsolidations.Create_And_Insert_Location(oOrderLocationPart.LocationID, oOrderLocationPart.OrderID);
                }

                return oOrderLocationPart;
            }

            public OrderLocationPart Insert(OrderLocationPart oOrderLocationPart, bool DoConsolidation, SqlTransaction trans)
            {
                var Command = new SqlCommand();
                Command.CommandText = "OrderLocationPart_Insert";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Transaction = trans;
                Command.Connection = trans.Connection;
                Command.Parameters.AddWithValue("@PartID", oOrderLocationPart.PartID);
                Command.Parameters.AddWithValue("@LocationID", oOrderLocationPart.LocationID);
                Command.Parameters.AddWithValue("@Quantity", oOrderLocationPart.Quantity);
                Command.Parameters.AddWithValue("@QuantityReceived", oOrderLocationPart.QuantityReceived);
                Command.Parameters.AddWithValue("@OrderID", oOrderLocationPart.OrderID);
                Command.Parameters.AddWithValue("@SellPrice", oOrderLocationPart.SellPrice);
                oOrderLocationPart.SetOrderLocationPartID = Sys.Helper.MakeIntegerValid(Command.ExecuteScalar());
                oOrderLocationPart.Exists = true;
                if (DoConsolidation)
                {
                    App.DB.OrderConsolidations.Create_And_Insert_Location(oOrderLocationPart.LocationID, oOrderLocationPart.OrderID, trans);
                }

                return oOrderLocationPart;
            }

            public void Update(OrderLocationPart oOrderLocationPart)
            {
                _database.ClearParameter();
                _database.AddParameter("@OrderLocationPartID", oOrderLocationPart.OrderLocationPartID, true);
                AddOrderLocationPartParametersToCommand(ref oOrderLocationPart);
                _database.ExecuteSP_NO_Return("OrderLocationPart_Update");
            }

            private void AddOrderLocationPartParametersToCommand(ref OrderLocationPart oOrderLocationPart)
            {
                {
                    var withBlock = _database;
                    withBlock.AddParameter("@PartID", oOrderLocationPart.PartID, true);
                    withBlock.AddParameter("@LocationID", oOrderLocationPart.LocationID, true);
                    withBlock.AddParameter("@Quantity", oOrderLocationPart.Quantity, true);
                    withBlock.AddParameter("@QuantityReceived", oOrderLocationPart.QuantityReceived, true);
                    withBlock.AddParameter("@OrderID", oOrderLocationPart.OrderID, true);
                    withBlock.AddParameter("@SellPrice", oOrderLocationPart.SellPrice, true);
                }
            }

            public void EngineerReceived(int OrderLocationPartID)
            {
                _database.ClearParameter();
                _database.AddParameter("@OrderLocationPartID", OrderLocationPartID, true);
                _database.ExecuteSP_NO_Return("OrderLocationPart_EngineerReceived");
            }

            public void MarkOrderQuantityReceived(int OrderLocationPartID, int OrderLocationQuantityOrdered)
            {
                _database.ClearParameter();
                _database.AddParameter("@OrderLocationPartID", OrderLocationPartID, true);
                _database.AddParameter("@QuantityReceived", OrderLocationQuantityOrdered, true);
                _database.ExecuteSP_NO_Return("OrderLocationPart_MarkOrderQuantityReceived");
            }

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}