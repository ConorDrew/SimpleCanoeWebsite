using System.Data;

namespace FSM.Entity
{
    namespace ContractOption3SiteAsset
    {
        public class ContractOption3AssetSQL
        {
            private Sys.Database _database;

            public ContractOption3AssetSQL(Sys.Database database)
            {
                _database = database;
            }

            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            public DataView ContractOption3SiteAssetDuration_GetAll_ForContractSiteID(int ContractSiteID)
            {
                _database.ClearParameter();
                _database.AddParameter("@ContractSiteID", ContractSiteID);
                var dt = _database.ExecuteSP_DataTable("ContractOption3SiteAssetDuration_GetAll_ForSiteID");
                dt.TableName = Sys.Enums.TableNames.tblContractOption3SiteAsset.ToString();
                return new DataView(dt);
            }

            public void ContractOption3SiteAssetDuration_Delete(int ContractSiteID)
            {
                _database.ClearParameter();
                _database.AddParameter("@ContractSiteID", ContractSiteID);
                _database.ExecuteSP_NO_Return("ContractOption3SiteAssetDuration_Delete");
            }

            public ContractOption3SiteAsset Insert(ContractOption3SiteAsset oContractOption3SiteAsset)
            {
                _database.ClearParameter();
                AddContractOption3SiteAssetParametersToCommand(ref oContractOption3SiteAsset);
                oContractOption3SiteAsset.SetContractSiteAssetDurationID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("ContractOption3SiteAssetDuration_Insert"));
                oContractOption3SiteAsset.Exists = true;
                return oContractOption3SiteAsset;
            }

            private void AddContractOption3SiteAssetParametersToCommand(ref ContractOption3SiteAsset oContractOption3SiteAsset)
            {
                {
                    var withBlock = _database;
                    withBlock.AddParameter("@ContractSiteID", oContractOption3SiteAsset.ContractSiteID, true);
                    withBlock.AddParameter("@AssetID", oContractOption3SiteAsset.AssetID, true);
                    withBlock.AddParameter("@ScheduledMonth", oContractOption3SiteAsset.ScheduledMonth, true);
                    withBlock.AddParameter("@VisitDuration", oContractOption3SiteAsset.VisitDuration, true);
                }
            }

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}