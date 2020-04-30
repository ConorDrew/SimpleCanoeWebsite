using System.Data;
using System.Data.SqlClient;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace OrderParts
    {
        public class OrderPartSQL
        {
            private Sys.Database _database;

            public OrderPartSQL(Sys.Database database)
            {
                _database = database;
            }

            
            public void Delete(int OrderPartID, SqlTransaction trans)
            {
                var Command = new SqlCommand();
                Command.CommandText = "OrderPart_Delete";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Transaction = trans;
                Command.Connection = trans.Connection;
                Command.Parameters.AddWithValue("@OrderPartID", OrderPartID);
                Command.ExecuteNonQuery();
            }

            public void Delete(int OrderPartID)
            {
                _database.ClearParameter();
                _database.AddParameter("@OrderPartID", OrderPartID, true);
                _database.ExecuteSP_NO_Return("OrderPart_Delete");
            }

            public void DeleteForOrder(int OrderID)
            {
                _database.ClearParameter();
                _database.AddParameter("@OrderID", OrderID, true);
                _database.ExecuteSP_NO_Return("OrderPart_DeleteForOrder");
            }

            public OrderPart OrderPart_Get(int OrderPartID)
            {
                _database.ClearParameter();
                _database.AddParameter("@OrderPartID", OrderPartID);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("OrderPart_Get");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oOrderPart = new OrderPart();
                        oOrderPart.IgnoreExceptionsOnSetMethods = true;
                        oOrderPart.SetOrderPartID = dt.Rows[0]["OrderPartID"];
                        oOrderPart.SetOrderID = dt.Rows[0]["OrderID"];
                        oOrderPart.SetPartSupplierID = dt.Rows[0]["PartSupplierID"];
                        oOrderPart.SetQuantity = dt.Rows[0]["Quantity"];
                        oOrderPart.SetQuantityReceived = dt.Rows[0]["QuantityReceived"];
                        oOrderPart.SetBuyPrice = dt.Rows[0]["BuyPrice"];
                        oOrderPart.SetSellPrice = dt.Rows[0]["SellPrice"];
                        oOrderPart.SetDispatchSiteID = dt.Rows[0]["DispatchSiteID"];
                        oOrderPart.SetDispatchWarehouseID = dt.Rows[0]["DispatchWarehouseID"];
                        oOrderPart.SetDeleted = Conversions.ToBoolean(dt.Rows[0]["Deleted"]);
                        oOrderPart.SetChildSupplierID = dt.Rows[0]["ChildSupplierID"];
                        oOrderPart.SetSpecialDescription = dt.Rows[0]["SpecialDescription"];
                        oOrderPart.SetSpecialPartNumber = dt.Rows[0]["SpecialPartNumber"];
                        oOrderPart.Exists = true;
                        return oOrderPart;
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

            public DataView OrderPart_GetAll()
            {
                _database.ClearParameter();
                var dt = _database.ExecuteSP_DataTable("OrderPart_GetAll");
                dt.TableName = Sys.Enums.TableNames.tblOrderPart.ToString();
                return new DataView(dt);
            }

            public OrderPart Insert(OrderPart oOrderPart, bool DoConsolidation)
            {
                _database.ClearParameter();
                AddOrderPartParametersToCommand(ref oOrderPart);
                oOrderPart.SetOrderPartID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("OrderPart_Insert"));
                oOrderPart.Exists = true;
                if (DoConsolidation)
                {
                    App.DB.OrderConsolidations.Create_And_Insert_Supplier(oOrderPart.PartSupplierID, 0, oOrderPart.OrderID);
                }

                return oOrderPart;
            }

            public OrderPart Insert(OrderPart oOrderPart, bool DoConsolidation, SqlTransaction trans)
            {
                var Command = new SqlCommand();
                Command.CommandText = "OrderPart_Insert";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Transaction = trans;
                Command.Connection = trans.Connection;
                Command.Parameters.AddWithValue("@PartSupplierID", oOrderPart.PartSupplierID);
                Command.Parameters.AddWithValue("@Quantity", oOrderPart.Quantity);
                Command.Parameters.AddWithValue("@QuantityReceived", oOrderPart.QuantityReceived);
                Command.Parameters.AddWithValue("@BuyPrice", oOrderPart.BuyPrice);
                Command.Parameters.AddWithValue("@SellPrice", oOrderPart.SellPrice);
                Command.Parameters.AddWithValue("@OrderID", oOrderPart.OrderID);
                Command.Parameters.AddWithValue("@DispatchSiteID", oOrderPart.DispatchSiteID);
                Command.Parameters.AddWithValue("@DispatchWarehouseID", oOrderPart.DispatchWarehouseID);
                Command.Parameters.AddWithValue("@ChildSupplierID", oOrderPart.ChildSupplierID);
                Command.Parameters.AddWithValue("@SpecialDescription", oOrderPart.SpecialDescription);
                Command.Parameters.AddWithValue("@SpecialPartNumber", oOrderPart.SpecialPartNumber);
                oOrderPart.SetOrderPartID = Sys.Helper.MakeIntegerValid(Command.ExecuteScalar());
                oOrderPart.Exists = true;
                if (DoConsolidation)
                {
                    App.DB.OrderConsolidations.Create_And_Insert_Supplier(oOrderPart.PartSupplierID, 0, oOrderPart.OrderID, trans);
                }

                return oOrderPart;
            }

            public void Update(OrderPart oOrderPart)
            {
                _database.ClearParameter();
                _database.AddParameter("@OrderPartID", oOrderPart.OrderPartID, true);
                AddOrderPartParametersToCommand(ref oOrderPart);
                _database.ExecuteSP_NO_Return("OrderPart_Update");
            }

            public void MarkOrderQuantityReceived(int OrderPartID, int QuantityReceived)
            {
                _database.ClearParameter();
                _database.AddParameter("@OrderPartID", OrderPartID, true);
                _database.AddParameter("@QuantityReceived", QuantityReceived, true);
                _database.ExecuteSP_NO_Return("OrderPart_MarkOrderQuantityReceived");
            }

            private void AddOrderPartParametersToCommand(ref OrderPart oOrderPart)
            {
                {
                    var withBlock = _database;
                    withBlock.AddParameter("@OrderID", oOrderPart.OrderID, true);
                    withBlock.AddParameter("@PartSupplierID", oOrderPart.PartSupplierID, true);
                    withBlock.AddParameter("@Quantity", oOrderPart.Quantity, true);
                    withBlock.AddParameter("@QuantityReceived", oOrderPart.QuantityReceived, true);
                    withBlock.AddParameter("@BuyPrice", oOrderPart.BuyPrice, true);
                    withBlock.AddParameter("@SellPrice", oOrderPart.SellPrice, true);
                    withBlock.AddParameter("@DispatchSiteID", oOrderPart.DispatchSiteID, true);
                    withBlock.AddParameter("@DispatchWarehouseID", oOrderPart.DispatchWarehouseID, true);
                    withBlock.AddParameter("@ChildSupplierID", oOrderPart.ChildSupplierID, true);
                    withBlock.AddParameter("@SpecialDescription", oOrderPart.SpecialDescription, true);
                    withBlock.AddParameter("@SpecialPartNumber", oOrderPart.SpecialPartNumber, true);
                }
            }

            public void EngineerReceived(int OrderPartID)
            {
                _database.ClearParameter();
                _database.AddParameter("@OrderPartID", OrderPartID, true);
                _database.ExecuteSP_NO_Return("OrderPart_EngineerReceived");
            }
            
        }
    }
}