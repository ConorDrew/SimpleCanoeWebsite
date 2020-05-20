using System.Data;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace PartSupplierPriceRequests
    {
        public class PartSupplierPriceRequestSQL
        {
            private Sys.Database _database;

            public PartSupplierPriceRequestSQL(Sys.Database database)
            {
                _database = database;
            }

            public PartSupplierPriceRequest InsertForOrder(PartSupplierPriceRequest oPartSupplierPriceRequest)
            {
                _database.ClearParameter();
                AddPartSupplierPriceRequestParametersToCommand(ref oPartSupplierPriceRequest);
                _database.AddParameter("@OrderID", oPartSupplierPriceRequest.OrderID, true);
                oPartSupplierPriceRequest.SetPartSupplierPriceRequestID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("PartSupplierPriceRequest_InsertForOrder"));
                oPartSupplierPriceRequest.Exists = true;
                return oPartSupplierPriceRequest;
            }

            public void Complete(int PartSupplierPriceRequestID)
            {
                _database.ClearParameter();
                _database.AddParameter("@PartSupplierPriceRequestID", PartSupplierPriceRequestID, true);
                _database.ExecuteSP_NO_Return("PartSupplierPriceRequest_Complete");
            }

            private void AddPartSupplierPriceRequestParametersToCommand(ref PartSupplierPriceRequest oPartSupplierPriceRequest)
            {
                {
                    var withBlock = _database;
                    withBlock.AddParameter("@SupplierID", oPartSupplierPriceRequest.SupplierID, true);
                    withBlock.AddParameter("@PartID", oPartSupplierPriceRequest.PartID, true);
                    withBlock.AddParameter("@QuantityInPack", oPartSupplierPriceRequest.QuantityInPack, true);
                    withBlock.AddParameter("@Complete", oPartSupplierPriceRequest.Complete, true);
                }
            }
        }
    }
}