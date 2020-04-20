using System.Data;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace QuoteOrderParts
    {
        public class QuoteOrderPartSQL
        {
            private Sys.Database _database;

            public QuoteOrderPartSQL(Sys.Database database)
            {
                _database = database;
            }

            /* TODO ERROR: Skipped RegionDirectiveTrivia */

            public void Delete(int QuoteOrderPartID)
            {
                _database.ClearParameter();
                _database.AddParameter("@QuoteOrderPartID", QuoteOrderPartID, true);
                _database.ExecuteSP_NO_Return("QuoteOrderPart_Delete");
            }

            public QuoteOrderPart QuoteOrderPart_Get(int QuoteOrderPartID)
            {
                _database.ClearParameter();
                _database.AddParameter("@QuoteOrderPartID", QuoteOrderPartID);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("QuoteOrderPart_Get");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oQuoteOrderPart = new QuoteOrderPart();
                        oQuoteOrderPart.IgnoreExceptionsOnSetMethods = true;
                        oQuoteOrderPart.SetQuoteOrderPartID = dt.Rows[0]["QuoteOrderPartID"];
                        oQuoteOrderPart.SetQuoteOrderID = dt.Rows[0]["QuoteOrderID"];
                        oQuoteOrderPart.SetPartID = dt.Rows[0]["PartID"];
                        oQuoteOrderPart.SetPrice = Sys.Helper.MakeDoubleValid("Price");
                        oQuoteOrderPart.SetQuantity = Sys.Helper.MakeIntegerValid("Quantity");
                        oQuoteOrderPart.SetDeleted = Conversions.ToBoolean(dt.Rows[0]["Deleted"]);
                        oQuoteOrderPart.Exists = true;
                        return oQuoteOrderPart;
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

            public DataView QuoteOrderPart_GetAll()
            {
                _database.ClearParameter();
                var dt = _database.ExecuteSP_DataTable("QuoteOrderPart_GetAll");
                dt.TableName = Sys.Enums.TableNames.tblQuoteOrderPart.ToString();
                return new DataView(dt);
            }

            public QuoteOrderPart Insert(QuoteOrderPart oQuoteOrderPart)
            {
                _database.ClearParameter();
                AddQuoteOrderPartParametersToCommand(ref oQuoteOrderPart);
                oQuoteOrderPart.SetQuoteOrderPartID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("QuoteOrderPart_Insert"));
                oQuoteOrderPart.Exists = true;
                return oQuoteOrderPart;
            }

            public void QuoteOrderPart_DeleteForQuoteOrder(int QuoteOrderID)
            {
                _database.ClearParameter();
                _database.AddParameter("@QuoteOrderID", QuoteOrderID, true);
                _database.ExecuteSP_NO_Return("QuoteOrderPart_DeleteForQuoteOrder");
            }

            public void Update(QuoteOrderPart oQuoteOrderPart)
            {
                _database.ClearParameter();
                _database.AddParameter("@QuoteOrderPartID", oQuoteOrderPart.QuoteOrderPartID, true);
                AddQuoteOrderPartParametersToCommand(ref oQuoteOrderPart);
                _database.ExecuteSP_NO_Return("QuoteOrderPart_Update");
            }

            public object QuoteOrderPart_GetForQuoteOrder(int QuoteOrderID)
            {
                _database.ClearParameter();
                _database.AddParameter("@QuoteOrderID", QuoteOrderID, true);
                var dt = _database.ExecuteSP_DataTable("QuoteOrderPart_GetForQuoteOrder");
                dt.TableName = Sys.Enums.TableNames.tblPart.ToString();
                return new DataView(dt);
            }

            private void AddQuoteOrderPartParametersToCommand(ref QuoteOrderPart oQuoteOrderPart)
            {
                {
                    var withBlock = _database;
                    withBlock.AddParameter("@QuoteOrderID", oQuoteOrderPart.QuoteOrderID, true);
                    withBlock.AddParameter("@PartID", oQuoteOrderPart.PartID, true);
                    withBlock.AddParameter("@Price", oQuoteOrderPart.Price, true);
                    withBlock.AddParameter("@Quantity", oQuoteOrderPart.Quantity, true);
                }
            }


            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}