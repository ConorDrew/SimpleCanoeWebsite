using System.Data;
using FSM.Entity.Sys;

namespace FSM.Entity.CostCentres.LinkTypes
{
    public class LinkTypeSql
    {
        private Database _database;

        public LinkTypeSql(Database database)
        {
            _database = database;
        }

        public DataView GetAll()
        {
            _database.ClearParameter();
            return new DataView(_database.ExecuteSP_DataTable("CostCentreLinkType_GetAll"));
        }
    }
}