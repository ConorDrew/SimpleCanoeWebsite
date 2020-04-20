using System.Collections;
using System.Data;

namespace FSM.Entity
{
    namespace QuoteJobAssets
    {
        public class QuoteJobAssetSQL
        {
            private Sys.Database _database;

            public QuoteJobAssetSQL(Sys.Database database)
            {
                _database = database;
            }

            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            public QuoteJobAsset Insert(QuoteJobAsset qJobAsset)
            {
                _database.ClearParameter();
                _database.AddParameter("@QuoteJobID", qJobAsset.QuoteJobID, true);
                _database.AddParameter("@AssetID", qJobAsset.AssetID, true);
                qJobAsset.SetQuoteJobAssetID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("QuoteJobAsset_Insert"));
                return qJobAsset;
            }

            public void Delete(int QuoteJobID)
            {
                _database.ClearParameter();
                _database.AddParameter("@QuoteJobID", QuoteJobID, true);
                _database.ExecuteSP_OBJECT("QuoteJobAsset_Delete");
            }

            public DataView QuoteJobAsset_Get_For_QuoteJob(int QuoteJobID)
            {
                _database.ClearParameter();
                _database.AddParameter("@QuoteJobID", QuoteJobID, true);
                var dt = _database.ExecuteSP_DataTable("QuoteJobAsset_Get_For_QuoteJob");
                dt.TableName = Sys.Enums.TableNames.tblQuoteJobAssets.ToString();
                return new DataView(dt);
            }

            public ArrayList QuoteJobAsset_Get_For_QuoteJob_As_Objects(int QuoteJobID)
            {
                var assets = new ArrayList();
                foreach (DataRow row in QuoteJobAsset_Get_For_QuoteJob(QuoteJobID).Table.Rows)
                {
                    var asset = new QuoteJobAsset();
                    asset.IgnoreExceptionsOnSetMethods = true;
                    asset.SetQuoteJobAssetID = row["QuoteJobAssetID"];
                    asset.SetQuoteJobID = row["QuoteJobID"];
                    asset.SetAssetID = row["AssetID"];
                    assets.Add(asset);
                }

                return assets;
            }


            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}