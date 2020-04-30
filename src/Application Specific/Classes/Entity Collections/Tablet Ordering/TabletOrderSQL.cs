
namespace FSM.Entity
{
    namespace TabletOrders
    {
        public class TabletOrderSQL
        {
            private Sys.Database _database;

            public TabletOrderSQL(Sys.Database database)
            {
                _database = database;
            }

            
            public int InsertTabletOrderItem(TabletOrderItem oTabletOrder)
            {
                _database.ClearParameter();
                _database.AddParameter("@OrderID", oTabletOrder.TabletOrderID, true);
                _database.AddParameter("@EngineerID", oTabletOrder.EngineerID, true);
                _database.AddParameter("@SupplierID", oTabletOrder.SupplierID, true);
                _database.AddParameter("@SelectedVisitID", oTabletOrder.SelectedVisitID, true);
                _database.AddParameter("@ForNextVisit", oTabletOrder.ForNextVisit, true);
                return Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("TabletOrderItem_Insert"));
            }

            public int InsertTabletOrderPart(TabletOrderPart oTabletOrderPart)
            {
                _database.ClearParameter();
                _database.AddParameter("@OrderPartID", oTabletOrderPart.OrderPartID, true);
                _database.AddParameter("@OrderID", oTabletOrderPart.OrderID, true);
                _database.AddParameter("@EngineerID", oTabletOrderPart.EngineerID, true);
                _database.AddParameter("@Quantity", oTabletOrderPart.Quantity, true);
                _database.AddParameter("@PartSupplierID", oTabletOrderPart.PartSupplierID, true);
                return Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("TabletOrderPart_Insert"));
            }

            
        }
    }
}