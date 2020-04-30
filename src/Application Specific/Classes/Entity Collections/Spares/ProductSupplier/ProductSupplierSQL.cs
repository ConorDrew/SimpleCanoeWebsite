using System.Data;
using System.Data.SqlClient;

namespace FSM.Entity
{
    namespace ProductSuppliers
    {
        public class ProductSupplierSQL
        {
            private Sys.Database _database;

            public ProductSupplierSQL(Sys.Database database)
            {
                _database = database;
            }

            
            public object ProductSupplier_Search(string SearchString, int SupplierID = 0)
            {
                _database.ClearParameter();
                _database.AddParameter("@SearchString", SearchString, true);
                _database.AddParameter("@SupplierID", SupplierID, true);
                var dt = _database.ExecuteSP_DataTable("ProductSupplier_Search");
                dt.TableName = Sys.Enums.TableNames.tblProduct.ToString();
                return new DataView(dt);
            }

            public ProductSupplier ProductSupplier_Get(int ProductSupplierID, SqlTransaction trans)
            {
                var Command = new SqlCommand();
                Command.CommandText = "ProductSupplier_Get";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Transaction = trans;
                Command.Connection = trans.Connection;
                Command.Parameters.AddWithValue("@ProductSupplierID", ProductSupplierID);
                var Adapter = new SqlDataAdapter(Command);
                var returnDS = new DataSet();
                Adapter.Fill(returnDS);
                var dt = returnDS.Tables[0];
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oProductSupplier = new ProductSupplier();
                        oProductSupplier.IgnoreExceptionsOnSetMethods = true;
                        oProductSupplier.SetProductID = dt.Rows[0]["ProductID"];
                        oProductSupplier.SetProductSupplierID = dt.Rows[0]["ProductSupplierID"];
                        oProductSupplier.SetProductCode = dt.Rows[0]["ProductCode"];
                        oProductSupplier.SetPrice = dt.Rows[0]["Price"];
                        oProductSupplier.SetSupplierID = dt.Rows[0]["SupplierID"];
                        oProductSupplier.SetQuantityInPack = dt.Rows[0]["QuantityInPack"];
                        oProductSupplier.Exists = true;
                        return oProductSupplier;
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

            public ProductSupplier ProductSupplier_Get(int ProductSupplierID)
            {
                _database.ClearParameter();
                _database.AddParameter("@ProductSupplierID", ProductSupplierID);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("ProductSupplier_Get");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oProductSupplier = new ProductSupplier();
                        oProductSupplier.IgnoreExceptionsOnSetMethods = true;
                        oProductSupplier.SetProductID = dt.Rows[0]["ProductID"];
                        oProductSupplier.SetProductSupplierID = dt.Rows[0]["ProductSupplierID"];
                        oProductSupplier.SetProductCode = dt.Rows[0]["ProductCode"];
                        oProductSupplier.SetPrice = dt.Rows[0]["Price"];
                        oProductSupplier.SetSupplierID = dt.Rows[0]["SupplierID"];
                        oProductSupplier.SetQuantityInPack = dt.Rows[0]["QuantityInPack"];
                        oProductSupplier.Exists = true;
                        return oProductSupplier;
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

            public DataView ProductSupplierPacks_Get(int ProductID, int SupplierID)
            {
                _database.ClearParameter();
                _database.AddParameter("@ProductID", ProductID, true);
                _database.AddParameter("@SupplierID", SupplierID, true);
                var dt = _database.ExecuteSP_DataTable("ProductSupplierPacks_Get");
                dt.TableName = Sys.Enums.TableNames.tblProductSupplier.ToString();
                return new DataView(dt);
            }

            public DataView ProductSupplierPacks_Get(int ProductID, int SupplierID, SqlTransaction trans)
            {
                var Command = new SqlCommand();
                Command.CommandText = "ProductSupplierPacks_Get";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Transaction = trans;
                Command.Connection = trans.Connection;
                Command.Parameters.AddWithValue("@ProductID", ProductID);
                Command.Parameters.AddWithValue("@SupplierID", SupplierID);
                var Adapter = new SqlDataAdapter(Command);
                var returnDS = new DataSet();
                Adapter.Fill(returnDS);
                var dt = returnDS.Tables[0];
                dt.TableName = Sys.Enums.TableNames.tblProductSupplier.ToString();
                return new DataView(dt);
            }

            public DataView ProductSupplierGet_All()
            {
                _database.ClearParameter();
                var dt = _database.ExecuteSP_DataTable("ProductSupplier_GetAll");
                dt.TableName = Sys.Enums.TableNames.tblProductSupplier.ToString();
                return new DataView(dt);
            }

            public DataView Get_ByProductID(int ProductID)
            {
                _database.ClearParameter();
                _database.AddParameter("@ProductID", ProductID, true);
                var dt = _database.ExecuteSP_DataTable("ProductSupplier_GetByProduct");
                dt.TableName = Sys.Enums.TableNames.tblProductSupplier.ToString();
                return new DataView(dt);
            }

            public void Delete(int ProductSupplierID)
            {
                _database.ClearParameter();
                _database.AddParameter("@ProductSupplierID", ProductSupplierID, true);
                _database.ExecuteSP_NO_Return("ProductSupplier_Delete");
            }

            public ProductSupplier Insert(ProductSupplier oProductSupplier)
            {
                _database.ClearParameter();
                AddProductSupplierParametersToCommand(ref oProductSupplier);
                oProductSupplier.SetProductSupplierID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("ProductSupplier_Insert"));
                oProductSupplier.Exists = true;
                return oProductSupplier;
            }

            public void Update(ProductSupplier oProductSupplier)
            {
                _database.ClearParameter();
                _database.AddParameter("@ProductSupplierID", oProductSupplier.ProductSupplierID, true);
                AddProductSupplierParametersToCommand(ref oProductSupplier);
                _database.ExecuteSP_NO_Return("ProductSupplier_Update");
            }

            private void AddProductSupplierParametersToCommand(ref ProductSupplier oProductSupplier)
            {
                {
                    var withBlock = _database;
                    withBlock.AddParameter("@ProductID", oProductSupplier.ProductID, true);
                    withBlock.AddParameter("@SupplierID", oProductSupplier.SupplierID, true);
                    withBlock.AddParameter("@ProductCode", oProductSupplier.ProductCode, true);
                    withBlock.AddParameter("@Price", oProductSupplier.Price, true);
                    withBlock.AddParameter("@QuantityInPack", oProductSupplier.QuantityInPack, true);
                }
            }


            
        }
    }
}