using System.Data;

namespace FSM.Entity
{
    namespace Accounts
    {
        public class SunFinanceSQL
        {
            private Sys.Database _database;

            public SunFinanceSQL(Sys.Database database)
            {
                _database = database;
            }

            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            public DataTable GetAllMaps()
            {
                _database.ClearParameter();
                return _database.ExecuteSP_DataTable("AccountsMapping_Get_All");
            }
            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}