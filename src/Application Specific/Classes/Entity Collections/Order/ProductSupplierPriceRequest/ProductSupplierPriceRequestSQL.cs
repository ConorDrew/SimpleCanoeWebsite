using System.Data;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace ProductSupplierPriceRequests
    {
        public class ProductSupplierPriceRequestSQL
        {
            private Sys.Database _database;

            public ProductSupplierPriceRequestSQL(Sys.Database database)
            {
                _database = database;
            }

            public ProductSupplierPriceRequest InsertForOrder(ProductSupplierPriceRequest oProductSupplierPriceRequest)
            {
                _database.ClearParameter();
                AddProductSupplierPriceRequestParametersToCommand(ref oProductSupplierPriceRequest);
                _database.AddParameter("@OrderID", oProductSupplierPriceRequest.OrderID, true);
                oProductSupplierPriceRequest.SetProductSupplierPriceRequestID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("PartSupplierPriceRequest_InsertForOrder"));
                oProductSupplierPriceRequest.Exists = true;
                return oProductSupplierPriceRequest;
            }

            public void Complete(int ProductSupplierPriceRequestID)
            {
                _database.ClearParameter();
                _database.AddParameter("@ProductSupplierPriceRequestID", ProductSupplierPriceRequestID, true);
                _database.ExecuteSP_NO_Return("ProductSupplierPriceRequest_Complete");
            }

            private void AddProductSupplierPriceRequestParametersToCommand(ref ProductSupplierPriceRequest oProductSupplierPriceRequest)
            {
                {
                    var withBlock = _database;
                    withBlock.AddParameter("@QuantityInPack", oProductSupplierPriceRequest.QuantityInPack, true);
                    withBlock.AddParameter("@Complete", oProductSupplierPriceRequest.Complete, true);
                    withBlock.AddParameter("@ProductID", oProductSupplierPriceRequest.ProductID, true);
                    withBlock.AddParameter("@SupplierID", oProductSupplierPriceRequest.SupplierID, true);
                }
            }
        }
    }
}