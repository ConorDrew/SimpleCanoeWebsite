using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace Parts
    {
        public class PartSQL
        {
            private Sys.Database _database;

            public PartSQL(Sys.Database database)
            {
                _database = database;
            }

            public void Delete(int PartID)
            {
                _database.ClearParameter();
                _database.AddParameter("@PartID", PartID, true);
                _database.ExecuteSP_NO_Return("Part_Delete");
            }

            public Part Part_Get(int PartID, SqlTransaction trans)
            {
                var Command = new SqlCommand();
                Command.CommandText = "Part_Get";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Transaction = trans;
                Command.Connection = trans.Connection;
                Command.Parameters.AddWithValue("@PartID", PartID);
                var Adapter = new SqlDataAdapter(Command);
                var returnDS = new DataSet();
                Adapter.Fill(returnDS);
                var dt = returnDS.Tables[0];
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oPart = new Part();
                        oPart.IgnoreExceptionsOnSetMethods = true;
                        oPart.SetPartID = dt.Rows[0]["PartID"];
                        oPart.SetName = Sys.Helper.MakeStringValid(dt.Rows[0]["Name"]);
                        oPart.SetNumber = Sys.Helper.MakeStringValid(dt.Rows[0]["Number"]);
                        oPart.SetReference = Sys.Helper.MakeStringValid(dt.Rows[0]["Reference"]);
                        oPart.SetNotes = Sys.Helper.MakeStringValid(dt.Rows[0]["Notes"]);
                        oPart.SetUnitTypeID = dt.Rows[0]["UnitTypeID"];
                        oPart.SetDeleted = Conversions.ToBoolean(dt.Rows[0]["Deleted"]);
                        oPart.SetSellPrice = dt.Rows[0]["SellPrice"];
                        oPart.SetMinimumQuantity = dt.Rows[0]["MinimumQuantity"];
                        oPart.SetRecommendedQuantity = dt.Rows[0]["RecommendedQuantity"];
                        oPart.SetCategoryID = dt.Rows[0]["CategoryID"];
                        oPart.SetWarehouseID = dt.Rows[0]["WarehouseID"];
                        oPart.SetShelfID = dt.Rows[0]["ShelfID"];
                        oPart.SetBinID = dt.Rows[0]["BinID"];
                        oPart.SetWarehouseQuantity = dt.Rows[0]["WarehouseQuantity"];
                        oPart.SetWarehouseIDAlternative = dt.Rows[0]["WarehouseIDAlternative"];
                        oPart.SetShelfIDAlternative = dt.Rows[0]["ShelfIDAlternative"];
                        oPart.SetBinIDAlternative = dt.Rows[0]["BinIDAlternative"];
                        oPart.SetEndFlagged = Conversions.ToBoolean(dt.Rows[0]["EndFlagged"]);
                        oPart.SetEquipment = Sys.Helper.MakeBooleanValid(dt.Rows[0]["Equipment"]);
                        oPart.SetFuelID = Sys.Helper.MakeIntegerValid(dt.Rows[0]["FuelID"]);
                        oPart.SetMakeID = Sys.Helper.MakeIntegerValid(dt.Rows[0]["MakeID"]);
                        oPart.Exists = true;
                        return oPart;
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

            public Part Part_Get(int PartID)
            {
                _database.ClearParameter();
                _database.AddParameter("@PartID", PartID);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("Part_Get");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oPart = new Part();
                        oPart.IgnoreExceptionsOnSetMethods = true;
                        oPart.SetPartID = dt.Rows[0]["PartID"];
                        oPart.SetName = Sys.Helper.MakeStringValid(dt.Rows[0]["Name"]);
                        oPart.SetNumber = Sys.Helper.MakeStringValid(dt.Rows[0]["Number"]);
                        oPart.SetReference = Sys.Helper.MakeStringValid(dt.Rows[0]["Reference"]);
                        oPart.SetNotes = Sys.Helper.MakeStringValid(dt.Rows[0]["Notes"]);
                        oPart.SetUnitTypeID = dt.Rows[0]["UnitTypeID"];
                        oPart.SetDeleted = Conversions.ToBoolean(dt.Rows[0]["Deleted"]);
                        oPart.SetSellPrice = dt.Rows[0]["SellPrice"];
                        oPart.SetMinimumQuantity = dt.Rows[0]["MinimumQuantity"];
                        oPart.SetRecommendedQuantity = dt.Rows[0]["RecommendedQuantity"];
                        oPart.SetCategoryID = dt.Rows[0]["CategoryID"];
                        oPart.SetWarehouseID = dt.Rows[0]["WarehouseID"];
                        oPart.SetShelfID = dt.Rows[0]["ShelfID"];
                        oPart.SetBinID = dt.Rows[0]["BinID"];
                        oPart.SetWarehouseQuantity = dt.Rows[0]["WarehouseQuantity"];
                        oPart.SetWarehouseIDAlternative = dt.Rows[0]["WarehouseIDAlternative"];
                        oPart.SetShelfIDAlternative = dt.Rows[0]["ShelfIDAlternative"];
                        oPart.SetBinIDAlternative = dt.Rows[0]["BinIDAlternative"];
                        oPart.SetEndFlagged = Conversions.ToBoolean(dt.Rows[0]["EndFlagged"]);
                        oPart.SetEquipment = Sys.Helper.MakeBooleanValid(dt.Rows[0]["Equipment"]);
                        oPart.SetFuelID = Sys.Helper.MakeIntegerValid(dt.Rows[0]["FuelID"]);
                        oPart.SetMakeID = Sys.Helper.MakeIntegerValid(dt.Rows[0]["MakeID"]);
                        oPart.SetIsSpecialPart = Conversions.ToBoolean(dt.Rows[0]["IsSpecialPart"]);
                        if (dt.Columns.Contains("NominalID"))
                            oPart.SetNominalID = Sys.Helper.MakeStringValid(dt.Rows[0]["NominalID"]);
                        oPart.Exists = true;
                        return oPart;
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

            public Part Part_Get_For_Code_And_Supplier(string Code, int SupplierID)
            {
                _database.ClearParameter();
                _database.AddParameter("@PartID", Code);
                _database.AddParameter("@SupplierID", SupplierID);
                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("PartSupplier_GetByPartCodeAndSupplier");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oPart = new Part();
                        oPart.IgnoreExceptionsOnSetMethods = true;
                        oPart.SetPartID = dt.Rows[0]["PartID"];
                        oPart.SetName = Sys.Helper.MakeStringValid(dt.Rows[0]["Name"]);
                        oPart.SetNumber = Sys.Helper.MakeStringValid(dt.Rows[0]["Number"]);
                        oPart.SetSPartID = dt.Rows[0]["PartSupplierID"];
                        oPart.Exists = true;
                        return oPart;
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
                int NumberOfParts = Sys.Helper.MakeIntegerValid(_database.ExecuteScalar("SELECT COUNT(PartID) as 'NumberOfParts' " + "FROM tblpart WHERE Deleted = 0 AND Number = '" + Number + "' AND partid <> " + ID, false));
                if (NumberOfParts == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public bool Check_Unique_Bin(int BinID, int ID, string ColumnName)
            {
                int NumberOfParts = Sys.Helper.MakeIntegerValid(_database.ExecuteScalar("SELECT COUNT(PartID) as 'NumberOfParts' " + "FROM tblpart WHERE " + ColumnName + " = " + BinID + " AND partid <> " + ID, false));
                if (NumberOfParts == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public DataView Part_GetAll(SqlTransaction trans)
            {
                var Command = new SqlCommand();
                Command.CommandText = "Part_GetAll";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Transaction = trans;
                Command.Connection = trans.Connection;
                var Adapter = new SqlDataAdapter(Command);
                var returnDS = new DataSet();
                Adapter.Fill(returnDS);
                var dt = returnDS.Tables[0];
                dt.TableName = Sys.Enums.TableNames.tblPart.ToString();
                return new DataView(dt);
            }

            public DataView Part_GetAll(bool ForMassPartEntry = false)
            {
                _database.ClearParameter();
                var dt = _database.ExecuteSP_DataTable("Part_GetAll");
                if (ForMassPartEntry)
                {
                    dt.AcceptChanges();
                    dt.Columns.Add(new DataColumn("QuantityToAdd", Type.GetType("System.Int64")));
                    foreach (DataRow row in dt.Rows)
                        row["QuantityToAdd"] = 0;
                    dt.AcceptChanges();
                }

                dt.TableName = Sys.Enums.TableNames.tblPart.ToString();
                return new DataView(dt);
            }

            public DataView Customer_Parts_GetAll(int CustomerID)
            {
                _database.ClearParameter();
                _database.AddParameter("@CustomerID", CustomerID);
                var dt = _database.ExecuteSP_DataTable("Customer_Parts_GetAll");
                dt.TableName = Sys.Enums.TableNames.tblPart.ToString();
                return new DataView(dt);
            }

            public int Part_Exists(string Part_Code, string Supplier_Part_Code, SqlTransaction trans = null)
            {
                if (trans is null)
                {
                    // Dim PartFoundID As Integer = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteScalar("SELECT DISTINCT COALESCE (tblPart.PartID, 0) AS PartID FROM tblPart LEFT OUTER JOIN tblPartSupplier ON tblPart.PartID = tblPartSupplier.PartID WHERE (tblPartSupplier.PartCode = '" & Part_Code & "') OR (tblPart.Number = '" & Part_Code & "')", False))
                    int PartFoundID = Sys.Helper.MakeIntegerValid(_database.ExecuteScalar("SELECT DISTINCT COALESCE (tblPart.PartID, 0) AS PartID FROM tblPart LEFT OUTER JOIN tblPartSupplier ON tblPart.PartID = tblPartSupplier.PartID WHERE (tblPart.Number = '" + Part_Code + "') AND (tblPart.Deleted IS NULL OR tblPart.Deleted = 0) OR (tblPart.Reference = '" + Part_Code + "') AND (tblPart.Deleted IS NULL OR tblPart.Deleted = 0) OR (tblPartSupplier.PartCode = '" + Part_Code + "') AND (tblPart.Deleted IS NULL OR tblPart.Deleted = 0) OR (tblPart.Number = '" + Supplier_Part_Code + "') AND (tblPart.Deleted IS NULL OR tblPart.Deleted = 0) OR (tblPart.Reference = '" + Supplier_Part_Code + "') AND (tblPart.Deleted IS NULL OR tblPart.Deleted = 0) OR (tblPartSupplier.PartCode = '" + Supplier_Part_Code + "') AND (tblPart.Deleted IS NULL OR tblPart.Deleted = 0)", false));
                    return PartFoundID;
                }
                else
                {
                    // Dim PartFoundID As Integer = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteScalar("SELECT DISTINCT COALESCE (tblPart.PartID, 0) AS PartID FROM tblPart LEFT OUTER JOIN tblPartSupplier ON tblPart.PartID = tblPartSupplier.PartID WHERE (tblPartSupplier.PartCode = '" & Part_Code & "') OR (tblPart.Number = '" & Part_Code & "')", trans, False))
                    int PartFoundID = Sys.Helper.MakeIntegerValid(_database.ExecuteScalar("SELECT DISTINCT COALESCE (tblPart.PartID, 0) AS PartID FROM tblPart LEFT OUTER JOIN tblPartSupplier ON tblPart.PartID = tblPartSupplier.PartID WHERE (tblPart.Number = '" + Part_Code + "') AND (tblPart.Deleted IS NULL OR tblPart.Deleted = 0) OR (tblPart.Reference = '" + Part_Code + "') AND (tblPart.Deleted IS NULL OR tblPart.Deleted = 0) OR (tblPartSupplier.PartCode = '" + Part_Code + "') AND (tblPart.Deleted IS NULL OR tblPart.Deleted = 0) OR (tblPart.Number = '" + Supplier_Part_Code + "') AND (tblPart.Deleted IS NULL OR tblPart.Deleted = 0) OR (tblPart.Reference = '" + Supplier_Part_Code + "') AND (tblPart.Deleted IS NULL OR tblPart.Deleted = 0) OR (tblPartSupplier.PartCode = '" + Supplier_Part_Code + "') AND (tblPart.Deleted IS NULL OR tblPart.Deleted = 0)", trans, false));
                    return PartFoundID;
                }
            }

            public DataView Part_Search(string criteria, string SearchOnField)
            {
                if (SearchOnField.Trim().Length > 0)
                {
                    criteria = "'%" + criteria + "%'";
                }

                _database.ClearParameter();
                _database.AddParameter("@SearchString", criteria, true);
                _database.AddParameter("@SearchOnField", SearchOnField, true);
                var dt = _database.ExecuteSP_DataTable("Part_SearchList");
                dt.TableName = Sys.Enums.TableNames.tblPart.ToString();
                return new DataView(dt);
            }

            public int Part_Check_Stock_Level(int PartID, int LocationID)
            {
                _database.ClearParameter();
                _database.AddParameter("@PartID", PartID, true);
                _database.AddParameter("@LocationID", LocationID, true);
                return Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("Part_Check_Stock_Level"));
            }

            public int Part_Check_Stock_Level(int PartID, int LocationID, SqlTransaction trans)
            {
                var Command = new SqlCommand();
                Command.CommandText = "Part_Check_Stock_Level";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Transaction = trans;
                Command.Connection = trans.Connection;
                Command.Parameters.AddWithValue("@PartID", PartID);
                Command.Parameters.AddWithValue("@LocationID", LocationID);
                return Sys.Helper.MakeIntegerValid(Command.ExecuteScalar());
            }

            public Part Insert(Part oPart)
            {
                _database.ClearParameter();
                AddPartParametersToCommand(ref oPart);
                oPart.SetPartID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("Part_Insert"));
                oPart.Exists = true;
                return oPart;
            }

            public void Update(Part oPart)
            {
                _database.ClearParameter();
                _database.AddParameter("@PartID", oPart.PartID, true);
                AddPartParametersToCommand(ref oPart);
                _database.AddParameter("@LastChanged", DateTime.Now, true);
                _database.ExecuteSP_NO_Return("Part_Update");
            }

            private void AddPartParametersToCommand(ref Part oPart)
            {
                {
                    var withBlock = _database;
                    withBlock.AddParameter("@Name", oPart.Name, true);
                    withBlock.AddParameter("@Number", oPart.Number, true);
                    withBlock.AddParameter("@Reference", oPart.Reference, true);
                    withBlock.AddParameter("@Notes", oPart.Notes, true);
                    withBlock.AddParameter("@UnitTypeID", oPart.UnitTypeID, true);
                    withBlock.AddParameter("@SellPrice", oPart.SellPrice, true);
                    withBlock.AddParameter("@MinimumQuantity", oPart.MinimumQuantity, true);
                    withBlock.AddParameter("@RecommendedQuantity", oPart.RecommendedQuantity, true);
                    withBlock.AddParameter("@CategoryID", oPart.CategoryID, true);
                    withBlock.AddParameter("@WarehouseID", oPart.WarehouseID, true);
                    withBlock.AddParameter("@ShelfID", oPart.ShelfID, true);
                    withBlock.AddParameter("@BinID", oPart.BinID, true);
                    withBlock.AddParameter("@WarehouseIDAlternative", oPart.WarehouseIDAlternative, true);
                    withBlock.AddParameter("@ShelfIDAlternative", oPart.ShelfIDAlternative, true);
                    withBlock.AddParameter("@BinIDAlternative", oPart.BinIDAlternative, true);
                    withBlock.AddParameter("@EndFlagged", oPart.EndFlagged, true);
                    withBlock.AddParameter("@Equipment", oPart.Equipment, true);
                    withBlock.AddParameter("@FuelID", oPart.FuelID, true);
                    withBlock.AddParameter("@MakeID", oPart.MakeID, true);
                    withBlock.AddParameter("@NominalID", oPart.NominalID, true);
                }
            }

            public DataView Stock_Used()
            {
                _database.ClearParameter();
                return new DataView(_database.ExecuteSP_DataTable("Stock_Used_Report"));
            }

            public DataView Stock_Get_Locations(int PartID, int WarehouseID = 0)
            {
                _database.ClearParameter();
                _database.AddParameter("@PartID", PartID, true);
                _database.AddParameter("@ProductID", 0, true);
                _database.AddParameter("@WarehouseID", WarehouseID, true);
                var dt = _database.ExecuteSP_DataTable("Stock_Get_Locations");
                dt.TableName = Sys.Enums.TableNames.tblStock.ToString();
                return new DataView(dt);
            }

            public DataView Stock_Get_Locations(int PartID, SqlTransaction trans, int WarehouseID = 0)
            {
                var Command = new SqlCommand();
                Command.CommandText = "Stock_Get_Locations";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Transaction = trans;
                Command.Connection = trans.Connection;
                Command.Parameters.AddWithValue("@PartID", PartID);
                Command.Parameters.AddWithValue("@ProductID", 0);
                Command.Parameters.AddWithValue("@WarehouseID", WarehouseID);
                var Adapter = new SqlDataAdapter(Command);
                var returnDS = new DataSet();
                Adapter.Fill(returnDS);
                var dt = returnDS.Tables[0];
                dt.TableName = Sys.Enums.TableNames.tblStock.ToString();
                return new DataView(dt);
            }

            public DataView Part_Locations_Get(int PartID)
            {
                _database.ClearParameter();
                _database.AddParameter("@PartID", PartID, true);
                var dt = _database.ExecuteSP_DataTable("PartLocations_GetAll");
                dt.TableName = Sys.Enums.TableNames.tblPartLocations.ToString();
                return new DataView(dt);
            }

            public DataView PartLocations_GetForVan(int LocationID)
            {
                _database.ClearParameter();
                _database.AddParameter("@LocationID", LocationID, true);
                var dt = _database.ExecuteSP_DataTable("PartLocations_GetForVan");
                dt.TableName = Sys.Enums.TableNames.tblPartLocations.ToString();
                return new DataView(dt);
            }

            public DataView PartLocations_GetForVan2(int LocationID)
            {
                _database.ClearParameter();
                _database.AddParameter("@LocationID", LocationID, true);
                var dt = _database.ExecuteSP_DataTable("Part_VanProfile2");
                dt.TableName = Sys.Enums.TableNames.tblPartLocations.ToString();
                return new DataView(dt);
            }

            public int PartLocation_GetStockLevel(int LocationID, int PartID)
            {
                _database.ClearParameter();
                _database.AddParameter("@LocationID", LocationID, true);
                _database.AddParameter("@PartID", PartID, true);
                int @int = Conversions.ToInteger(_database.ExecuteSP_OBJECT("Stock_Get_ForLocationAndPart"));
                return @int;
            }

            public void Part_Locations_Update(int PartID, DataView DV)
            {
                _database.ClearParameter();
                _database.AddParameter("@PartID", PartID, true);
                _database.ExecuteSP_NO_Return("PartLocations_Delete");
                foreach (DataRow row in DV.Table.Rows)
                {
                    _database.ClearParameter();
                    _database.AddParameter("@PartID", PartID, true);
                    _database.AddParameter("@LocationID", row["LocationID"], true);
                    _database.AddParameter("@MinQty", row["MinQty"], true);
                    _database.AddParameter("@RecQty", row["RecQty"], true);
                    _database.ExecuteSP_NO_Return("PartLocations_Insert");
                }
            }

            public void Part_Locations_Insert(int PartID, int LocationID, int MinQty, int MaxQty)
            {
                _database.ClearParameter();
                _database.AddParameter("@PartID", PartID, true);
                _database.AddParameter("@LocationID", LocationID, true);
                _database.AddParameter("@MinQty", MinQty, true);
                _database.AddParameter("@RecQty", MaxQty, true);
                _database.ExecuteSP_NO_Return("PartLocations_Insert");
            }

            public void Part_Locations_Delete(int PartID, int LocationID)
            {
                _database.ClearParameter();
                _database.AddParameter("@PartID", PartID, true);
                _database.AddParameter("@LocationID", LocationID, true);
                _database.ExecuteSP_NO_Return("Part_Locations_Delete");
            }

            public DataView Part_Locations_Get_For_Replenishment(int PartID)
            {
                _database.ClearParameter();
                _database.AddParameter("@PartID", PartID, true);
                var dt = _database.ExecuteSP_DataTable("PartLocations_GetAll_For_Replenishment");
                dt.TableName = Sys.Enums.TableNames.tblLocations.ToString();
                return new DataView(dt);
            }

            public DataView Part_Locations_Get_For_Replenishment_Suppliers_Only(int PartID)
            {
                _database.ClearParameter();
                _database.AddParameter("@PartID", PartID, true);
                var dt = _database.ExecuteSP_DataTable("PartLocations_GetAll_For_Replenishment_Suppliers_Only");
                dt.TableName = Sys.Enums.TableNames.tblLocations.ToString();
                return new DataView(dt);
            }

            public DataView PartPack_GetAll()
            {
                _database.ClearParameter();
                var dt = _database.ExecuteSP_DataTable("PartPack_GetAll");
                dt.TableName = Sys.Enums.TableNames.tblLocations.ToString();
                return new DataView(dt);
            }

            public DataView PartPack_Get(int PackID)
            {
                _database.ClearParameter();
                _database.AddParameter("@PackID", PackID, true);
                var dt = _database.ExecuteSP_DataTable("PartPack_Get");
                dt.TableName = Sys.Enums.TableNames.tblLocations.ToString();
                return new DataView(dt);
            }

            public DataView PartPack_Get_Suppliers(int PackID)
            {
                _database.ClearParameter();
                _database.AddParameter("@PackID", PackID, true);
                var dt = _database.ExecuteSP_DataTable("PartPack_Get_Suppliers");
                dt.TableName = Sys.Enums.TableNames.tblLocations.ToString();
                return new DataView(dt);
            }
        }
    }
}