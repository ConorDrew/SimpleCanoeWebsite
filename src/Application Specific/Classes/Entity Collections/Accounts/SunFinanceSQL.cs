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

            
            public DataTable GetAllMaps()
            {
                _database.ClearParameter();
                return _database.ExecuteSP_DataTable("AccountsMapping_Get_All");
            }
            
        }
    }
}