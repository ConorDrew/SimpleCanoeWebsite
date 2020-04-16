// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Assets.AssetSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM.Entity.Assets
{
    public class AssetSQL
    {
        private Database _database;

        public AssetSQL(Database database)
        {
            this._database = database;
        }

        public void Delete(int AssetID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@AssetID", (object)AssetID, true);
            this._database.ExecuteSP_NO_Return("Asset_Delete", true);
        }

        public Asset Asset_Get(int AssetID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@AssetID", (object)AssetID, false);
            DataTable dataTable = this._database.ExecuteSP_DataTable(nameof(Asset_Get), true);
            if (dataTable == null || dataTable.Rows.Count <= 0)
                return (Asset)null;
            Asset asset1 = new Asset();
            Asset asset2 = asset1;
            asset2.IgnoreExceptionsOnSetMethods = true;
            asset2.SetAssetID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0][nameof(AssetID)]);
            asset2.SetPropertyID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SiteID"]);
            asset2.SetGasTypeID = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["GasTypeID"]));
            asset2.SetFlueTypeID = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["FlueTypeID"]));
            asset2.SetProductID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ProductID"]);
            asset2.SetSerialNum = (object)Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SerialNum"]));
            asset2.DateFitted = !Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["DateFitted"])) ? Conversions.ToDate(dataTable.Rows[0]["DateFitted"]) : DateTime.MinValue;
            asset2.CertificateLastIssued = !Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CertificateLastIssued"])) ? Conversions.ToDate(dataTable.Rows[0]["CertificateLastIssued"]) : DateTime.MinValue;
            asset2.LastServicedDate = !Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["LastServicedDate"])) ? Conversions.ToDate(dataTable.Rows[0]["LastServicedDate"]) : DateTime.MinValue;
            asset2.WarrantyStartDate = !Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["WarrantyStartDate"])) ? Conversions.ToDate(dataTable.Rows[0]["WarrantyStartDate"]) : DateTime.MinValue;
            asset2.WarrantyEndDate = !Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["WarrantyEndDate"])) ? Conversions.ToDate(dataTable.Rows[0]["WarrantyEndDate"]) : DateTime.MinValue;
            asset2.SetBoughtFrom = (object)Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["BoughtFrom"]));
            asset2.SetSuppliedBy = (object)Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SuppliedBy"]));
            asset2.SetLocation = (object)Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Location"]));
            asset2.SetNotes = (object)Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Notes"]));
            asset2.SetGCNumber = (object)Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["GCNumber"]));
            asset2.SetYearOfManufacture = (object)Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["YearOfManufacture"]));
            asset2.SetApproximateValue = (object)Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ApproximateValue"]));
            asset2.SetDeleted = Conversions.ToBoolean(dataTable.Rows[0]["Deleted"]);
            asset2.SetActive = (object)Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Active"]));
            asset2.SetTenantsAppliance = (object)Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["TenantsAppliance"]));
            asset1.Exists = true;
            return asset1;
        }

        public bool Check_Unique_Serial(string Serial, int ID)
        {
            return Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteScalar("SELECT COUNT(AssetID) as 'NumberOfAssets' FROM tblasset WHERE SerialNum = '" + Serial + "' AND AssetID <> " + Conversions.ToString(ID), false, false))) == 0;
        }

        public DataView Asset_GetAll(int userID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@UserID", (object)userID, false);
            DataTable table = this._database.ExecuteSP_DataTable("Asset_GetAll_Mk1", true);
            table.TableName = Enums.TableNames.tblAsset.ToString();
            return new DataView(table);
        }

        public DataView Asset_GetForCustomer(int CustomerID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@CustomerID", (object)CustomerID, true);
            DataTable table = this._database.ExecuteSP_DataTable("[Asset_GetForCustomer]", true);
            table.TableName = Enums.TableNames.tblAsset.ToString();
            return new DataView(table);
        }

        public DataView Asset_GetForSite(int SiteID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@SiteID", (object)SiteID, true);
            DataTable table = this._database.ExecuteSP_DataTable("[Asset_GetForSite]", true);
            table.TableName = Enums.TableNames.tblAsset.ToString();
            return new DataView(table);
        }

        public DataView Asset_Search(string Criteria, int RegionID = 0)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@SearchString", (object)Criteria, true);
            this._database.AddParameter("@RegionID", (object)RegionID, true);
            DataTable table = this._database.ExecuteSP_DataTable("[Asset_SearchList]", true);
            table.TableName = Enums.TableNames.tblAsset.ToString();
            return new DataView(table);
        }

        public Asset Insert(Asset oAsset)
        {
            this._database.ClearParameter();
            this.AddAssetParametersToCommand(ref oAsset);
            oAsset.SetAssetID = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("Asset_Insert", true)));
            oAsset.Exists = true;
            return oAsset;
        }

        public void Update(Asset oAsset)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@AssetID", (object)oAsset.AssetID, true);
            this.AddAssetParametersToCommand(ref oAsset);
            this._database.ExecuteSP_NO_Return("Asset_Update", true);
        }

        private void AddAssetParametersToCommand(ref Asset oAsset)
        {
            Database database = this._database;
            database.AddParameter("@SiteID", (object)oAsset.PropertyID, true);
            database.AddParameter("@ProductID", (object)oAsset.ProductID, true);
            database.AddParameter("@SerialNum", (object)oAsset.SerialNum, true);
            if (DateTime.Compare(oAsset.DateFitted, DateTime.MinValue) == 0 | DateTime.Compare(oAsset.DateFitted, DateTime.MinValue) == 0)
                database.AddParameter("@DateFitted", (object)DBNull.Value, true);
            else
                database.AddParameter("@DateFitted", (object)oAsset.DateFitted, true);
            database.AddParameter("@Location", (object)oAsset.Location, true);
            if (DateTime.Compare(oAsset.CertificateLastIssued, DateTime.MinValue) == 0 | DateTime.Compare(oAsset.CertificateLastIssued, DateTime.MinValue) == 0)
                database.AddParameter("@CertificateLastIssued", (object)DBNull.Value, true);
            else
                database.AddParameter("@CertificateLastIssued", (object)oAsset.CertificateLastIssued, true);
            if (DateTime.Compare(oAsset.LastServicedDate, DateTime.MinValue) == 0 | DateTime.Compare(oAsset.LastServicedDate, DateTime.MinValue) == 0)
                database.AddParameter("@LastServicedDate", (object)DBNull.Value, true);
            else
                database.AddParameter("@LastServicedDate", (object)oAsset.LastServicedDate, true);
            if (DateTime.Compare(oAsset.WarrantyStartDate, DateTime.MinValue) == 0 | DateTime.Compare(oAsset.WarrantyStartDate, DateTime.MinValue) == 0)
                database.AddParameter("@WarrantyStartDate", (object)DBNull.Value, true);
            else
                database.AddParameter("@WarrantyStartDate", (object)oAsset.WarrantyStartDate, true);
            if (DateTime.Compare(oAsset.WarrantyEndDate, DateTime.MinValue) == 0 | DateTime.Compare(oAsset.WarrantyEndDate, DateTime.MinValue) == 0)
                database.AddParameter("@WarrantyEndDate", (object)DBNull.Value, true);
            else
                database.AddParameter("@WarrantyEndDate", (object)oAsset.WarrantyEndDate, true);
            database.AddParameter("@BoughtFrom", (object)oAsset.BoughtFrom, true);
            database.AddParameter("@SuppliedBy", (object)oAsset.SuppliedBy, true);
            database.AddParameter("@Notes", (object)oAsset.Notes, true);
            database.AddParameter("@GCNumber", (object)oAsset.GCNumber, true);
            database.AddParameter("@YearOfManufacture", (object)oAsset.YearOfManufacture, true);
            database.AddParameter("@ApproximateValue", (object)oAsset.ApproximateValue, true);
            database.AddParameter("@GasTypeID", (object)oAsset.GasTypeID, true);
            database.AddParameter("@FlueTypeID", (object)oAsset.FlueTypeID, true);
            database.AddParameter("@Active", (object)oAsset.Active, true);
            database.AddParameter("@TenantsAppliance", (object)oAsset.TenantsAppliance, true);
        }
    }
}