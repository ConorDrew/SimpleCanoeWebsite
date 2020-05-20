using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace PartTransactions
    {
        public class PartTransactionSQL
        {
            private Sys.Database _database;

            public PartTransactionSQL(Sys.Database database)
            {
                _database = database;
            }

            public PartTransaction PartTransaction_GetByOrderLocationPart(int OrderLocationPartID, SqlTransaction trans)
            {
                var Command = new SqlCommand();
                Command.CommandText = "PartTransaction_GetByOrderLocationPart";
                Command.CommandType = CommandType.StoredProcedure;
                if (trans is object)
                {
                    Command.Transaction = trans;
                    Command.Connection = trans.Connection;
                }

                Command.Parameters.AddWithValue("@OrderLocationPartID", OrderLocationPartID);
                var Adapter = new SqlDataAdapter(Command);
                var returnDS = new DataSet();
                Adapter.Fill(returnDS);
                var dt = returnDS.Tables[0];
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oPartTransaction = new PartTransaction();
                        oPartTransaction.IgnoreExceptionsOnSetMethods = true;
                        oPartTransaction.SetPartTransactionID = dt.Rows[0]["PartTransactionID"];
                        oPartTransaction.SetPartID = dt.Rows[0]["PartID"];
                        oPartTransaction.SetAmount = dt.Rows[0]["Amount"];
                        oPartTransaction.TransactionDate = Conversions.ToDate(dt.Rows[0]["TransactionDate"]);
                        oPartTransaction.SetUserID = dt.Rows[0]["UserID"];
                        oPartTransaction.SetTransactionTypeID = dt.Rows[0]["TransactionTypeID"];
                        oPartTransaction.SetLocationID = dt.Rows[0]["LocationID"];
                        oPartTransaction.SetOrderPartID = dt.Rows[0]["OrderPartID"];
                        oPartTransaction.SetOrderLocationPartID = dt.Rows[0]["OrderLocationPartID"];
                        oPartTransaction.SetDeleted = Conversions.ToBoolean(dt.Rows[0]["Deleted"]);
                        oPartTransaction.Exists = true;
                        return oPartTransaction;
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

            public PartTransaction PartTransaction_GetByOrderLocationPart(int OrderLocationPartID)
            {
                _database.ClearParameter();
                _database.AddParameter("@OrderLocationPartID", OrderLocationPartID);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("PartTransaction_GetByOrderLocationPart");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oPartTransaction = new PartTransaction();
                        oPartTransaction.IgnoreExceptionsOnSetMethods = true;
                        oPartTransaction.SetPartTransactionID = dt.Rows[0]["PartTransactionID"];
                        oPartTransaction.SetPartID = dt.Rows[0]["PartID"];
                        oPartTransaction.SetAmount = dt.Rows[0]["Amount"];
                        oPartTransaction.TransactionDate = Conversions.ToDate(dt.Rows[0]["TransactionDate"]);
                        oPartTransaction.SetUserID = dt.Rows[0]["UserID"];
                        oPartTransaction.SetTransactionTypeID = dt.Rows[0]["TransactionTypeID"];
                        oPartTransaction.SetLocationID = dt.Rows[0]["LocationID"];
                        oPartTransaction.SetOrderPartID = dt.Rows[0]["OrderPartID"];
                        oPartTransaction.SetOrderLocationPartID = dt.Rows[0]["OrderLocationPartID"];
                        oPartTransaction.SetDeleted = Conversions.ToBoolean(dt.Rows[0]["Deleted"]);
                        oPartTransaction.Exists = true;
                        return oPartTransaction;
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

            public object PartTransaction_Consolidate_All(int LocationID, int PartID)
            {
                _database.ClearParameter();
                _database.AddParameter("@LocationID", LocationID, true);
                _database.AddParameter("@PartID", PartID, true);
                _database.ExecuteSP_NO_Return("PartTransaction_Consolidate_All");
                return default;
            }

            public DataView SearchByVan(string SearchString, int LocationID)
            {
                _database.ClearParameter();
                _database.AddParameter("@SearchString", SearchString, true);
                _database.AddParameter("@LocationID", LocationID, true);
                var dt = _database.ExecuteSP_DataTable("Part_SearchByVan");
                dt.TableName = Sys.Enums.TableNames.tblPart.ToString();
                return new DataView(dt);
            }

            public DataTable GetByVan2(int VanID, bool WithLocation = false, bool ForIPT = false, int SupplierID = 0)
            {
                int ChildSupplier = App.DB.Supplier.GetChildSupplier(SupplierID);
                if (!(ChildSupplier == 0) & !(ChildSupplier == SupplierID))
                {
                    SupplierID = ChildSupplier;
                }

                if (WithLocation)
                {
                    string registration = App.DB.Van.Van_Get(VanID).Registration.Split('*')[0].Trim();
                    var dt = new DataTable();
                    var loopTable = new DataTable();
                    int i = 0;
                    foreach (DataRow vanRow in App.DB.Van.Van_GetAll(false).Table.Rows)
                    {
                        if ((Sys.Helper.MakeStringValid(vanRow["Registration"]).Split('*')[0].Trim() ?? "") == (registration ?? ""))
                        {
                            _database.ClearParameter();
                            // chkval = vanRow("VanID").ToString
                            _database.AddParameter("@VanID", vanRow["VanID"], true);
                            _database.AddParameter("@SupplierID", SupplierID, true);
                            _database.AddParameter("@Location", Sys.Helper.MakeStringValid(vanRow["Registration"]).Split('*')[1].Trim(), true);
                            // If ForIPT Then
                            // _database.AddParameter("@ForIPT", 1, True)
                            // Else
                            // _database.AddParameter("@ForIPT", 0, True)
                            // End If
                            if (i == 0)
                            {
                                dt = _database.ExecuteSP_DataTable("Part_VanProfile");
                            }
                            else
                            {
                                loopTable = _database.ExecuteSP_DataTable("Part_VanProfile");
                                dt.Merge(loopTable);
                            }

                            i = i + 1;
                        }
                    }

                    dt.TableName = Sys.Enums.TableNames.tblPart.ToString();
                    var dvSort = new DataView(dt);
                    dvSort.Sort = "Amount ASC";
                    return dvSort.Table;
                }
                else
                {
                    _database.ClearParameter();
                    _database.AddParameter("@VanID", VanID, true);
                    if (ForIPT)
                    {
                        _database.AddParameter("@ForIPT", 1, true);
                    }
                    else
                    {
                        _database.AddParameter("@ForIPT", 0, true);
                    }

                    var dt = _database.ExecuteSP_DataTable("Part_GetByVan");
                    dt.TableName = Sys.Enums.TableNames.tblPart.ToString();
                    return dt;
                }
            }

            public DataView GetByWarehouse(int WarehouseID, bool ForIPT = false)
            {
                _database.ClearParameter();
                _database.AddParameter("@WarehouseID", WarehouseID, true);
                if (ForIPT)
                {
                    _database.AddParameter("@ForIPT", 1, true);
                }
                else
                {
                    _database.AddParameter("@ForIPT", 0, true);
                }

                var dt = _database.ExecuteSP_DataTable("Part_GetByWarehouse");
                dt.TableName = Sys.Enums.TableNames.tblPart.ToString();
                return new DataView(dt);
            }

            public DataView SearchByWarehouse(string SearchString, int LocationID)
            {
                _database.ClearParameter();
                _database.AddParameter("@SearchString", SearchString, true);
                _database.AddParameter("@LocationID", LocationID, true);
                var dt = _database.ExecuteSP_DataTable("Part_SearchByWarehouse");
                dt.TableName = Sys.Enums.TableNames.tblPart.ToString();
                return new DataView(dt);
            }

            public void Delete(int PartTransactionID)
            {
                _database.ClearParameter();
                _database.AddParameter("@PartTransactionID", PartTransactionID, true);
                _database.ExecuteSP_NO_Return("PartTransaction_Delete");
            }

            public void Delete(int PartTransactionID, SqlTransaction trans)
            {
                var Command = new SqlCommand();
                Command.CommandText = "PartTransaction_Delete";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Transaction = trans;
                Command.Connection = trans.Connection;
                Command.Parameters.AddWithValue("@PartTransactionID", PartTransactionID);
                Command.ExecuteNonQuery();
            }

            public void DeleteForOrder(int OrderID)
            {
                _database.ClearParameter();
                _database.AddParameter("@OrderID", OrderID, true);
                _database.ExecuteSP_NO_Return("PartTransactions_DeleteForOrder");
            }

            public void DeleteByPartAndLocation(int PartID, int LocationID)
            {
                _database.ClearParameter();
                _database.AddParameter("@PartID", PartID, true);
                _database.AddParameter("@LocationID", LocationID, true);
                _database.ExecuteSP_NO_Return("PartTransaction_DeleteByPartAndLocation");
            }

            public PartTransaction Insert(PartTransaction oPartTransaction)
            {
                _database.ClearParameter();
                AddPartTransactionParametersToCommand(oPartTransaction);
                oPartTransaction.SetPartTransactionID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("PartTransaction_Insert"));
                oPartTransaction.Exists = true;
                return oPartTransaction;
            }

            public PartTransaction Insert(PartTransaction oPartTransaction, SqlTransaction trans)
            {
                var Command = new SqlCommand();
                Command.CommandText = "PartTransaction_Insert";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Transaction = trans;
                Command.Connection = trans.Connection;
                Command.Parameters.Add(new SqlParameter("@PartID", oPartTransaction.PartID));
                Command.Parameters.Add(new SqlParameter("@Amount", oPartTransaction.Amount));
                Command.Parameters.Add(new SqlParameter("@UserID", App.loggedInUser.UserID));
                Command.Parameters.Add(new SqlParameter("@TransactionTypeID", oPartTransaction.TransactionTypeID));
                Command.Parameters.Add(new SqlParameter("@LocationID", oPartTransaction.LocationID));
                Command.Parameters.Add(new SqlParameter("@OrderPartID", oPartTransaction.OrderPartID));
                Command.Parameters.Add(new SqlParameter("@OrderLocationPartID", oPartTransaction.OrderLocationPartID));
                oPartTransaction.SetPartTransactionID = Command.ExecuteScalar();
                oPartTransaction.Exists = true;
                return oPartTransaction;
            }

            public void Update(PartTransaction oPartTransaction)
            {
                _database.ClearParameter();
                _database.AddParameter("@PartTransactionID", oPartTransaction.PartTransactionID, true);
                AddPartTransactionParametersToCommand(oPartTransaction);
                _database.ExecuteSP_NO_Return("PartTransaction_Update");
            }

            private void AddPartTransactionParametersToCommand(PartTransaction oPartTransaction)
            {
                _database.AddParameter("@PartID", oPartTransaction.PartID, true);
                _database.AddParameter("@Amount", oPartTransaction.Amount, true);
                _database.AddParameter("@UserID", App.loggedInUser.UserID, true);
                _database.AddParameter("@TransactionTypeID", oPartTransaction.TransactionTypeID, true);
                _database.AddParameter("@LocationID", oPartTransaction.LocationID, true);
                _database.AddParameter("@OrderPartID", oPartTransaction.OrderPartID, true);
                _database.AddParameter("@OrderLocationPartID", oPartTransaction.OrderLocationPartID, true);
            }

            public void UpdateMinMaxValues(int PartLocationID, int MinValue, int MaxValue)
            {
                _database.ClearParameter();
                _database.AddParameter("@PartLocationID", PartLocationID, true);
                _database.AddParameter("@MinQty", MinValue, true);
                _database.AddParameter("@MaxQty", MaxValue, true);
                _database.ExecuteSP_NO_Return("PartLocations_UpdateMinMax");
            }

            public int PartLocations_Insert2(int PartID, int LocationID, int MinValue, int MaxValue)
            {
                _database.ClearParameter();
                _database.AddParameter("@PartID", PartID, true);
                _database.AddParameter("@LocationID", LocationID, true);
                _database.AddParameter("@MinQty", MinValue, true);
                _database.AddParameter("@RecQty", MaxValue, true);
                return Conversions.ToInteger(_database.ExecuteSP_OBJECT("PartLocations_Insert_WithPartLocationReturn"));
            }
        }
    }
}