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

            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            public void DeleteForOrder(int OrderID)
            {
                _database.ClearParameter();
                _database.AddParameter("@OrderID", OrderID, true);
                _database.ExecuteSP_NO_Return("PartSupplierPriceRequest_DeleteForOrder");
            }

            public void Delete(int PartSupplierPriceRequestID)
            {
                _database.ClearParameter();
                _database.AddParameter("@PartSupplierPriceRequestID", PartSupplierPriceRequestID, true);
                _database.ExecuteSP_NO_Return("PartSupplierPriceRequest_Delete");
            }

            public PartSupplierPriceRequest PartSupplierPriceRequest_Get(int PartSupplierPriceRequestID)
            {
                _database.ClearParameter();
                _database.AddParameter("@PartSupplierPriceRequestID", PartSupplierPriceRequestID);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("PartSupplierPriceRequest_Get");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oPartSupplierPriceRequest = new PartSupplierPriceRequest();
                        oPartSupplierPriceRequest.IgnoreExceptionsOnSetMethods = true;
                        oPartSupplierPriceRequest.SetPartSupplierPriceRequestID = dt.Rows[0]["PartSupplierPriceRequestID"];
                        oPartSupplierPriceRequest.SetOrderID = dt.Rows[0]["OrderID"];
                        oPartSupplierPriceRequest.SetSupplierID = dt.Rows[0]["SupplierID"];
                        oPartSupplierPriceRequest.SetPartID = dt.Rows[0]["PartID"];
                        oPartSupplierPriceRequest.SetQuantityInPack = dt.Rows[0]["QuantityInPack"];
                        oPartSupplierPriceRequest.SetComplete = dt.Rows[0]["Complete"];
                        oPartSupplierPriceRequest.SetDeleted = Conversions.ToBoolean(dt.Rows[0]["Deleted"]);
                        oPartSupplierPriceRequest.Exists = true;
                        return oPartSupplierPriceRequest;
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

            public DataView PartSupplierPriceRequest_GetForOrder(int OrderID)
            {
                _database.ClearParameter();
                _database.AddParameter("@OrderID", OrderID, true);
                var dt = _database.ExecuteSP_DataTable("PartSupplierPriceRequest_GetForOrder");
                dt.TableName = Sys.Enums.TableNames.tblPart.ToString();
                return new DataView(dt);
            }

            public DataView PartSupplierPriceRequest_GetAll()
            {
                _database.ClearParameter();
                var dt = _database.ExecuteSP_DataTable("PartSupplierPriceRequest_GetAll");
                dt.TableName = Sys.Enums.TableNames.tblPartSupplierPriceRequest.ToString();
                return new DataView(dt);
            }

            public PartSupplierPriceRequest Insert(PartSupplierPriceRequest oPartSupplierPriceRequest)
            {
                _database.ClearParameter();
                AddPartSupplierPriceRequestParametersToCommand(ref oPartSupplierPriceRequest);
                _database.AddParameter("@QuoteID", oPartSupplierPriceRequest.QuoteID, true);
                _database.AddParameter("@OrderID", oPartSupplierPriceRequest.OrderID, true);
                oPartSupplierPriceRequest.SetPartSupplierPriceRequestID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("PartSupplierPriceRequest_Insert"));
                oPartSupplierPriceRequest.Exists = true;
                return oPartSupplierPriceRequest;
            }

            public PartSupplierPriceRequest InsertForQuote(PartSupplierPriceRequest oPartSupplierPriceRequest)
            {
                _database.ClearParameter();
                AddPartSupplierPriceRequestParametersToCommand(ref oPartSupplierPriceRequest);
                _database.AddParameter("@QuoteID", oPartSupplierPriceRequest.QuoteID, true);
                oPartSupplierPriceRequest.SetPartSupplierPriceRequestID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("PartSupplierPriceRequest_InsertForQuote"));
                oPartSupplierPriceRequest.Exists = true;
                return oPartSupplierPriceRequest;
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


            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}