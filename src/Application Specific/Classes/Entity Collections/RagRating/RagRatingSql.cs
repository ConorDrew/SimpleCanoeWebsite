using System.Data;
using FSM.Entity.Sys;

namespace FSM.Entity.RagRating
{
    public class RagRatingSql
    {
        private Database _database;

        public RagRatingSql(Database database)
        {
            _database = database;
        }

        public DataView Get_All()
        {
            _database.ClearParameter();
            return new DataView(_database.ExecuteSP_DataTable("RagRating_Get_All"));
        }
    }
}