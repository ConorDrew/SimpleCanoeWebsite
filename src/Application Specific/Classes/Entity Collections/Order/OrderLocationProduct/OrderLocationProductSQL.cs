using System.Data;
using System.Data.SqlClient;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace OrderLocationProduct
    {
        public class OrderLocationProductSQL
        {
            private Sys.Database _database;

            public OrderLocationProductSQL(Sys.Database database)
            {
                _database = database;
            }

            

            public void Delete(int OrderLocationProductID)
            {
                _database.ClearParameter();
                _database.AddParameter("@OrderLocationProductID", OrderLocationProductID, true);
                _database.ExecuteSP_NO_Return("OrderLocationProduct_Delete");
            }

            public void Delete(int OrderLocationProductID, SqlTransaction trans)
            {
                var Command = new SqlCommand();
                Command.CommandText = "OrderLocationProduct_Delete";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Transaction = trans;
                Command.Connection = trans.Connection;
                Command.Parameters.AddWithValue("@OrderLocationProductID", OrderLocationProductID);
                Command.ExecuteNonQuery();
            }

            public void DeleteForOrder(int OrderID)
            {
                _database.ClearParameter();
                _database.AddParameter("@OrderID", OrderID, true);
                _database.ExecuteSP_NO_Return("OrderLocationProduct_DeleteForOrder");
            }

            public OrderLocationProduct OrderLocationProduct_Get(int OrderLocationProductID, SqlTransaction trans)
            {
                var Command = new SqlCommand();
                Command.CommandText = "OrderLocationProduct_Get";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Transaction = trans;
                Command.Connection = trans.Connection;
                Command.Parameters.AddWithValue("@OrderLocationProductID", OrderLocationProductID);
                var Adapter = new SqlDataAdapter(Command);
                var returnDS = new DataSet();
                Adapter.Fill(returnDS);
                var dt = returnDS.Tables[0];
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oOrderLocationProduct = new OrderLocationProduct();
                        oOrderLocationProduct.IgnoreExceptionsOnSetMethods = true;
                        oOrderLocationProduct.SetOrderLocationProductID = dt.Rows[0]["OrderLocationProductID"];
                        oOrderLocationProduct.SetProductID = dt.Rows[0]["ProductID"];
                        oOrderLocationProduct.SetLocationID = dt.Rows[0]["LocationID"];
                        oOrderLocationProduct.SetQuantity = dt.Rows[0]["Quantity"];
                        oOrderLocationProduct.SetQuantityReceived = dt.Rows[0]["QuantityReceived"];
                        oOrderLocationProduct.SetOrderID = dt.Rows[0]["OrderID"];
                        oOrderLocationProduct.SetSellPrice = dt.Rows[0]["SellPrice"];
                        oOrderLocationProduct.SetDeleted = Conversions.ToBoolean(dt.Rows[0]["Deleted"]);
                        oOrderLocationProduct.Exists = true;
                        return oOrderLocationProduct;
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

            public OrderLocationProduct OrderLocationProduct_Get(int OrderLocationProductID)
            {
                _database.ClearParameter();
                _database.AddParameter("@OrderLocationProductID", OrderLocationProductID);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("OrderLocationProduct_Get");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oOrderLocationProduct = new OrderLocationProduct();
                        oOrderLocationProduct.IgnoreExceptionsOnSetMethods = true;
                        oOrderLocationProduct.SetOrderLocationProductID = dt.Rows[0]["OrderLocationProductID"];
                        oOrderLocationProduct.SetProductID = dt.Rows[0]["ProductID"];
                        oOrderLocationProduct.SetLocationID = dt.Rows[0]["LocationID"];
                        oOrderLocationProduct.SetQuantity = dt.Rows[0]["Quantity"];
                        oOrderLocationProduct.SetQuantityReceived = dt.Rows[0]["QuantityReceived"];
                        oOrderLocationProduct.SetOrderID = dt.Rows[0]["OrderID"];
                        oOrderLocationProduct.SetSellPrice = dt.Rows[0]["SellPrice"];
                        oOrderLocationProduct.SetDeleted = Conversions.ToBoolean(dt.Rows[0]["Deleted"]);
                        oOrderLocationProduct.Exists = true;
                        return oOrderLocationProduct;
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

            public DataView OrderLocationProduct_GetAll()
            {
                _database.ClearParameter();
                var dt = _database.ExecuteSP_DataTable("OrderLocationProduct_GetAll");
                dt.TableName = Sys.Enums.TableNames.tblOrderLocationProduct.ToString();
                return new DataView(dt);
            }

            public OrderLocationProduct Insert(OrderLocationProduct oOrderLocationProduct, bool DoConsolidation)
            {
                _database.ClearParameter();
                AddOrderLocationProductParametersToCommand(ref oOrderLocationProduct);
                oOrderLocationProduct.SetOrderLocationProductID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("OrderLocationProduct_Insert"));
                oOrderLocationProduct.Exists = true;
                if (DoConsolidation)
                {
                    App.DB.OrderConsolidations.Create_And_Insert_Location(oOrderLocationProduct.LocationID, oOrderLocationProduct.OrderID);
                }

                return oOrderLocationProduct;
            }

            public OrderLocationProduct Insert(OrderLocationProduct oOrderLocationProduct, bool DoConsolidation, SqlTransaction trans)
            {
                var Command = new SqlCommand();
                Command.CommandText = "OrderLocationProduct_Insert";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Transaction = trans;
                Command.Connection = trans.Connection;
                Command.Parameters.AddWithValue("@ProductID", oOrderLocationProduct.ProductID);
                Command.Parameters.AddWithValue("@LocationID", oOrderLocationProduct.LocationID);
                Command.Parameters.AddWithValue("@Quantity", oOrderLocationProduct.Quantity);
                Command.Parameters.AddWithValue("@QuantityReceived", oOrderLocationProduct.QuantityReceived);
                Command.Parameters.AddWithValue("@OrderID", oOrderLocationProduct.OrderID);
                Command.Parameters.AddWithValue("@SellPrice", oOrderLocationProduct.SellPrice);
                oOrderLocationProduct.SetOrderLocationProductID = Sys.Helper.MakeIntegerValid(Command.ExecuteScalar());
                oOrderLocationProduct.Exists = true;
                if (DoConsolidation)
                {
                    App.DB.OrderConsolidations.Create_And_Insert_Location(oOrderLocationProduct.LocationID, oOrderLocationProduct.OrderID, trans);
                }

                return oOrderLocationProduct;
            }

            public void Update(OrderLocationProduct oOrderLocationProduct)
            {
                _database.ClearParameter();
                _database.AddParameter("@OrderLocationProductID", oOrderLocationProduct.OrderLocationProductID, true);
                AddOrderLocationProductParametersToCommand(ref oOrderLocationProduct);
                _database.ExecuteSP_NO_Return("OrderLocationProduct_Update");
            }

            private void AddOrderLocationProductParametersToCommand(ref OrderLocationProduct oOrderLocationProduct)
            {
                {
                    var withBlock = _database;
                    withBlock.AddParameter("@ProductID", oOrderLocationProduct.ProductID, true);
                    withBlock.AddParameter("@LocationID", oOrderLocationProduct.LocationID, true);
                    withBlock.AddParameter("@Quantity", oOrderLocationProduct.Quantity, true);
                    withBlock.AddParameter("@QuantityReceived", oOrderLocationProduct.QuantityReceived, true);
                    withBlock.AddParameter("@OrderID", oOrderLocationProduct.OrderID, true);
                    withBlock.AddParameter("@SellPrice", oOrderLocationProduct.SellPrice, true);
                }
            }

            public void MarkOrderQuantityReceived(int OrderLocationProductID, int QuantityReceived)
            {
                _database.ClearParameter();
                _database.AddParameter("@OrderLocationProductID", OrderLocationProductID, true);
                _database.AddParameter("@QuantityRecieved", QuantityReceived, true);
                _database.ExecuteSP_NO_Return("OrderLocationProduct_MarkOrderQuantityReceived");
            }

            
        }
    }
}