using System.Data;

namespace FSM.Entity
{
    namespace QuoteContractAlternativeSiteAssets
    {
        public class QuoteContractAlternativeSiteAssetSQL
        {
            private Sys.Database _database;

            public QuoteContractAlternativeSiteAssetSQL(Sys.Database database)
            {
                _database = database;
            }

            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            public DataView GetAll_SiteID(int SiteID)
            {
                _database.ClearParameter();
                _database.AddParameter("@SiteID", SiteID, true);
                var dt = _database.ExecuteSP_DataTable("QuoteContractAlternativeSiteAsset_GetAll_SiteID");
                dt.TableName = Sys.Enums.TableNames.tblContractSiteAsset.ToString();
                return new DataView(dt);
            }

            public DataView GetAll_JobItemID(int QuoteContractSiteJobItemID)
            {
                _database.ClearParameter();
                _database.AddParameter("@QuoteContractSiteJobItemID", QuoteContractSiteJobItemID, true);
                var dt = _database.ExecuteSP_DataTable("QuoteContractAlternativeSiteAsset_GetAll_JobItemID");
                dt.TableName = Sys.Enums.TableNames.tblContractSiteAsset.ToString();
                return new DataView(dt);
            }

            public QuoteContractAlternativeSiteAsset Insert(QuoteContractAlternativeSiteAsset oQuoteContractSiteAsset)
            {
                _database.ClearParameter();
                AddContractSiteAssetParametersToCommand(ref oQuoteContractSiteAsset);
                oQuoteContractSiteAsset.SetQuoteContractSiteAssetID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("QuoteContractAlternativeSiteAsset_Insert"));
                oQuoteContractSiteAsset.Exists = true;
                return oQuoteContractSiteAsset;
            }

            public void Delete(int QuoteContractSiteJobItemID)
            {
                _database.ClearParameter();
                _database.AddParameter("@QuoteContractSiteJobItemID", QuoteContractSiteJobItemID, true);
                _database.ExecuteSP_NO_Return("QuoteContractAlternativeSiteAsset_Delete");
            }

            private void AddContractSiteAssetParametersToCommand(ref QuoteContractAlternativeSiteAsset oQuoteContractSiteAsset)
            {
                {
                    var withBlock = _database;
                    withBlock.AddParameter("@QuoteContractSiteJobItemID", oQuoteContractSiteAsset.QuoteContractSiteJobItemID, true);
                    withBlock.AddParameter("@AssetID", oQuoteContractSiteAsset.AssetID, true);
                }
            }

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}