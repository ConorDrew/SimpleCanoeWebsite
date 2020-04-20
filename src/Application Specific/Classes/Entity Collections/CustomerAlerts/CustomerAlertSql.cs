using System.Collections.Generic;
using FSM.Entity.Sys;

namespace FSM.Entity.Customers
{
    public class CustomerAlertSql
    {
        private Database _database;

        public CustomerAlertSql(Database database)
        {
            _database = database;
        }

        public List<CustomerAlert> Get(int Id)
        {
            _database.ClearParameter();
            _database.AddParameter("@Id", Id);
            var dt = _database.ExecuteSP_DataTable("CustomerAlert_Get");
            if (dt is object && dt.Rows.Count > 0)
            {
                var customerAlerts = ObjectMap.DataTableToList<CustomerAlert>(dt);
                return customerAlerts;
            }
            else
            {
                return null;
            }
        }

        public List<CustomerAlert> Get_ForCustomer(int customerId)
        {
            _database.ClearParameter();
            _database.AddParameter("@CustomerId", customerId);
            var dt = _database.ExecuteSP_DataTable("CustomerAlert_Get_ForCustomer");
            if (dt is object && dt.Rows.Count > 0)
            {
                var customerAlerts = ObjectMap.DataTableToList<CustomerAlert>(dt);
                return customerAlerts;
            }
            else
            {
                return null;
            }
        }

        public CustomerAlert Insert(CustomerAlert customerAlert)
        {
            _database.ClearParameter();
            _database.AddParameter("@CustomerId", customerAlert.CustomerId, true);
            _database.AddParameter("@AlertTypeId", customerAlert.AlertTypeId, true);
            _database.AddParameter("@EmailAddress", customerAlert.EmailAddress, true);
            customerAlert.Id = Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("CustomerAlert_Insert"));
            return customerAlert;
        }

        public void Update(CustomerAlert customerAlert)
        {
            _database.ClearParameter();
            _database.AddParameter("@Id", customerAlert.Id, true);
            _database.AddParameter("@EmailAddress", customerAlert.EmailAddress, true);
            _database.ExecuteSP_NO_Return("CustomerAlert_Update");
        }

        public void Delete(CustomerAlert customerAlert)
        {
            _database.ClearParameter();
            _database.AddParameter("@Id", customerAlert.Id, true);
            _database.ExecuteSP_NO_Return("CustomerAlert_Delete");
        }
    }
}