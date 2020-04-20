
namespace FSM.Entity
{
    public class StockTakeAuditSQL
    {
        private Sys.Database _database;

        public StockTakeAuditSQL(Sys.Database database)
        {
            _database = database;
        }

        private void AddStockTakeAuditParametersToCommand(StockTakeAudit oStockTakeAudit)
        {
            _database.AddParameter("@PartID", oStockTakeAudit.PartID, true);
            _database.AddParameter("@UserID", App.loggedInUser.UserID, true);
            _database.AddParameter("@OriginalAmount", oStockTakeAudit.OriginalAmount, true);
            _database.AddParameter("@NewAmount", oStockTakeAudit.NewAmount, true);
            _database.AddParameter("@ReasonChangeID", oStockTakeAudit.ReasonChange, true);
            _database.AddParameter("@LocationID", oStockTakeAudit.LocationID, true);
        }

        public StockTakeAudit Insert(StockTakeAudit oStockTakeAudit)
        {
            _database.ClearParameter();
            AddStockTakeAuditParametersToCommand(oStockTakeAudit);
            oStockTakeAudit.SetStockTakeAuditID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("StockTakeAudit_Insert"));
            oStockTakeAudit.Exists = true;
            return oStockTakeAudit;
        }
    }
}