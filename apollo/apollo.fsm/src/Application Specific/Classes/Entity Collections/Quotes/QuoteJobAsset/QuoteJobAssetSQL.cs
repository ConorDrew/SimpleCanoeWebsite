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
        }
    }
}