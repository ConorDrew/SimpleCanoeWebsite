using System.Linq;
using FSM.Entity.Sys;

namespace FSM.Entity.CompanyDetails
{
    public class CompanyDetailsSql
    {
        private Database _database;

        public CompanyDetailsSql(Database database)
        {
            _database = database;
        }

        public CompanyDetails Get()
        {
            _database.ClearParameter();
            var dt = _database.ExecuteSP_DataTable("CompanyDetails_Get");
            if (dt is object && dt.Rows.Count > 0)
            {
                var companyDetails = ObjectMap.DataTableToList<CompanyDetails>(dt);
                return companyDetails.FirstOrDefault();
            }
            else
            {
                return null;
            }
        }
    }
}