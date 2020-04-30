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

            

            public void Delete(int ProductSupplierPriceRequestID)
            {
                _database.ClearParameter();
                _database.AddParameter("@ProductSupplierPriceRequestID", ProductSupplierPriceRequestID, true);
                _database.ExecuteSP_NO_Return("ProductSupplierPriceRequest_Delete");
            }

            public void DeleteForOrder(int OrderID)
            {
                _database.ClearParameter();
                _database.AddParameter("@OrderID", OrderID, true);
                _database.ExecuteSP_NO_Return("ProductSupplierPriceRequest_DeleteForOrder");
            }

            public ProductSupplierPriceRequest ProductSupplierPriceRequest_Get(int ProductSupplierPriceRequestID)
            {
                _database.ClearParameter();
                _database.AddParameter("@ProductSupplierPriceRequestID", ProductSupplierPriceRequestID);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("ProductSupplierPriceRequest_Get");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oProductSupplierPriceRequest = new ProductSupplierPriceRequest();
                        oProductSupplierPriceRequest.IgnoreExceptionsOnSetMethods = true;
                        oProductSupplierPriceRequest.SetProductSupplierPriceRequestID = dt.Rows[0]["ProductSupplierPriceRequestID"];
                        oProductSupplierPriceRequest.SetOrderID = dt.Rows[0]["OrderID"];
                        oProductSupplierPriceRequest.SetQuantityInPack = dt.Rows[0]["QuantityInPack"];
                        oProductSupplierPriceRequest.SetComplete = dt.Rows[0]["Complete"];
                        oProductSupplierPriceRequest.SetProductID = dt.Rows[0]["ProductID"];
                        oProductSupplierPriceRequest.SetSupplierID = dt.Rows[0]["SupplierID"];
                        oProductSupplierPriceRequest.SetDeleted = Conversions.ToBoolean(dt.Rows[0]["Deleted"]);
                        oProductSupplierPriceRequest.Exists = true;
                        return oProductSupplierPriceRequest;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }

            public object ProductSupplierPriceRequest_GetForOrder(int OrderID)
            {
                _database.ClearParameter();
                _database.AddParameter("@OrderID", OrderID, true);
                var dt = _database.ExecuteSP_DataTable("ProductSupplierPriceRequest_GetForOrder");
                dt.TableName = Sys.Enums.TableNames.tblProduct.ToString();
                return new DataView(dt);
            }

            public DataView ProductSupplierPriceRequest_GetAll()
            {
                _database.ClearParameter();
                var dt = _database.ExecuteSP_DataTable("ProductSupplierPriceRequest_GetAll");
                dt.TableName = Sys.Enums.TableNames.tblProductSupplierPriceRequest.ToString();
                return new DataView(dt);
            }

            public ProductSupplierPriceRequest Insert(ProductSupplierPriceRequest oProductSupplierPriceRequest)
            {
                _database.ClearParameter();
                AddProductSupplierPriceRequestParametersToCommand(ref oProductSupplierPriceRequest);
                _database.AddParameter("@QuoteID", oProductSupplierPriceRequest.QuoteID, true);
                _database.AddParameter("@OrderID", oProductSupplierPriceRequest.OrderID, true);
                oProductSupplierPriceRequest.SetProductSupplierPriceRequestID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("ProductSupplierPriceRequest_Insert"));
                oProductSupplierPriceRequest.Exists = true;
                return oProductSupplierPriceRequest;
            }

            public ProductSupplierPriceRequest InsertForQuote(ProductSupplierPriceRequest oProductSupplierPriceRequest)
            {
                _database.ClearParameter();
                AddProductSupplierPriceRequestParametersToCommand(ref oProductSupplierPriceRequest);
                _database.AddParameter("@QuoteID", oProductSupplierPriceRequest.QuoteID, true);
                oProductSupplierPriceRequest.SetProductSupplierPriceRequestID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("ProductSupplierPriceRequest_InsertForQuote"));
                oProductSupplierPriceRequest.Exists = true;
                return oProductSupplierPriceRequest;
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