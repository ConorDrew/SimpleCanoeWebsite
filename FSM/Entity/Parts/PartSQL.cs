// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Parts.PartSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace FSM.Entity.Parts
{
    public class PartSQL
    {
        private Database _database;

        public PartSQL(Database database)
        {
            this._database = database;
        }

        public void Delete(int PartID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@PartID", (object)PartID, true);
            this._database.ExecuteSP_NO_Return("Part_Delete", true);
        }

        public Part Part_Get(int PartID, SqlTransaction trans)
        {
            SqlCommand selectCommand = new SqlCommand();
            selectCommand.CommandText = nameof(Part_Get);
            selectCommand.CommandType = CommandType.StoredProcedure;
            selectCommand.Transaction = trans;
            selectCommand.Connection = trans.Connection;
            selectCommand.Parameters.AddWithValue("@PartID", (object)PartID);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            DataTable table = dataSet.Tables[0];
            if (table == null || table.Rows.Count <= 0)
                return (Part)null;
            Part part1 = new Part();
            Part part2 = part1;
            part2.IgnoreExceptionsOnSetMethods = true;
            part2.SetPartID = RuntimeHelpers.GetObjectValue(table.Rows[0][nameof(PartID)]);
            part2.SetName = (object)Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(table.Rows[0]["Name"]));
            part2.SetNumber = (object)Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(table.Rows[0]["Number"]));
            part2.SetReference = (object)Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(table.Rows[0]["Reference"]));
            part2.SetNotes = (object)Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(table.Rows[0]["Notes"]));
            part2.SetUnitTypeID = RuntimeHelpers.GetObjectValue(table.Rows[0]["UnitTypeID"]);
            part2.SetDeleted = Conversions.ToBoolean(table.Rows[0]["Deleted"]);
            part2.SetSellPrice = RuntimeHelpers.GetObjectValue(table.Rows[0]["SellPrice"]);
            part2.SetMinimumQuantity = RuntimeHelpers.GetObjectValue(table.Rows[0]["MinimumQuantity"]);
            part2.SetRecommendedQuantity = RuntimeHelpers.GetObjectValue(table.Rows[0]["RecommendedQuantity"]);
            part2.SetCategoryID = RuntimeHelpers.GetObjectValue(table.Rows[0]["CategoryID"]);
            part2.SetWarehouseID = RuntimeHelpers.GetObjectValue(table.Rows[0]["WarehouseID"]);
            part2.SetShelfID = RuntimeHelpers.GetObjectValue(table.Rows[0]["ShelfID"]);
            part2.SetBinID = RuntimeHelpers.GetObjectValue(table.Rows[0]["BinID"]);
            part2.SetWarehouseQuantity = RuntimeHelpers.GetObjectValue(table.Rows[0]["WarehouseQuantity"]);
            part2.SetWarehouseIDAlternative = RuntimeHelpers.GetObjectValue(table.Rows[0]["WarehouseIDAlternative"]);
            part2.SetShelfIDAlternative = RuntimeHelpers.GetObjectValue(table.Rows[0]["ShelfIDAlternative"]);
            part2.SetBinIDAlternative = RuntimeHelpers.GetObjectValue(table.Rows[0]["BinIDAlternative"]);
            part2.SetEndFlagged = Conversions.ToBoolean(table.Rows[0]["EndFlagged"]);
            part2.SetEquipment = Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(table.Rows[0]["Equipment"]));
            part2.SetFuelID = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(table.Rows[0]["FuelID"]));
            part2.SetMakeID = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(table.Rows[0]["MakeID"]));
            part1.Exists = true;
            return part1;
        }

        public Part Part_Get(int PartID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@PartID", (object)PartID, false);
            DataTable dataTable = this._database.ExecuteSP_DataTable(nameof(Part_Get), true);
            if (dataTable == null || dataTable.Rows.Count <= 0)
                return (Part)null;
            Part part1 = new Part();
            Part part2 = part1;
            part2.IgnoreExceptionsOnSetMethods = true;
            part2.SetPartID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0][nameof(PartID)]);
            part2.SetName = (object)Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Name"]));
            part2.SetNumber = (object)Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Number"]));
            part2.SetReference = (object)Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Reference"]));
            part2.SetNotes = (object)Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Notes"]));
            part2.SetUnitTypeID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["UnitTypeID"]);
            part2.SetDeleted = Conversions.ToBoolean(dataTable.Rows[0]["Deleted"]);
            part2.SetSellPrice = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SellPrice"]);
            part2.SetMinimumQuantity = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["MinimumQuantity"]);
            part2.SetRecommendedQuantity = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["RecommendedQuantity"]);
            part2.SetCategoryID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CategoryID"]);
            part2.SetWarehouseID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["WarehouseID"]);
            part2.SetShelfID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ShelfID"]);
            part2.SetBinID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["BinID"]);
            part2.SetWarehouseQuantity = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["WarehouseQuantity"]);
            part2.SetWarehouseIDAlternative = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["WarehouseIDAlternative"]);
            part2.SetShelfIDAlternative = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ShelfIDAlternative"]);
            part2.SetBinIDAlternative = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["BinIDAlternative"]);
            part2.SetEndFlagged = Conversions.ToBoolean(dataTable.Rows[0]["EndFlagged"]);
            part2.SetEquipment = Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Equipment"]));
            part2.SetFuelID = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["FuelID"]));
            part2.SetMakeID = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["MakeID"]));
            part2.SetIsSpecialPart = Conversions.ToBoolean(dataTable.Rows[0]["IsSpecialPart"]);
            part1.Exists = true;
            return part1;
        }

        public Part Part_Get_For_Code_And_Supplier(string Code, int SupplierID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@PartID", (object)Code, false);
            this._database.AddParameter("@SupplierID", (object)SupplierID, false);
            DataTable dataTable = this._database.ExecuteSP_DataTable("PartSupplier_GetByPartCodeAndSupplier", true);
            if (dataTable == null || dataTable.Rows.Count <= 0)
                return (Part)null;
            Part part1 = new Part();
            Part part2 = part1;
            part2.IgnoreExceptionsOnSetMethods = true;
            part2.SetPartID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["PartID"]);
            part2.SetName = (object)Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Name"]));
            part2.SetNumber = (object)Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Number"]));
            part2.SetSPartID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["PartSupplierID"]);
            part1.Exists = true;
            return part1;
        }

        public bool Check_Unique_Number(string Number, int ID)
        {
            return Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteScalar("SELECT COUNT(PartID) as 'NumberOfParts' FROM tblpart WHERE Deleted = 0 AND Number = '" + Number + "' AND partid <> " + Conversions.ToString(ID), false, false))) == 0;
        }

        public bool Check_Unique_Bin(int BinID, int ID, string ColumnName)
        {
            return Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteScalar("SELECT COUNT(PartID) as 'NumberOfParts' FROM tblpart WHERE " + ColumnName + " = " + Conversions.ToString(BinID) + " AND partid <> " + Conversions.ToString(ID), false, false))) == 0;
        }

        public DataView Part_GetAll(SqlTransaction trans)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(new SqlCommand()
            {
                CommandText = nameof(Part_GetAll),
                CommandType = CommandType.StoredProcedure,
                Transaction = trans,
                Connection = trans.Connection
            });
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            DataTable table = dataSet.Tables[0];
            table.TableName = Enums.TableNames.tblPart.ToString();
            return new DataView(table);
        }

        public DataView Part_GetAll(bool ForMassPartEntry = false)
        {
            this._database.ClearParameter();
            DataTable table = this._database.ExecuteSP_DataTable(nameof(Part_GetAll), true);
            if (ForMassPartEntry)
            {
                table.AcceptChanges();
                table.Columns.Add(new DataColumn("QuantityToAdd", Type.GetType("System.Int64")));

                foreach (DataRow current in table.Rows)
                {
                    current["QuantityToAdd"] = (object)0;
                }

                table.AcceptChanges();
            }
            table.TableName = Enums.TableNames.tblPart.ToString();
            return new DataView(table);
        }

        public DataView Customer_Parts_GetAll(int CustomerID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@CustomerID", (object)CustomerID, false);
            DataTable table = this._database.ExecuteSP_DataTable(nameof(Customer_Parts_GetAll), true);
            table.TableName = Enums.TableNames.tblPart.ToString();
            return new DataView(table);
        }

        public int Part_Exists(string Part_Code, string Supplier_Part_Code, SqlTransaction trans = null)
        {
            return trans == null ? Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteScalar("SELECT DISTINCT COALESCE (tblPart.PartID, 0) AS PartID FROM tblPart LEFT OUTER JOIN tblPartSupplier ON tblPart.PartID = tblPartSupplier.PartID WHERE (tblPart.Number = '" + Part_Code + "') AND (tblPart.Deleted IS NULL OR tblPart.Deleted = 0) OR (tblPart.Reference = '" + Part_Code + "') AND (tblPart.Deleted IS NULL OR tblPart.Deleted = 0) OR (tblPartSupplier.PartCode = '" + Part_Code + "') AND (tblPart.Deleted IS NULL OR tblPart.Deleted = 0) OR (tblPart.Number = '" + Supplier_Part_Code + "') AND (tblPart.Deleted IS NULL OR tblPart.Deleted = 0) OR (tblPart.Reference = '" + Supplier_Part_Code + "') AND (tblPart.Deleted IS NULL OR tblPart.Deleted = 0) OR (tblPartSupplier.PartCode = '" + Supplier_Part_Code + "') AND (tblPart.Deleted IS NULL OR tblPart.Deleted = 0)", false, false))) : Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteScalar("SELECT DISTINCT COALESCE (tblPart.PartID, 0) AS PartID FROM tblPart LEFT OUTER JOIN tblPartSupplier ON tblPart.PartID = tblPartSupplier.PartID WHERE (tblPart.Number = '" + Part_Code + "') AND (tblPart.Deleted IS NULL OR tblPart.Deleted = 0) OR (tblPart.Reference = '" + Part_Code + "') AND (tblPart.Deleted IS NULL OR tblPart.Deleted = 0) OR (tblPartSupplier.PartCode = '" + Part_Code + "') AND (tblPart.Deleted IS NULL OR tblPart.Deleted = 0) OR (tblPart.Number = '" + Supplier_Part_Code + "') AND (tblPart.Deleted IS NULL OR tblPart.Deleted = 0) OR (tblPart.Reference = '" + Supplier_Part_Code + "') AND (tblPart.Deleted IS NULL OR tblPart.Deleted = 0) OR (tblPartSupplier.PartCode = '" + Supplier_Part_Code + "') AND (tblPart.Deleted IS NULL OR tblPart.Deleted = 0)", trans, false)));
        }

        public DataView Part_Search(string criteria, string SearchOnField)
        {
            if (SearchOnField.Trim().Length > 0)
                criteria = "'%" + criteria + "%'";
            this._database.ClearParameter();
            this._database.AddParameter("@SearchString", (object)criteria, true);
            this._database.AddParameter("@SearchOnField", (object)SearchOnField, true);
            DataTable table = this._database.ExecuteSP_DataTable("Part_SearchList", true);
            table.TableName = Enums.TableNames.tblPart.ToString();
            return new DataView(table);
        }

        public int Part_Check_Stock_Level(int PartID, int LocationID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@PartID", (object)PartID, true);
            this._database.AddParameter("@LocationID", (object)LocationID, true);
            return Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT(nameof(Part_Check_Stock_Level), true)));
        }

        public int Part_Check_Stock_Level(int PartID, int LocationID, SqlTransaction trans)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = nameof(Part_Check_Stock_Level);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Transaction = trans;
            sqlCommand.Connection = trans.Connection;
            sqlCommand.Parameters.AddWithValue("@PartID", (object)PartID);
            sqlCommand.Parameters.AddWithValue("@LocationID", (object)LocationID);
            return Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(sqlCommand.ExecuteScalar()));
        }

        public Part Insert(Part oPart)
        {
            this._database.ClearParameter();
            this.AddPartParametersToCommand(ref oPart);
            oPart.SetPartID = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("Part_Insert", true)));
            oPart.Exists = true;
            return oPart;
        }

        public void Update(Part oPart)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@PartID", (object)oPart.PartID, true);
            this.AddPartParametersToCommand(ref oPart);
            this._database.AddParameter("@LastChanged", (object)DateTime.Now, true);
            this._database.ExecuteSP_NO_Return("Part_Update", true);
        }

        private void AddPartParametersToCommand(ref Part oPart)
        {
            Database database = this._database;
            database.AddParameter("@Name", (object)oPart.Name, true);
            database.AddParameter("@Number", (object)oPart.Number, true);
            database.AddParameter("@Reference", (object)oPart.Reference, true);
            database.AddParameter("@Notes", (object)oPart.Notes, true);
            database.AddParameter("@UnitTypeID", (object)oPart.UnitTypeID, true);
            database.AddParameter("@SellPrice", (object)oPart.SellPrice, true);
            database.AddParameter("@MinimumQuantity", (object)oPart.MinimumQuantity, true);
            database.AddParameter("@RecommendedQuantity", (object)oPart.RecommendedQuantity, true);
            database.AddParameter("@CategoryID", (object)oPart.CategoryID, true);
            database.AddParameter("@WarehouseID", (object)oPart.WarehouseID, true);
            database.AddParameter("@ShelfID", (object)oPart.ShelfID, true);
            database.AddParameter("@BinID", (object)oPart.BinID, true);
            database.AddParameter("@WarehouseIDAlternative", (object)oPart.WarehouseIDAlternative, true);
            database.AddParameter("@ShelfIDAlternative", (object)oPart.ShelfIDAlternative, true);
            database.AddParameter("@BinIDAlternative", (object)oPart.BinIDAlternative, true);
            database.AddParameter("@EndFlagged", (object)oPart.EndFlagged, true);
            database.AddParameter("@Equipment", (object)oPart.Equipment, true);
            database.AddParameter("@FuelID", (object)oPart.FuelID, true);
            database.AddParameter("@MakeID", (object)oPart.MakeID, true);
        }

        public DataSet Stock_Valuation(
          int CategoryID,
          int WarehouseID,
          int VanID,
          string FilterString,
          bool ExactMatch)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@CategoryID", (object)CategoryID, true);
            this._database.AddParameter("@WarehouseID", (object)WarehouseID, true);
            this._database.AddParameter("@VanID", (object)VanID, true);
            this._database.AddParameter("@FilterString", (object)FilterString, true);
            if (ExactMatch)
                this._database.AddParameter("@ExactMatch", (object)"Y", true);
            else
                this._database.AddParameter("@ExactMatch", (object)"N", true);
            this._database.AddParameter("@PartsToBeCreditedStatus_Awaiting", (object)1, true);
            this._database.AddParameter("@OrderType_Van", (object)2, true);
            this._database.AddParameter("@DownloadedVisitStatus", (object)6, true);
            return this._database.ExecuteSP_DataSet("Stock_Valuation_Report", true);
        }

        public DataView Stock_Used()
        {
            this._database.ClearParameter();
            return new DataView(this._database.ExecuteSP_DataTable("Stock_Used_Report", true));
        }

        public DataView Stock_Get_Locations(int PartID, int WarehouseID = 0)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@PartID", (object)PartID, true);
            this._database.AddParameter("@ProductID", (object)0, true);
            this._database.AddParameter("@WarehouseID", (object)WarehouseID, true);
            DataTable table = this._database.ExecuteSP_DataTable(nameof(Stock_Get_Locations), true);
            table.TableName = Enums.TableNames.tblStock.ToString();
            return new DataView(table);
        }

        public DataView Stock_Get_Locations(int PartID, SqlTransaction trans, int WarehouseID = 0)
        {
            SqlCommand selectCommand = new SqlCommand();
            selectCommand.CommandText = nameof(Stock_Get_Locations);
            selectCommand.CommandType = CommandType.StoredProcedure;
            selectCommand.Transaction = trans;
            selectCommand.Connection = trans.Connection;
            selectCommand.Parameters.AddWithValue("@PartID", (object)PartID);
            selectCommand.Parameters.AddWithValue("@ProductID", (object)0);
            selectCommand.Parameters.AddWithValue("@WarehouseID", (object)WarehouseID);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            DataTable table = dataSet.Tables[0];
            table.TableName = Enums.TableNames.tblStock.ToString();
            return new DataView(table);
        }

        public DataView Stock_Quantities()
        {
            this._database.ClearParameter();
            return new DataView(this._database.ExecuteSP_DataTable(nameof(Stock_Quantities), true));
        }

        public DataView Part_Locations_Get(int PartID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@PartID", (object)PartID, true);
            DataTable table = this._database.ExecuteSP_DataTable("PartLocations_GetAll", true);
            table.TableName = Enums.TableNames.tblPartLocations.ToString();
            return new DataView(table);
        }

        public DataView PartLocations_GetForVanHM(int LocationID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@LocationID", (object)LocationID, true);
            DataTable table = this._database.ExecuteSP_DataTable(nameof(PartLocations_GetForVanHM), true);
            table.TableName = Enums.TableNames.tblPartLocations.ToString();
            return new DataView(table);
        }

        public DataView PartLocations_GetForVan(int LocationID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@LocationID", (object)LocationID, true);
            DataTable table = this._database.ExecuteSP_DataTable(nameof(PartLocations_GetForVan), true);
            table.TableName = Enums.TableNames.tblPartLocations.ToString();
            return new DataView(table);
        }

        public DataView PartLocations_GetForVan2(int LocationID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@LocationID", (object)LocationID, true);
            DataTable table = this._database.ExecuteSP_DataTable("Part_VanProfile2", true);
            table.TableName = Enums.TableNames.tblPartLocations.ToString();
            return new DataView(table);
        }

        public int PartLocation_GetStockLevel(int LocationID, int PartID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@LocationID", (object)LocationID, true);
            this._database.AddParameter("@PartID", (object)PartID, true);
            return Conversions.ToInteger(this._database.ExecuteSP_OBJECT("Stock_Get_ForLocationAndPart", true));
        }

        public void Part_Locations_Update(int PartID, DataView DV)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@PartID", (object)PartID, true);
            this._database.ExecuteSP_NO_Return("PartLocations_Delete", true);

            foreach (DataRow current in DV.Table.Rows)
            {
                this._database.ClearParameter();
                this._database.AddParameter("@PartID", (object)PartID, true);
                this._database.AddParameter("@LocationID", RuntimeHelpers.GetObjectValue(current["LocationID"]), true);
                this._database.AddParameter("@MinQty", RuntimeHelpers.GetObjectValue(current["MinQty"]), true);
                this._database.AddParameter("@RecQty", RuntimeHelpers.GetObjectValue(current["RecQty"]), true);
                this._database.ExecuteSP_NO_Return("PartLocations_Insert", true);
            }
        }

        public void Part_Locations_Insert(int PartID, int LocationID, int MinQty, int MaxQty)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@PartID", (object)PartID, true);
            this._database.AddParameter("@LocationID", (object)LocationID, true);
            this._database.AddParameter("@MinQty", (object)MinQty, true);
            this._database.AddParameter("@RecQty", (object)MaxQty, true);
            this._database.ExecuteSP_NO_Return("PartLocations_Insert", true);
        }

        public void Part_Locations_Delete(int PartID, int LocationID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@PartID", (object)PartID, true);
            this._database.AddParameter("@LocationID", (object)LocationID, true);
            this._database.ExecuteSP_NO_Return(nameof(Part_Locations_Delete), true);
        }

        public DataView Part_Locations_Get_For_Replenishment(int PartID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@PartID", (object)PartID, true);
            DataTable table = this._database.ExecuteSP_DataTable("PartLocations_GetAll_For_Replenishment", true);
            table.TableName = Enums.TableNames.tblLocations.ToString();
            return new DataView(table);
        }

        public DataView Part_Locations_Get_For_Replenishment_Suppliers_Only(int PartID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@PartID", (object)PartID, true);
            DataTable table = this._database.ExecuteSP_DataTable("PartLocations_GetAll_For_Replenishment_Suppliers_Only", true);
            table.TableName = Enums.TableNames.tblLocations.ToString();
            return new DataView(table);
        }

        public DataView PartPack_GetAll()
        {
            this._database.ClearParameter();
            DataTable table = this._database.ExecuteSP_DataTable(nameof(PartPack_GetAll), true);
            table.TableName = Enums.TableNames.tblLocations.ToString();
            return new DataView(table);
        }

        public DataView PartPack_Get(int PackID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@PackID", (object)PackID, true);
            DataTable table = this._database.ExecuteSP_DataTable(nameof(PartPack_Get), true);
            table.TableName = Enums.TableNames.tblLocations.ToString();
            return new DataView(table);
        }

        public DataView PartPack_Get_Suppliers(int PackID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@PackID", (object)PackID, true);
            DataTable table = this._database.ExecuteSP_DataTable(nameof(PartPack_Get_Suppliers), true);
            table.TableName = Enums.TableNames.tblLocations.ToString();
            return new DataView(table);
        }
    }
}