using System;
using System.Data;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace Assets
    {
        public class AssetSQL
        {
            private Sys.Database _database;

            public AssetSQL(Sys.Database database)
            {
                _database = database;
            }

            public void Delete(int AssetID)
            {
                _database.ClearParameter();
                _database.AddParameter("@AssetID", AssetID, true);
                _database.ExecuteSP_NO_Return("Asset_Delete");
            }

            public Asset Asset_Get(int AssetID)
            {
                _database.ClearParameter();
                _database.AddParameter("@AssetID", AssetID);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("Asset_Get");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oAsset = new Asset();
                        oAsset.IgnoreExceptionsOnSetMethods = true;
                        oAsset.SetAssetID = dt.Rows[0]["AssetID"];
                        oAsset.SetPropertyID = dt.Rows[0]["SiteID"];
                        oAsset.SetGasTypeID = Sys.Helper.MakeIntegerValid(dt.Rows[0]["GasTypeID"]);
                        oAsset.SetFlueTypeID = Sys.Helper.MakeIntegerValid(dt.Rows[0]["FlueTypeID"]);
                        oAsset.SetProductID = dt.Rows[0]["ProductID"];
                        oAsset.SetSerialNum = Sys.Helper.MakeStringValid(dt.Rows[0]["SerialNum"]);
                        if (Information.IsDBNull(dt.Rows[0]["DateFitted"]))
                        {
                            oAsset.DateFitted = DateTime.MinValue;
                        }
                        else
                        {
                            oAsset.DateFitted = Conversions.ToDate(dt.Rows[0]["DateFitted"]);
                        }

                        if (Information.IsDBNull(dt.Rows[0]["CertificateLastIssued"]))
                        {
                            oAsset.CertificateLastIssued = DateTime.MinValue;
                        }
                        else
                        {
                            oAsset.CertificateLastIssued = Conversions.ToDate(dt.Rows[0]["CertificateLastIssued"]);
                        }

                        if (Information.IsDBNull(dt.Rows[0]["LastServicedDate"]))
                        {
                            oAsset.LastServicedDate = DateTime.MinValue;
                        }
                        else
                        {
                            oAsset.LastServicedDate = Conversions.ToDate(dt.Rows[0]["LastServicedDate"]);
                        }

                        if (Information.IsDBNull(dt.Rows[0]["WarrantyStartDate"]))
                        {
                            oAsset.WarrantyStartDate = DateTime.MinValue;
                        }
                        else
                        {
                            oAsset.WarrantyStartDate = Conversions.ToDate(dt.Rows[0]["WarrantyStartDate"]);
                        }

                        if (Information.IsDBNull(dt.Rows[0]["WarrantyEndDate"]))
                        {
                            oAsset.WarrantyEndDate = DateTime.MinValue;
                        }
                        else
                        {
                            oAsset.WarrantyEndDate = Conversions.ToDate(dt.Rows[0]["WarrantyEndDate"]);
                        }

                        oAsset.SetBoughtFrom = Sys.Helper.MakeStringValid(dt.Rows[0]["BoughtFrom"]);
                        oAsset.SetSuppliedBy = Sys.Helper.MakeStringValid(dt.Rows[0]["SuppliedBy"]);
                        oAsset.SetLocation = Sys.Helper.MakeStringValid(dt.Rows[0]["Location"]);
                        oAsset.SetNotes = Sys.Helper.MakeStringValid(dt.Rows[0]["Notes"]);
                        oAsset.SetGCNumber = Sys.Helper.MakeStringValid(dt.Rows[0]["GCNumber"]);
                        oAsset.SetYearOfManufacture = Sys.Helper.MakeStringValid(dt.Rows[0]["YearOfManufacture"]);
                        oAsset.SetApproximateValue = Sys.Helper.MakeDoubleValid(dt.Rows[0]["ApproximateValue"]);
                        oAsset.SetDeleted = Conversions.ToBoolean(dt.Rows[0]["Deleted"]);
                        oAsset.SetActive = Sys.Helper.MakeBooleanValid(dt.Rows[0]["Active"]);
                        oAsset.SetTenantsAppliance = Sys.Helper.MakeBooleanValid(dt.Rows[0]["TenantsAppliance"]);
                        oAsset.Exists = true;
                        return oAsset;
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

            public DataView Asset_GetAll(int userID)
            {
                _database.ClearParameter();
                _database.AddParameter("@UserID", userID);
                var dt = _database.ExecuteSP_DataTable("Asset_GetAll_Mk1");
                dt.TableName = Sys.Enums.TableNames.tblAsset.ToString();
                return new DataView(dt);
            }

            public DataView Asset_GetForSite(int SiteID)
            {
                _database.ClearParameter();
                _database.AddParameter("@SiteID", SiteID, true);
                var dt = _database.ExecuteSP_DataTable("[Asset_GetForSite]");
                dt.TableName = Sys.Enums.TableNames.tblAsset.ToString();
                return new DataView(dt);
            }

            public DataView Asset_Search(string Criteria, int RegionID = 0)
            {
                _database.ClearParameter();
                _database.AddParameter("@SearchString", Criteria, true);
                _database.AddParameter("@RegionID", RegionID, true);
                var dt = _database.ExecuteSP_DataTable("[Asset_SearchList]");
                dt.TableName = Sys.Enums.TableNames.tblAsset.ToString();
                return new DataView(dt);
            }

            public Asset Insert(Asset oAsset)
            {
                _database.ClearParameter();
                AddAssetParametersToCommand(ref oAsset);
                oAsset.SetAssetID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("Asset_Insert"));
                oAsset.Exists = true;
                return oAsset;
            }

            public void Update(Asset oAsset)
            {
                _database.ClearParameter();
                _database.AddParameter("@AssetID", oAsset.AssetID, true);
                AddAssetParametersToCommand(ref oAsset);
                _database.ExecuteSP_NO_Return("Asset_Update");
            }

            private void AddAssetParametersToCommand(ref Asset oAsset)
            {
                {
                    var withBlock = _database;
                    withBlock.AddParameter("@SiteID", oAsset.PropertyID, true);
                    withBlock.AddParameter("@ProductID", oAsset.ProductID, true);
                    withBlock.AddParameter("@SerialNum", oAsset.SerialNum, true);
                    if (oAsset.DateFitted == DateTime.MinValue | oAsset.DateFitted == default)
                    {
                        withBlock.AddParameter("@DateFitted", DBNull.Value, true);
                    }
                    else
                    {
                        withBlock.AddParameter("@DateFitted", oAsset.DateFitted, true);
                    }

                    withBlock.AddParameter("@Location", oAsset.Location, true);
                    if (oAsset.CertificateLastIssued == DateTime.MinValue | oAsset.CertificateLastIssued == default)
                    {
                        withBlock.AddParameter("@CertificateLastIssued", DBNull.Value, true);
                    }
                    else
                    {
                        withBlock.AddParameter("@CertificateLastIssued", oAsset.CertificateLastIssued, true);
                    }

                    if (oAsset.LastServicedDate == DateTime.MinValue | oAsset.LastServicedDate == default)
                    {
                        withBlock.AddParameter("@LastServicedDate", DBNull.Value, true);
                    }
                    else
                    {
                        withBlock.AddParameter("@LastServicedDate", oAsset.LastServicedDate, true);
                    }

                    if (oAsset.WarrantyStartDate == DateTime.MinValue | oAsset.WarrantyStartDate == default)
                    {
                        withBlock.AddParameter("@WarrantyStartDate", DBNull.Value, true);
                    }
                    else
                    {
                        withBlock.AddParameter("@WarrantyStartDate", oAsset.WarrantyStartDate, true);
                    }

                    if (oAsset.WarrantyEndDate == DateTime.MinValue | oAsset.WarrantyEndDate == default)
                    {
                        withBlock.AddParameter("@WarrantyEndDate", DBNull.Value, true);
                    }
                    else
                    {
                        withBlock.AddParameter("@WarrantyEndDate", oAsset.WarrantyEndDate, true);
                    }

                    withBlock.AddParameter("@BoughtFrom", oAsset.BoughtFrom, true);
                    withBlock.AddParameter("@SuppliedBy", oAsset.SuppliedBy, true);
                    withBlock.AddParameter("@Notes", oAsset.Notes, true);
                    withBlock.AddParameter("@GCNumber", oAsset.GCNumber, true);
                    withBlock.AddParameter("@YearOfManufacture", oAsset.YearOfManufacture, true);
                    withBlock.AddParameter("@ApproximateValue", oAsset.ApproximateValue, true);
                    withBlock.AddParameter("@GasTypeID", oAsset.GasTypeID, true);
                    withBlock.AddParameter("@FlueTypeID", oAsset.FlueTypeID, true);
                    withBlock.AddParameter("@Active", oAsset.Active, true);
                    withBlock.AddParameter("@TenantsAppliance", oAsset.TenantsAppliance, true);
                }
            }
        }
    }
}