using System.Data;

namespace FSM.Entity
{
    namespace Quotes
    {
        public class QuotesSQL
        {
            private Sys.Database _database;

            public QuotesSQL(Sys.Database database)
            {
                _database = database;
            }

            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            public DataView QuotesGet_All()
            {
                _database.ClearParameter();
                var dt = _database.ExecuteSP_DataTable("Quotes_GetAll");
                dt.TableName = Sys.Enums.TableNames.tblQuotes.ToString();
                return new DataView(dt);
            }

            public DataView Quotes_Search(string Criteria)
            {
                _database.ClearParameter();
                _database.AddParameter("@Criteria", Criteria, true);
                var dt = _database.ExecuteSP_DataTable("Quotes_Search");
                dt.TableName = Sys.Enums.TableNames.tblQuotes.ToString();
                return new DataView(dt);
            }

            public DataView QuotesGet_All_For_CustomerID(int CustomerID)
            {
                _database.ClearParameter();
                _database.AddParameter("@CustomerID", CustomerID);
                var dt = _database.ExecuteSP_DataTable("QuotesGet_All_For_CustomerID");
                dt.TableName = Sys.Enums.TableNames.tblQuotes.ToString();
                return new DataView(dt);
            }

            public DataView QuotesGet_All_For_SiteID(int SiteID)
            {
                _database.ClearParameter();
                _database.AddParameter("@SiteID", SiteID);
                var dt = _database.ExecuteSP_DataTable("QuotesGet_All_For_SiteID");
                dt.TableName = Sys.Enums.TableNames.tblQuotes.ToString();
                return new DataView(dt);
            }

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}