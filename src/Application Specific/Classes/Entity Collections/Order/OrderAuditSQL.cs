using System.Data;

namespace FSM.Entity
{
    public class OrderAuditSQL
    {
        private Entity.Sys.Database _database;

        public OrderAuditSQL(Entity.Sys.Database database)
        {
            _database = database;
        }

        private void AddOrderAuditParametersToCommand(Entity.OrderAudit oOrderAudit)
        {
            _database.AddParameter("@OrderID", oOrderAudit.OrderID, true);
            _database.AddParameter("@ReasonID", oOrderAudit.ReasonID, true);
            _database.AddParameter("@Description", oOrderAudit.Description, true);
            _database.AddParameter("@UserID", FSM.App.loggedInUser.UserID, true);
        }

        public Entity.OrderAudit Insert(Entity.OrderAudit oOrderAudit)
        {
            _database.ClearParameter();
            AddOrderAuditParametersToCommand(oOrderAudit);
            oOrderAudit.SetOrderAuditID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("OrderAudit_Insert"));
            oOrderAudit.Exists = true;
            return oOrderAudit;
        }

        public DataView Get_For_Job(int OrderID)
        {
            _database.ClearParameter();
            _database.AddParameter("@OrderID", OrderID, true);
            var dt = _database.ExecuteSP_DataTable("OrderAudit_Get");
            dt.TableName = Entity.Sys.Enums.TableNames.tblJobAudit.ToString();
            return new DataView(dt);
        }
    }
}