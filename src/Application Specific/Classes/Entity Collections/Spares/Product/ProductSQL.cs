using System.Data;
using System.Data.SqlClient;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity.Products
{
    public class ProductSQL
    {
        private Sys.Database _database;

        public ProductSQL(Sys.Database database)
        {
            _database = database;
        }

        
        public void Delete(int ProductID)
        {
            _database.ClearParameter();
            _database.AddParameter("@ProductID", ProductID, true);
            _database.ExecuteSP_NO_Return("Product_Delete");
        }

        public Product Product_Get(int ProductID, SqlTransaction trans)
        {
            var Command = new SqlCommand();
            Command.CommandText = "Product_Get";
            Command.CommandType = CommandType.StoredProcedure;
            Command.Transaction = trans;
            Command.Connection = trans.Connection;
            Command.Parameters.AddWithValue("@ProductID", ProductID);
            var Adapter = new SqlDataAdapter(Command);
            var returnDS = new DataSet();
            Adapter.Fill(returnDS);

            // Get the datatable from the database store in dt
            var dt = _database.ExecuteSP_DataTable("");
            if (dt is object)
            {
                if (dt.Rows.Count > 0)
                {
                    var oProduct = new Product();
                    oProduct.IgnoreExceptionsOnSetMethods = true;
                    oProduct.SetProductID = dt.Rows[0]["ProductID"];
                    oProduct.SetNumber = dt.Rows[0]["Number"];
                    oProduct.SetReference = Sys.Helper.MakeStringValid(dt.Rows[0]["Reference"]);
                    oProduct.SetTypeID = dt.Rows[0]["TypeID"];
                    oProduct.SetMakeID = dt.Rows[0]["MakeID"];
                    oProduct.SetModelID = dt.Rows[0]["ModelID"];
                    oProduct.SetNotes = dt.Rows[0]["Notes"];
                    oProduct.SetSellPrice = dt.Rows[0]["SellPrice"];
                    oProduct.SetName = dt.Rows[0]["Name"];
                    oProduct.SetDeleted = Conversions.ToBoolean(dt.Rows[0]["Deleted"]);
                    oProduct.SetMinimumQuantity = dt.Rows[0]["MinimumQuantity"];
                    oProduct.SetRecommendedQuantity = dt.Rows[0]["RecommendedQuantity"];
                    oProduct.AssociatedPart = App.DB.ProductAssociatedPart.GetAll_For_ProductID(ProductID);
                    oProduct.Exists = true;
                    return oProduct;
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

        public Product Product_Get(int ProductID)
        {
            _database.ClearParameter();
            _database.AddParameter("@ProductID", ProductID);

            // Get the datatable from the database store in dt
            var dt = _database.ExecuteSP_DataTable("Product_Get");
            if (dt is object)
            {
                if (dt.Rows.Count > 0)
                {
                    var oProduct = new Product();
                    oProduct.IgnoreExceptionsOnSetMethods = true;
                    oProduct.SetProductID = dt.Rows[0]["ProductID"];
                    oProduct.SetNumber = dt.Rows[0]["Number"];
                    oProduct.SetReference = Sys.Helper.MakeStringValid(dt.Rows[0]["Reference"]);
                    oProduct.SetTypeID = dt.Rows[0]["TypeID"];
                    oProduct.SetMakeID = dt.Rows[0]["MakeID"];
                    oProduct.SetModelID = dt.Rows[0]["ModelID"];
                    oProduct.SetNotes = dt.Rows[0]["Notes"];
                    oProduct.SetSellPrice = dt.Rows[0]["SellPrice"];
                    oProduct.SetName = dt.Rows[0]["Name"];
                    oProduct.SetDeleted = Conversions.ToBoolean(dt.Rows[0]["Deleted"]);
                    oProduct.SetMinimumQuantity = dt.Rows[0]["MinimumQuantity"];
                    oProduct.SetRecommendedQuantity = dt.Rows[0]["RecommendedQuantity"];
                    oProduct.AssociatedPart = App.DB.ProductAssociatedPart.GetAll_For_ProductID(ProductID);
                    oProduct.Exists = true;
                    return oProduct;
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

        public bool Check_Unique_Number(string Number, int ID)
        {
            int NumberOfProducts = Sys.Helper.MakeIntegerValid(_database.ExecuteScalar("SELECT COUNT(ProductID) as 'NumberOfProducts' " + "FROM tblproduct WHERE deleted =0 AND Number = '" + Number + "' AND ProductID <> " + ID, false));
            if (NumberOfProducts == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public DataView Product_GetAll()
        {
            _database.ClearParameter();
            var dt = _database.ExecuteSP_DataTable("Product_GetAll");
            dt.TableName = Sys.Enums.TableNames.tblProduct.ToString();
            return new DataView(dt);
        }

        public DataView Product_GetAll(SqlTransaction trans)
        {
            var Command = new SqlCommand();
            Command.CommandText = "Product_GetAll";
            Command.CommandType = CommandType.StoredProcedure;
            Command.Transaction = trans;
            Command.Connection = trans.Connection;
            var Adapter = new SqlDataAdapter(Command);
            var returnDS = new DataSet();
            Adapter.Fill(returnDS);
            var dt = returnDS.Tables[0];
            dt.TableName = Sys.Enums.TableNames.tblProduct.ToString();
            return new DataView(dt);
        }

        public DataView Product_Search(string criteria, string SearchOnField)
        {
            if (SearchOnField.Trim().Length > 0)
            {
                criteria = "'%" + criteria + "%'";
            }

            _database.ClearParameter();
            _database.AddParameter("@SearchString", criteria, true);
            _database.AddParameter("@SearchOnField", SearchOnField, true);
            var dt = _database.ExecuteSP_DataTable("Product_SearchList");
            dt.TableName = Sys.Enums.TableNames.tblProduct.ToString();
            return new DataView(dt);
        }

        public int Product_Check_Stock_Level(int ProductID, int LocationID)
        {
            _database.ClearParameter();
            _database.AddParameter("@ProductID", ProductID, true);
            _database.AddParameter("@LocationID", LocationID, true);
            return Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("Product_Check_Stock_Level"));
        }

        public int Product_Check_Stock_Level(int ProductID, int LocationID, SqlTransaction trans)
        {
            var Command = new SqlCommand();
            Command.CommandText = "Product_Check_Stock_Level";
            Command.CommandType = CommandType.StoredProcedure;
            Command.Transaction = trans;
            Command.Connection = trans.Connection;
            Command.Parameters.AddWithValue("@ProductID", ProductID);
            Command.Parameters.AddWithValue("@LocationID", LocationID);
            return Sys.Helper.MakeIntegerValid(Command.ExecuteScalar());
        }

        public Product Insert(Product oProduct)
        {
            _database.ClearParameter();
            AddProductParametersToCommand(ref oProduct);
            oProduct.SetProductID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("Product_Insert"));
            oProduct.Exists = true;
            InsertAssociatedParts(oProduct);
            return oProduct;
        }

        public void Update(Product oProduct)
        {
            _database.ClearParameter();
            _database.AddParameter("@ProductID", oProduct.ProductID, true);
            AddProductParametersToCommand(ref oProduct);
            _database.ExecuteSP_NO_Return("Product_Update");
            InsertAssociatedParts(oProduct);
        }

        private void AddProductParametersToCommand(ref Product oProduct)
        {
            {
                var withBlock = _database;
                withBlock.AddParameter("@Number", oProduct.Number, true);
                withBlock.AddParameter("@Reference", oProduct.Reference, true);
                withBlock.AddParameter("@TypeID", oProduct.TypeID, true);
                withBlock.AddParameter("@MakeID", oProduct.MakeID, true);
                withBlock.AddParameter("@ModelID", oProduct.ModelID, true);
                withBlock.AddParameter("@Notes", oProduct.Notes, true);
                withBlock.AddParameter("@SellPrice", oProduct.SellPrice, true);
                withBlock.AddParameter("@MinimumQuantity", oProduct.MinimumQuantity, true);
                withBlock.AddParameter("@RecommendedQuantity", oProduct.RecommendedQuantity, true);
            }
        }

        private void InsertAssociatedParts(Product oProduct)
        {
            _database.ProductAssociatedPart.Delete(oProduct.ProductID);
            var oProductAssociatedPart = new ProductAssociatedParts.ProductAssociatedPart();
            oProductAssociatedPart.SetProductID = oProduct.ProductID;
            if (oProduct.AssociatedPart is object)
            {
                foreach (DataRow part in oProduct.AssociatedPart.Table.Rows)
                {
                    if (Conversions.ToBoolean(part["Tick"]))
                    {
                        oProductAssociatedPart.SetPartID = part["PartID"];
                        _database.ProductAssociatedPart.Insert(oProductAssociatedPart);
                    }
                }
            }
        }

        public DataView Stock_Get_Locations(int ProductID)
        {
            _database.ClearParameter();
            _database.AddParameter("@PartID", 0, true);
            _database.AddParameter("@ProductID", ProductID, true);
            _database.AddParameter("@WarehouseID", 0, true);
            var dt = _database.ExecuteSP_DataTable("Stock_Get_Locations");
            dt.TableName = Sys.Enums.TableNames.tblStock.ToString();
            return new DataView(dt);
        }

        public DataView Stock_Get_Locations(int ProductID, SqlTransaction trans)
        {
            var Command = new SqlCommand();
            Command.CommandText = "Stock_Get_Locations";
            Command.CommandType = CommandType.StoredProcedure;
            Command.Transaction = trans;
            Command.Connection = trans.Connection;
            Command.Parameters.AddWithValue("@PartID", 0);
            Command.Parameters.AddWithValue("@ProductID", ProductID);
            Command.Parameters.AddWithValue("@WarehouseID", 0);
            var Adapter = new SqlDataAdapter(Command);
            var returnDS = new DataSet();
            Adapter.Fill(returnDS);
            var dt = returnDS.Tables[0];
            dt.TableName = Sys.Enums.TableNames.tblStock.ToString();
            return new DataView(dt);
        }

        
    }
}