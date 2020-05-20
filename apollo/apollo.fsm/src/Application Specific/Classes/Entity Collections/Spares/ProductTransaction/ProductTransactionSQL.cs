using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace ProductTransactions
    {
        public class ProductTransactionSQL
        {
            private Sys.Database _database;

            public ProductTransactionSQL(Sys.Database database)
            {
                _database = database;
            }

            public ProductTransaction ProductTransaction_GetByOrderLocationProduct(int OrderLocationProductID, SqlTransaction trans)
            {
                var Command = new SqlCommand();
                Command.CommandText = "ProductTransaction_GetByOrderLocationProduct";
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
                        var oProductTransaction = new ProductTransaction();
                        oProductTransaction.IgnoreExceptionsOnSetMethods = true;
                        oProductTransaction.SetProductTransactionID = dt.Rows[0]["ProductTransactionID"];
                        oProductTransaction.SetProductID = dt.Rows[0]["ProductID"];
                        oProductTransaction.SetAmount = dt.Rows[0]["Amount"];
                        oProductTransaction.TransactionDate = Conversions.ToDate(dt.Rows[0]["TransactionDate"]);
                        oProductTransaction.SetUserID = dt.Rows[0]["UserID"];
                        oProductTransaction.SetTransactionTypeID = dt.Rows[0]["TransactionTypeID"];
                        oProductTransaction.SetLocationID = dt.Rows[0]["LocationID"];
                        oProductTransaction.SetOrderProductID = dt.Rows[0]["OrderProductID"];
                        oProductTransaction.SetOrderLocationProductID = dt.Rows[0]["OrderLocationProductID"];
                        oProductTransaction.SetDeleted = Conversions.ToBoolean(dt.Rows[0]["Deleted"]);
                        oProductTransaction.Exists = true;
                        return oProductTransaction;
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

            public ProductTransaction ProductTransaction_GetByOrderLocationProduct(int OrderLocationProductID)
            {
                _database.ClearParameter();
                _database.AddParameter("@OrderLocationProductID", OrderLocationProductID);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("ProductTransaction_GetByOrderLocationProduct");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oProductTransaction = new ProductTransaction();
                        oProductTransaction.IgnoreExceptionsOnSetMethods = true;
                        oProductTransaction.SetProductTransactionID = dt.Rows[0]["ProductTransactionID"];
                        oProductTransaction.SetProductID = dt.Rows[0]["ProductID"];
                        oProductTransaction.SetAmount = dt.Rows[0]["Amount"];
                        oProductTransaction.TransactionDate = Conversions.ToDate(dt.Rows[0]["TransactionDate"]);
                        oProductTransaction.SetUserID = dt.Rows[0]["UserID"];
                        oProductTransaction.SetTransactionTypeID = dt.Rows[0]["TransactionTypeID"];
                        oProductTransaction.SetLocationID = dt.Rows[0]["LocationID"];
                        oProductTransaction.SetOrderProductID = dt.Rows[0]["OrderProductID"];
                        oProductTransaction.SetOrderLocationProductID = dt.Rows[0]["OrderLocationProductID"];
                        oProductTransaction.SetDeleted = Conversions.ToBoolean(dt.Rows[0]["Deleted"]);
                        oProductTransaction.Exists = true;
                        return oProductTransaction;
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

            public object ProductTransaction_Consolidate_All(int LocationID, int ProductID)
            {
                _database.ClearParameter();
                _database.AddParameter("@LocationID", LocationID, true);
                _database.AddParameter("@ProductID", ProductID, true);
                _database.ExecuteSP_NO_Return("ProductTransaction_Consolidate_All");
                return default;
            }

            public DataView SearchByVan(string SearchString, int LocationID)
            {
                _database.ClearParameter();
                _database.AddParameter("@SearchString", SearchString, true);
                _database.AddParameter("@LocationID", LocationID, true);
                var dt = _database.ExecuteSP_DataTable("Product_SearchByVan");
                dt.TableName = Sys.Enums.TableNames.tblProduct.ToString();
                return new DataView(dt);
            }

            public DataView GetByVan(int VanID, bool WithLocation = false)
            {
                if (WithLocation)
                {
                    string registration = App.DB.Van.Van_Get(VanID).Registration.Split('*')[0].Trim();
                    var dt = new DataTable();
                    dt.Columns.Add(new DataColumn("Location"));
                    dt.Columns.Add(new DataColumn("ProductID", Type.GetType("System.Int32")));
                    dt.Columns.Add(new DataColumn("typemakemodel"));
                    dt.Columns.Add(new DataColumn("ProductNumber"));
                    dt.Columns.Add(new DataColumn("Amount", Type.GetType("System.Int32")));
                    dt.Columns.Add(new DataColumn("LocationID", Type.GetType("System.Int32")));
                    foreach (DataRow vanRow in App.DB.Van.Van_GetAll(false).Table.Rows)
                    {
                        if ((Sys.Helper.MakeStringValid(vanRow["Registration"]).Split('*')[0].Trim() ?? "") == (registration ?? ""))
                        {
                            _database.ClearParameter();
                            _database.AddParameter("@VanID", vanRow["VanID"], true);
                            foreach (DataRow row in _database.ExecuteSP_DataTable("Product_GetByVan").Rows)
                            {
                                var r = dt.NewRow();
                                r["Location"] = Sys.Helper.MakeStringValid(vanRow["Registration"]).Split('*')[1].Trim();
                                r["ProductID"] = row["ProductID"];
                                r["typemakemodel"] = row["typemakemodel"];
                                r["ProductNumber"] = row["ProductNumber"];
                                r["Amount"] = row["Amount"];
                                r["LocationID"] = row["LocationID"];
                                dt.Rows.Add(r);
                            }
                        }
                    }

                    dt.TableName = Sys.Enums.TableNames.tblProduct.ToString();
                    return new DataView(dt);
                }
                else
                {
                    _database.ClearParameter();
                    _database.AddParameter("@VanID", VanID, true);
                    var dt = _database.ExecuteSP_DataTable("Product_GetByVan");
                    dt.TableName = Sys.Enums.TableNames.tblProduct.ToString();
                    return new DataView(dt);
                }
            }

            public DataView GetByWarehouse(int WarehouseID)
            {
                _database.ClearParameter();
                _database.AddParameter("@WarehouseID", WarehouseID, true);
                var dt = _database.ExecuteSP_DataTable("Product_GetByWarehouse");
                dt.TableName = Sys.Enums.TableNames.tblProduct.ToString();
                return new DataView(dt);
            }

            public DataView SearchByWarehouse(string SearchString, int LocationID)
            {
                _database.ClearParameter();
                _database.AddParameter("@SearchString", SearchString, true);
                _database.AddParameter("@LocationID", LocationID, true);
                var dt = _database.ExecuteSP_DataTable("Product_SearchByWarehouse");
                dt.TableName = Sys.Enums.TableNames.tblProduct.ToString();
                return new DataView(dt);
            }

            public void DeleteForOrder(int OrderID)
            {
                _database.ClearParameter();
                _database.AddParameter("@OrderID", OrderID, true);
                _database.ExecuteSP_NO_Return("ProductTransactions_DeleteForOrder");
            }

            public void Delete(int ProductTransactionID, SqlTransaction trans)
            {
                var Command = new SqlCommand();
                Command.CommandText = "ProductTransaction_Delete";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Transaction = trans;
                Command.Connection = trans.Connection;
                Command.Parameters.AddWithValue("@ProductTransactionID", ProductTransactionID);
                Command.ExecuteNonQuery();
            }

            public void Delete(int ProductTransactionID)
            {
                _database.ClearParameter();
                _database.AddParameter("@ProductTransactionID", ProductTransactionID, true);
                _database.ExecuteSP_NO_Return("ProductTransaction_Delete");
            }

            public ProductTransaction Insert(ProductTransaction oProductTransaction, SqlTransaction trans)
            {
                var Command = new SqlCommand();
                Command.CommandText = "ProductTransaction_Insert";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Transaction = trans;
                Command.Connection = trans.Connection;
                Command.Parameters.Add(new SqlParameter("@ProductID", oProductTransaction.ProductID));
                Command.Parameters.Add(new SqlParameter("@Amount", oProductTransaction.Amount));
                Command.Parameters.Add(new SqlParameter("@UserID", App.loggedInUser.UserID));
                Command.Parameters.Add(new SqlParameter("@TransactionTypeID", oProductTransaction.TransactionTypeID));
                Command.Parameters.Add(new SqlParameter("@LocationID", oProductTransaction.LocationID));
                Command.Parameters.Add(new SqlParameter("@OrderProductID", oProductTransaction.OrderProductID));
                Command.Parameters.Add(new SqlParameter("@OrderLocationProductID", oProductTransaction.OrderLocationProductID));
                oProductTransaction.SetProductTransactionID = Command.ExecuteScalar();
                oProductTransaction.Exists = true;
                return oProductTransaction;
            }

            public ProductTransaction Insert(ProductTransaction oProductTransaction)
            {
                _database.ClearParameter();
                AddProductTransactionParametersToCommand(oProductTransaction);
                oProductTransaction.SetProductTransactionID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("ProductTransaction_Insert"));
                oProductTransaction.Exists = true;
                return oProductTransaction;
            }

            public void Update(ProductTransaction oProductTransaction)
            {
                _database.ClearParameter();
                _database.AddParameter("@ProductTransactionID", oProductTransaction.ProductTransactionID, true);
                AddProductTransactionParametersToCommand(oProductTransaction);
                _database.ExecuteSP_NO_Return("ProductTransaction_Update");
            }

            private void AddProductTransactionParametersToCommand(ProductTransaction oProductTransaction)
            {
                _database.AddParameter("@ProductID", oProductTransaction.ProductID, true);
                _database.AddParameter("@Amount", oProductTransaction.Amount, true);
                _database.AddParameter("@UserID", App.loggedInUser.UserID, true);
                _database.AddParameter("@TransactionTypeID", oProductTransaction.TransactionTypeID, true);
                _database.AddParameter("@LocationID", oProductTransaction.LocationID, true);
                _database.AddParameter("@OrderProductID", oProductTransaction.OrderProductID, true);
                _database.AddParameter("@OrderLocationProductID", oProductTransaction.OrderLocationProductID, true);
            }
        }
    }
}