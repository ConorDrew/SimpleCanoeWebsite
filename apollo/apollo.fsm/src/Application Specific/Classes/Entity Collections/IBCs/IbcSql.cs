using System.Data;
using FSM.Entity.Sys;

namespace FSM.Entity.Ibc
{
    public class IbcSql
    {
        private Database _database;

        public IbcSql(Database database)
        {
            _database = database;
        }

        public DataView GetAll()
        {
            _database.ClearParameter();
            return new DataView(_database.ExecuteSP_DataTable("Ibc_GetAll"));
        }
    }
}