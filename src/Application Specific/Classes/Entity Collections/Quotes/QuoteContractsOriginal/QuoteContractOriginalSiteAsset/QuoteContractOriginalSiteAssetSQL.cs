using System.Data;

namespace FSM.Entity
{
    namespace QuoteContractOriginalSiteAssets
    {
        public class QuoteContractOriginalSiteAssetSQL
        {
            private Sys.Database _database;

            public QuoteContractOriginalSiteAssetSQL(Sys.Database database)
            {
                _database = database;
            }

            /* TODO ERROR: Skipped RegionDirectiveTrivia */

            public void Delete(int QuoteContractSiteID)
            {
                _database.ClearParameter();
                _database.AddParameter("@QuoteContractSiteID", QuoteContractSiteID, true);
                _database.ExecuteSP_NO_Return("QuoteContractOriginalSiteAsset_Delete");
            }

            public DataView QuoteContractSiteAsset_GetAll_QuoteContractSiteID(int QuoteContractSiteID, int SiteID)
            {
                _database.ClearParameter();
                _database.AddParameter("@QuoteContractSiteID", QuoteContractSiteID, true);
                _database.AddParameter("@SiteID", SiteID, true);
                var dt = _database.ExecuteSP_DataTable("QuoteContractOriginalSiteAsset_GetAll_QuoteContractSiteID");
                dt.TableName = Sys.Enums.TableNames.tblQuoteContractSiteAsset.ToString();
                return new DataView(dt);
            }

            public QuoteContractOriginalSiteAsset Insert(QuoteContractOriginalSiteAsset oQuoteContractSiteAsset)
            {
                _database.ClearParameter();
                AddQuoteContractSiteAssetParametersToCommand(ref oQuoteContractSiteAsset);
                oQuoteContractSiteAsset.SetQuoteContractSiteAssetID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("QuoteContractOriginalSiteAsset_Insert"));
                oQuoteContractSiteAsset.Exists = true;
                return oQuoteContractSiteAsset;
            }

            private void AddQuoteContractSiteAssetParametersToCommand(ref QuoteContractOriginalSiteAsset oQuoteContractSiteAsset)
            {
                {
                    var withBlock = _database;
                    withBlock.AddParameter("@QuoteContractSiteID", oQuoteContractSiteAsset.QuoteContractSiteID, true);
                    withBlock.AddParameter("@AssetID", oQuoteContractSiteAsset.AssetID, true);
                    withBlock.AddParameter("@PricePerVisit", oQuoteContractSiteAsset.PricePerVisit, true);
                }
            }


            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}