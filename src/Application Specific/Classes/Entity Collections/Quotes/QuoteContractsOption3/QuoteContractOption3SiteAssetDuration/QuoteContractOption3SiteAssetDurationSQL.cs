using System.Data;

namespace FSM.Entity
{
    namespace QuoteContractOption3SiteAssetDurations
    {
        public class QuoteContractOption3SiteAssetDurationSQL
        {
            private Sys.Database _database;

            public QuoteContractOption3SiteAssetDurationSQL(Sys.Database database)
            {
                _database = database;
            }

            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            public DataView QuoteContractOption3SiteAssetDuration_GetAll_ForQuoteContractSiteID(int QuoteContractSiteID)
            {
                _database.ClearParameter();
                _database.AddParameter("@QuoteContractSiteID", QuoteContractSiteID);
                var dt = _database.ExecuteSP_DataTable("QuoteContractOption3SiteAssetDuration_GetAll_ForSiteID");
                dt.TableName = Sys.Enums.TableNames.tblQuoteContractOption3SiteAsset.ToString();
                return new DataView(dt);
            }

            public void QuoteContractOption3SiteAssetDuration_Delete(int QuoteContractSiteID)
            {
                _database.ClearParameter();
                _database.AddParameter("@QuoteContractSiteID", QuoteContractSiteID);
                _database.ExecuteSP_NO_Return("QuoteContractOption3SiteAssetDuration_Delete");
            }

            public QuoteContractOption3SiteAssetDuration Insert(QuoteContractOption3SiteAssetDuration oQuoteContractOption3SiteAsset)
            {
                _database.ClearParameter();
                AddQuoteContractOption3SiteAssetParametersToCommand(ref oQuoteContractOption3SiteAsset);
                oQuoteContractOption3SiteAsset.SetQuoteContractSiteAssetDurationID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("QuoteContractOption3SiteAssetDuration_Insert"));
                oQuoteContractOption3SiteAsset.Exists = true;
                return oQuoteContractOption3SiteAsset;
            }

            private void AddQuoteContractOption3SiteAssetParametersToCommand(ref QuoteContractOption3SiteAssetDuration oQuoteContractOption3SiteAsset)
            {
                {
                    var withBlock = _database;
                    withBlock.AddParameter("@QuoteContractSiteID", oQuoteContractOption3SiteAsset.QuoteContractSiteID, true);
                    withBlock.AddParameter("@AssetID", oQuoteContractOption3SiteAsset.AssetID, true);
                    withBlock.AddParameter("@ScheduledMonth", oQuoteContractOption3SiteAsset.ScheduledMonth, true);
                    withBlock.AddParameter("@VisitDuration", oQuoteContractOption3SiteAsset.VisitDuration, true);
                }
            }

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}