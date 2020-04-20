using System.Data;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace QuoteOrderProducts
    {
        public class QuoteOrderProductSQL
        {
            private Sys.Database _database;

            public QuoteOrderProductSQL(Sys.Database database)
            {
                _database = database;
            }

            /* TODO ERROR: Skipped RegionDirectiveTrivia */

            public void Delete(int QuoteOrderProductID)
            {
                _database.ClearParameter();
                _database.AddParameter("@QuoteOrderProductID", QuoteOrderProductID, true);
                _database.ExecuteSP_NO_Return("QuoteOrderProduct_Delete");
            }

            public QuoteOrderProduct QuoteOrderProduct_Get(int QuoteOrderProductID)
            {
                _database.ClearParameter();
                _database.AddParameter("@QuoteOrderProductID", QuoteOrderProductID);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("QuoteOrderProduct_Get");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oQuoteOrderProduct = new QuoteOrderProduct();
                        oQuoteOrderProduct.IgnoreExceptionsOnSetMethods = true;
                        oQuoteOrderProduct.SetQuoteOrderProductID = dt.Rows[0]["QuoteOrderProductID"];
                        oQuoteOrderProduct.SetQuoteOrderID = dt.Rows[0]["QuoteOrderID"];
                        oQuoteOrderProduct.SetProductID = dt.Rows[0]["ProductID"];
                        oQuoteOrderProduct.SetPrice = Sys.Helper.MakeDoubleValid("Price");
                        oQuoteOrderProduct.SetQuantity = Sys.Helper.MakeIntegerValid("Quantity");
                        oQuoteOrderProduct.SetDeleted = Conversions.ToBoolean(dt.Rows[0]["Deleted"]);
                        oQuoteOrderProduct.Exists = true;
                        return oQuoteOrderProduct;
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

            public DataView QuoteOrderProduct_GetAll()
            {
                _database.ClearParameter();
                var dt = _database.ExecuteSP_DataTable("QuoteOrderProduct_GetAll");
                dt.TableName = Sys.Enums.TableNames.tblQuoteOrderProduct.ToString();
                return new DataView(dt);
            }

            public QuoteOrderProduct Insert(QuoteOrderProduct oQuoteOrderProduct)
            {
                _database.ClearParameter();
                AddQuoteOrderProductParametersToCommand(ref oQuoteOrderProduct);
                oQuoteOrderProduct.SetQuoteOrderProductID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("QuoteOrderProduct_Insert"));
                oQuoteOrderProduct.Exists = true;
                return oQuoteOrderProduct;
            }

            public void Update(QuoteOrderProduct oQuoteOrderProduct)
            {
                _database.ClearParameter();
                _database.AddParameter("@QuoteOrderProductID", oQuoteOrderProduct.QuoteOrderProductID, true);
                AddQuoteOrderProductParametersToCommand(ref oQuoteOrderProduct);
                _database.ExecuteSP_NO_Return("QuoteOrderProduct_Update");
            }

            public object QuoteOrderProduct_GetForQuoteOrder(int QuoteOrderID)
            {
                _database.ClearParameter();
                _database.AddParameter("@QuoteOrderID", QuoteOrderID, true);
                var dt = _database.ExecuteSP_DataTable("QuoteOrderProduct_GetForQuoteOrder");
                dt.TableName = Sys.Enums.TableNames.tblProduct.ToString();
                return new DataView(dt);
            }

            private void AddQuoteOrderProductParametersToCommand(ref QuoteOrderProduct oQuoteOrderProduct)
            {
                {
                    var withBlock = _database;
                    withBlock.AddParameter("@QuoteOrderID", oQuoteOrderProduct.QuoteOrderID, true);
                    withBlock.AddParameter("@ProductID", oQuoteOrderProduct.ProductID, true);
                    withBlock.AddParameter("@Price", oQuoteOrderProduct.Price, true);
                    withBlock.AddParameter("@Quantity", oQuoteOrderProduct.Quantity, true);
                }
            }

            public void QuoteOrderProduct_DeleteForQuoteOrder(int QuoteOrderID)
            {
                _database.ClearParameter();
                _database.AddParameter("@QuoteOrderID", QuoteOrderID, true);
                _database.ExecuteSP_NO_Return("QuoteOrderProduct_DeleteForQuoteOrder");
            }

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}