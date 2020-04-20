using System.Data;

namespace FSM.Entity
{
    namespace ContractOriginalSiteAssets
    {
        public class ContractOriginalSiteAssetSQL
        {
            private Sys.Database _database;

            public ContractOriginalSiteAssetSQL(Sys.Database database)
            {
                _database = database;
            }

            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            public DataView GetAll_ContractSiteID(int ContractSiteID, int SiteID)
            {
                _database.ClearParameter();
                _database.AddParameter("@ContractSiteID", ContractSiteID, true);
                _database.AddParameter("@SiteID", SiteID, true);
                var dt = _database.ExecuteSP_DataTable("ContractOriginalSiteAsset_GetAll_ContractSiteID");
                dt.TableName = Sys.Enums.TableNames.tblContractSiteAsset.ToString();
                return new DataView(dt);
            }

            public ContractOriginalSiteAsset Insert(ContractOriginalSiteAsset oContractSiteAsset)
            {
                _database.ClearParameter();
                AddContractSiteAssetParametersToCommand(ref oContractSiteAsset);
                oContractSiteAsset.SetContractSiteAssetID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("ContractOriginalSiteAsset_Insert"));
                oContractSiteAsset.Exists = true;
                return oContractSiteAsset;
            }

            public void Delete(int ContractSiteID)
            {
                _database.ClearParameter();
                _database.AddParameter("@ContractSiteID", ContractSiteID, true);
                _database.ExecuteSP_NO_Return("ContractOriginalSiteAsset_Delete");
            }

            private void AddContractSiteAssetParametersToCommand(ref ContractOriginalSiteAsset oContractSiteAsset)
            {
                {
                    var withBlock = _database;
                    withBlock.AddParameter("@ContractSiteID", oContractSiteAsset.ContractSiteID, true);
                    withBlock.AddParameter("@AssetID", oContractSiteAsset.AssetID, true);
                    withBlock.AddParameter("@PricePerVisit", oContractSiteAsset.PricePerVisit, true);
                    withBlock.AddParameter("@PrimaryAsset", oContractSiteAsset.PrimaryAsset, true);
                    withBlock.AddParameter("@Type", oContractSiteAsset.Type, true);
                    withBlock.AddParameter("@Product", oContractSiteAsset.Product, true);
                }
            }

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}