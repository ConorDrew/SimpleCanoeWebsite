using System.Data;

namespace FSM.Entity
{
    namespace ContractAlternativeSiteAssets
    {
        public class ContractAlternativeSiteAssetSQL
        {
            private Sys.Database _database;

            public ContractAlternativeSiteAssetSQL(Sys.Database database)
            {
                _database = database;
            }

            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            public DataView GetAll_SiteID(int SiteID)
            {
                _database.ClearParameter();
                _database.AddParameter("@SiteID", SiteID, true);
                var dt = _database.ExecuteSP_DataTable("ContractAlternativeSiteAsset_GetAll_SiteID");
                dt.TableName = Sys.Enums.TableNames.tblContractSiteAsset.ToString();
                return new DataView(dt);
            }

            public DataView GetAll_JobItemID(int ContractSiteJobItemID)
            {
                _database.ClearParameter();
                _database.AddParameter("@ContractSiteJobItemID", ContractSiteJobItemID, true);
                var dt = _database.ExecuteSP_DataTable("ContractAlternativeSiteAsset_GetAll_JobItemID");
                dt.TableName = Sys.Enums.TableNames.tblContractSiteAsset.ToString();
                return new DataView(dt);
            }

            public ContractAlternativeSiteAsset Insert(ContractAlternativeSiteAsset oContractSiteAsset)
            {
                _database.ClearParameter();
                AddContractSiteAssetParametersToCommand(ref oContractSiteAsset);
                oContractSiteAsset.SetContractSiteAssetID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("ContractAlternativeSiteAsset_Insert"));
                oContractSiteAsset.Exists = true;
                return oContractSiteAsset;
            }

            public void Delete(int ContractSiteJobItemID)
            {
                _database.ClearParameter();
                _database.AddParameter("@ContractSiteJobItemID", ContractSiteJobItemID, true);
                _database.ExecuteSP_NO_Return("ContractAlternativeSiteAsset_Delete");
            }

            private void AddContractSiteAssetParametersToCommand(ref ContractAlternativeSiteAsset oContractSiteAsset)
            {
                {
                    var withBlock = _database;
                    withBlock.AddParameter("@ContractSiteJobItemID", oContractSiteAsset.ContractSiteJobItemID, true);
                    withBlock.AddParameter("@AssetID", oContractSiteAsset.AssetID, true);
                }
            }

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}