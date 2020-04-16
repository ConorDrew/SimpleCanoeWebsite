// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Locationss.LocationsSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace FSM.Entity.Locationss
{
    public class LocationsSQL
    {
        private Database _database;

        public LocationsSQL(Database database)
        {
            this._database = database;
        }

        public void Delete(int LocationID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@LocationID", (object)LocationID, true);
            this._database.ExecuteSP_NO_Return("Locations_Delete", true);
        }

        public Locations Locations_Get(int LocationID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@LocationID", (object)LocationID, false);
            DataTable dataTable = this._database.ExecuteSP_DataTable(nameof(Locations_Get), true);
            if (dataTable == null || dataTable.Rows.Count <= 0)
                return (Locations)null;
            Locations locations1 = new Locations();
            Locations locations2 = locations1;
            locations2.IgnoreExceptionsOnSetMethods = true;
            locations2.SetLocationID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0][nameof(LocationID)]);
            locations2.SetVanID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["VanID"]);
            locations2.SetWarehouseID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["WarehouseID"]);
            locations2.SetDeleted = Conversions.ToBoolean(dataTable.Rows[0]["Deleted"]);
            locations1.Exists = true;
            return locations1;
        }

        public DataView Locations_GetAll()
        {
            this._database.ClearParameter();
            DataTable table = this._database.ExecuteSP_DataTable(nameof(Locations_GetAll), true);
            table.TableName = Enums.TableNames.tblLocations.ToString();
            return new DataView(table);
        }

        public DataView Locations_Get_ForVanReg(string VanReg)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@Reg", (object)VanReg, true);
            DataTable table = this._database.ExecuteSP_DataTable("Locations_Get_ForVanReg_ActiveOnly", true);
            table.TableName = Enums.TableNames.tblLocations.ToString();
            return new DataView(table);
        }

        public DataView Locations_Get_ForVanReg_ActiveOnly(string VanReg)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@Reg", (object)VanReg, true);
            DataTable table = this._database.ExecuteSP_DataTable(nameof(Locations_Get_ForVanReg_ActiveOnly), true);
            table.TableName = Enums.TableNames.tblLocations.ToString();
            return new DataView(table);
        }

        public DataView Locations_GetAll_WithNames(SqlTransaction trans)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(new SqlCommand()
            {
                CommandText = nameof(Locations_GetAll_WithNames),
                CommandType = CommandType.StoredProcedure,
                Transaction = trans,
                Connection = trans.Connection
            });
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            return new DataView(dataSet.Tables[0]);
        }

        public DataView Locations_GetAll_WithNames()
        {
            this._database.ClearParameter();
            DataTable table = this._database.ExecuteSP_DataTable(nameof(Locations_GetAll_WithNames), true);
            table.TableName = Enums.TableNames.tblLocations.ToString();
            return new DataView(table);
        }

        public DataView StockTake_GetAll(
          bool ShowOnlyWithLocation,
          int CategoryID,
          int WarehouseID,
          int VanID,
          bool ExpectedNotZero,
          bool ShowWarehousesOnly,
          bool ShowVansOnly)
        {
            this._database.ClearParameter();
            if (ShowOnlyWithLocation)
                this._database.AddParameter("@ShowOnlyWithLocation", (object)1, true);
            else
                this._database.AddParameter("@ShowOnlyWithLocation", (object)0, true);
            if (ExpectedNotZero)
                this._database.AddParameter("@ExpectedNotZero", (object)1, true);
            else
                this._database.AddParameter("@ExpectedNotZero", (object)0, true);
            this._database.AddParameter("@CategoryID", (object)CategoryID, true);
            this._database.AddParameter("@WarehouseID", (object)WarehouseID, true);
            this._database.AddParameter("@VanID", (object)VanID, true);
            if (ShowWarehousesOnly)
                this._database.AddParameter("@ShowWarehousesOnly", (object)1, true);
            else
                this._database.AddParameter("@ShowWarehousesOnly", (object)0, true);
            if (ShowVansOnly)
                this._database.AddParameter("@ShowVansOnly", (object)1, true);
            else
                this._database.AddParameter("@ShowVansOnly", (object)0, true);
            DataTable table = this._database.ExecuteSP_DataTable(nameof(StockTake_GetAll), true);
            table.TableName = Enums.TableNames.tblStock.ToString();
            return new DataView(table);
        }

        public DataView StockTake_GetAll_WithName(
          bool ShowOnlyWithLocation,
          int CategoryID,
          int WarehouseID,
          int VanID,
          bool ExpectedNotZero,
          bool ShowWarehousesOnly,
          bool ShowVansOnly,
          string MPN)
        {
            this._database.ClearParameter();
            if (ShowOnlyWithLocation)
                this._database.AddParameter("@ShowOnlyWithLocation", (object)1, true);
            else
                this._database.AddParameter("@ShowOnlyWithLocation", (object)0, true);
            if (ExpectedNotZero)
                this._database.AddParameter("@ExpectedNotZero", (object)1, true);
            else
                this._database.AddParameter("@ExpectedNotZero", (object)0, true);
            this._database.AddParameter("@CategoryID", (object)CategoryID, true);
            this._database.AddParameter("@WarehouseID", (object)WarehouseID, true);
            this._database.AddParameter("@VanID", (object)VanID, true);
            if (ShowWarehousesOnly)
                this._database.AddParameter("@ShowWarehousesOnly", (object)1, true);
            else
                this._database.AddParameter("@ShowWarehousesOnly", (object)0, true);
            if (ShowVansOnly)
                this._database.AddParameter("@ShowVansOnly", (object)1, true);
            else
                this._database.AddParameter("@ShowVansOnly", (object)0, true);
            this._database.AddParameter("@MPN", (object)MPN, true);
            DataTable table = this._database.ExecuteSP_DataTable("StockTake_GetAll_PartName", true);
            table.TableName = Enums.TableNames.tblStock.ToString();
            return new DataView(table);
        }

        public DataView StockTake_Replenishment_Filtered(
          string Location,
          string Item,
          bool IncludeVans,
          bool LessMin,
          bool LessRec)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@Location", (object)Location, true);
            this._database.AddParameter("@Item", (object)Item, true);
            this._database.AddParameter("@IncludeVans", (object)IncludeVans, true);
            this._database.AddParameter("@LessMin", (object)LessMin, true);
            this._database.AddParameter("@LessRec", (object)LessRec, true);
            DataTable table = this._database.ExecuteSP_DataTable(nameof(StockTake_Replenishment_Filtered), true);
            table.TableName = Enums.TableNames.tblStock.ToString();
            return new DataView(table);
        }

        public DataView StockTake_Replenishment_Filtered_OvernightSP()
        {
            this._database.ClearParameter();
            this._database.AddParameter("@Location", (object)"", true);
            this._database.AddParameter("@Item", (object)"", true);
            this._database.AddParameter("@IncludeVans", (object)true, true);
            this._database.AddParameter("@LessMin", (object)true, true);
            this._database.AddParameter("@LessRec", (object)true, true);
            DataTable table = this._database.ExecuteSP_DataTable("StockTake_Replenishment_OvernightSP_VansOnly", true);
            table.TableName = Enums.TableNames.tblStock.ToString();
            return new DataView(table);
        }

        public DataView StockTake_Replenishment_Daily_Filtered(int FilterType = 0, int VanID = 0)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@FilterType", (object)FilterType, true);
            this._database.AddParameter("@VanID", (object)VanID, true);
            DataTable table = FilterType != 0 ? this._database.ExecuteSP_DataTable("StockTake_Replenishment_Daily_FilterResults", true) : this._database.ExecuteSP_DataTable("StockTake_Replenishment_Daily_FilterResults_ALL", true);
            table.TableName = Enums.TableNames.tblStock.ToString();
            return new DataView(table);
        }

        public DataView StockTake_Replenishment_UpdateExclude(int ItemID, bool Exclude)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@ItemID", (object)ItemID, true);
            this._database.AddParameter("@Exclude", (object)Exclude, true);
            this._database.ExecuteSP_NO_Return("StockTake_Replenishment_Daily_UpdateExclude", true);
            DataView dataView = null;
            return dataView;
        }

        public DataView StockTake_Replenishment_UpdateAmountToOrder(
          int ItemID,
          int AmountToOrder)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@ItemID", (object)ItemID, true);
            this._database.AddParameter("@AmountToOrder", (object)AmountToOrder, true);
            this._database.ExecuteSP_NO_Return("StockTake_Replenishment_Daily_UpdateAmountToOrder", true);
            DataView dataView = null;
            return dataView;
        }

        public DataView StockTake_Replenishment_Daily_UpdateFilterType(
          int ItemID,
          int FilterType)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@ItemID", (object)ItemID, true);
            this._database.AddParameter("@FilterType", (object)FilterType, true);
            this._database.ExecuteSP_NO_Return(nameof(StockTake_Replenishment_Daily_UpdateFilterType), true);
            DataView dataView = null;
            return dataView;
        }

        public DataView StockTake_Replenishment_Daily_UpdateSupplier(
          int ItemID,
          int PartSupplierID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@ItemID", (object)ItemID, true);
            this._database.AddParameter("@PartSupplierID", (object)PartSupplierID, true);
            this._database.ExecuteSP_NO_Return(nameof(StockTake_Replenishment_Daily_UpdateSupplier), true);
            DataView dataView = null;
            return dataView;
        }

        public DataView StockTakeReason_Get()
        {
            this._database.ClearParameter();
            DataTable table = this._database.ExecuteSP_DataTable("StockReason_GetAll", true);
            table.TableName = Enums.TableNames.tblStock.ToString();
            return new DataView(table);
        }

        public Locations Insert(Locations oLocations)
        {
            this._database.ClearParameter();
            this.AddLocationsParametersToCommand(ref oLocations);
            oLocations.SetLocationID = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("Locations_Insert", true)));
            oLocations.Exists = true;
            return oLocations;
        }

        public void Update(int LocationID, bool Deleted)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@LocationID", (object)LocationID, true);
            if (Deleted)
                this._database.AddParameter("@Deleted", (object)1, true);
            else
                this._database.AddParameter("@Deleted", (object)0, true);
            this._database.ExecuteSP_NO_Return("Locations_Update", true);
        }

        private void AddLocationsParametersToCommand(ref Locations oLocations)
        {
            Database database = this._database;
            if (oLocations.VanID == 0)
                database.AddParameter("@VanID", (object)DBNull.Value, true);
            else
                database.AddParameter("@VanID", (object)oLocations.VanID, true);
            if (oLocations.WarehouseID == 0)
                database.AddParameter("@WarehouseID", (object)DBNull.Value, true);
            else
                database.AddParameter("@WarehouseID", (object)oLocations.WarehouseID, true);
        }

        public void IPT_Audit_Insert(
          int PartID,
          int ProductID,
          int FromLocationID,
          int ToLocationID,
          int Quantity)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@PartID", (object)PartID, true);
            this._database.AddParameter("@ProductID", (object)ProductID, true);
            this._database.AddParameter("@FromLocationID", (object)FromLocationID, true);
            this._database.AddParameter("@ToLocationID", (object)ToLocationID, true);
            this._database.AddParameter("@Quantity", (object)Quantity, true);
            this._database.AddParameter("@MovedByUserID", (object)App.loggedInUser.UserID, true);
            this._database.ExecuteSP_NO_Return(nameof(IPT_Audit_Insert), true);
        }

        public DataView IPT_Audit_Get(
          string Type,
          string Name,
          string Number,
          string Reference,
          int FromLocationID,
          int ToLocationID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@Type", (object)Type, true);
            this._database.AddParameter("@Name", (object)Name, true);
            this._database.AddParameter("@Number", (object)Number, true);
            this._database.AddParameter("@Reference", (object)Reference, true);
            this._database.AddParameter("@FromLocationID", (object)FromLocationID, true);
            this._database.AddParameter("@ToLocationID", (object)ToLocationID, true);
            DataTable table = this._database.ExecuteSP_DataTable(nameof(IPT_Audit_Get), true);
            table.TableName = Enums.TableNames.tblIPTAudit.ToString();
            return new DataView(table);
        }
    }
}