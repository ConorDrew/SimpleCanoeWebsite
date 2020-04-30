using System.Data;
using System.Data.SqlClient;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace OrderProducts
    {
        public class OrderProductSQL
        {
            private Sys.Database _database;

            public OrderProductSQL(Sys.Database database)
            {
                _database = database;
            }

            
            public void Delete(int OrderProductID, SqlTransaction trans)
            {
                var Command = new SqlCommand();
                Command.CommandText = "OrderProduct_Delete";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Transaction = trans;
                Command.Connection = trans.Connection;
                Command.Parameters.AddWithValue("@OrderProductID", OrderProductID);
                Command.ExecuteNonQuery();
            }

            public void Delete(int OrderProductID)
            {
                _database.ClearParameter();
                _database.AddParameter("@OrderProductID", OrderProductID, true);
                _database.ExecuteSP_NO_Return("OrderProduct_Delete");
            }

            public void DeleteForOrder(int OrderID)
            {
                _database.ClearParameter();
                _database.AddParameter("@OrderID", OrderID, true);
                _database.ExecuteSP_NO_Return("OrderProduct_DeleteForOrder");
            }

            public OrderProduct OrderProduct_Get(int OrderProductID)
            {
                _database.ClearParameter();
                _database.AddParameter("@OrderProductID", OrderProductID);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("OrderProduct_Get");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oOrderProduct = new OrderProduct();
                        oOrderProduct.IgnoreExceptionsOnSetMethods = true;
                        oOrderProduct.SetOrderProductID = dt.Rows[0]["OrderProductID"];
                        oOrderProduct.SetProductSupplierID = dt.Rows[0]["ProductSupplierID"];
                        oOrderProduct.SetQuantity = dt.Rows[0]["Quantity"];
                        oOrderProduct.SetQuantityReceived = dt.Rows[0]["QuantityReceived"];
                        oOrderProduct.SetBuyPrice = dt.Rows[0]["BuyPrice"];
                        oOrderProduct.SetSellPrice = dt.Rows[0]["SellPrice"];
                        oOrderProduct.SetOrderID = dt.Rows[0]["OrderID"];
                        oOrderProduct.SetDispatchSiteID = dt.Rows[0]["DispatchSiteID"];
                        oOrderProduct.SetDispatchWarehouseID = dt.Rows[0]["DispatchWarehouseID"];
                        oOrderProduct.SetDeleted = Conversions.ToBoolean(dt.Rows[0]["Deleted"]);
                        oOrderProduct.Exists = true;
                        return oOrderProduct;
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

            public DataView OrderProduct_GetAll()
            {
                _database.ClearParameter();
                var dt = _database.ExecuteSP_DataTable("OrderProduct_GetAll");
                dt.TableName = Sys.Enums.TableNames.tblOrderProduct.ToString();
                return new DataView(dt);
            }

            public OrderProduct Insert(OrderProduct oOrderProduct, bool DoConsolidation, SqlTransaction trans)
            {
                var Command = new SqlCommand();
                Command.CommandText = "OrderProduct_Insert";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Transaction = trans;
                Command.Connection = trans.Connection;
                Command.Parameters.AddWithValue("@ProductSupplierID", oOrderProduct.ProductSupplierID);
                Command.Parameters.AddWithValue("@Quantity", oOrderProduct.Quantity);
                Command.Parameters.AddWithValue("@QuantityReceived", oOrderProduct.QuantityReceived);
                Command.Parameters.AddWithValue("@BuyPrice", oOrderProduct.BuyPrice);
                Command.Parameters.AddWithValue("@SellPrice", oOrderProduct.SellPrice);
                Command.Parameters.AddWithValue("@OrderID", oOrderProduct.OrderID);
                Command.Parameters.AddWithValue("@DispatchSiteID", oOrderProduct.DispatchSiteID);
                Command.Parameters.AddWithValue("@DispatchWarehouseID", oOrderProduct.DispatchWarehouseID);
                oOrderProduct.SetOrderProductID = Sys.Helper.MakeIntegerValid(Command.ExecuteScalar());
                oOrderProduct.Exists = true;
                if (DoConsolidation)
                {
                    App.DB.OrderConsolidations.Create_And_Insert_Supplier(0, oOrderProduct.ProductSupplierID, oOrderProduct.OrderID, trans);
                }

                return oOrderProduct;
            }

            public OrderProduct Insert(OrderProduct oOrderProduct, bool DoConsolidation)
            {
                _database.ClearParameter();
                AddOrderProductParametersToCommand(ref oOrderProduct);
                oOrderProduct.SetOrderProductID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("OrderProduct_Insert"));
                oOrderProduct.Exists = true;
                if (DoConsolidation)
                {
                    App.DB.OrderConsolidations.Create_And_Insert_Supplier(0, oOrderProduct.ProductSupplierID, oOrderProduct.OrderID);
                }

                return oOrderProduct;
            }

            public void Update(OrderProduct oOrderProduct)
            {
                _database.ClearParameter();
                _database.AddParameter("@OrderProductID", oOrderProduct.OrderProductID, true);
                AddOrderProductParametersToCommand(ref oOrderProduct);
                _database.ExecuteSP_NO_Return("OrderProduct_Update");
            }

            public void MarkOrderQuantityReceived(int OrderProductID, int QuantityReceived)
            {
                _database.ClearParameter();
                _database.AddParameter("@OrderProductID", OrderProductID, true);
                _database.AddParameter("@QuantityReceived", QuantityReceived, true);
                _database.ExecuteSP_NO_Return("OrderProduct_MarkOrderQuantityReceived");
            }

            private void AddOrderProductParametersToCommand(ref OrderProduct oOrderProduct)
            {
                {
                    var withBlock = _database;
                    withBlock.AddParameter("@ProductSupplierID", oOrderProduct.ProductSupplierID, true);
                    withBlock.AddParameter("@Quantity", oOrderProduct.Quantity, true);
                    withBlock.AddParameter("@QuantityReceived", oOrderProduct.QuantityReceived, true);
                    withBlock.AddParameter("@BuyPrice", oOrderProduct.BuyPrice, true);
                    withBlock.AddParameter("@SellPrice", oOrderProduct.SellPrice, true);
                    withBlock.AddParameter("@OrderID", oOrderProduct.OrderID, true);
                    withBlock.AddParameter("@DispatchSiteID", oOrderProduct.DispatchSiteID, true);
                    withBlock.AddParameter("@DispatchWarehouseID", oOrderProduct.DispatchWarehouseID, true);
                }
            }


            
        }
    }
}