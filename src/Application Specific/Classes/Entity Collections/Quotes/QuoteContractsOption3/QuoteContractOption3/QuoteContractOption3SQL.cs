using System.Data;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace QuoteContractOption3s
    {
        public class QuoteContractOption3SQL
        {
            private Sys.Database _database;

            public QuoteContractOption3SQL(Sys.Database database)
            {
                _database = database;
            }

            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            public DataTable VisitFrequency_Get()
            {
                _database.ClearParameter();
                return _database.ExecuteSP_DataTable("VisitFrequencyOption3_Get");
            }

            public DataTable InvoiceFrequency_Get()
            {
                _database.ClearParameter();
                return _database.ExecuteSP_DataTable("InvoiceFrequency_Get");
            }

            public void Delete(int QuoteContractID)
            {
                _database.ClearParameter();
                _database.AddParameter("@QuoteContractID", QuoteContractID, true);
                _database.ExecuteSP_NO_Return("QuoteContractOption3_Delete");
            }

            public QuoteContractOption3 QuoteContractOption3_Get(int QuoteContractID)
            {
                _database.ClearParameter();
                _database.AddParameter("@QuoteContractID", QuoteContractID);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("QuoteContractOption3_Get");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oQuoteContractOption3 = new QuoteContractOption3();
                        oQuoteContractOption3.IgnoreExceptionsOnSetMethods = true;
                        oQuoteContractOption3.SetQuoteContractID = dt.Rows[0]["QuoteContractID"];
                        oQuoteContractOption3.SetCustomerID = dt.Rows[0]["CustomerID"];
                        oQuoteContractOption3.SetQuoteContractReference = dt.Rows[0]["QuoteContractReference"];
                        oQuoteContractOption3.SetQuoteContractStatusID = dt.Rows[0]["QuoteContractStatusID"];
                        oQuoteContractOption3.QuoteContractDate = Conversions.ToDate(dt.Rows[0]["QuoteContractDate"]);
                        oQuoteContractOption3.SetQuoteContractPrice = dt.Rows[0]["QuoteContractPrice"];
                        oQuoteContractOption3.SetReasonForReject = dt.Rows[0]["ReasonForReject"];
                        oQuoteContractOption3.Exists = true;
                        return oQuoteContractOption3;
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

            public DataView QuoteContractOption3_GetAll()
            {
                _database.ClearParameter();
                var dt = _database.ExecuteSP_DataTable("QuoteContractOption3_GetAll");
                dt.TableName = Sys.Enums.TableNames.tblQuoteContractOption3.ToString();
                return new DataView(dt);
            }

            public QuoteContractOption3 Insert(QuoteContractOption3 oQuoteContractOption3)
            {
                _database.ClearParameter();
                AddQuoteContractOption3ParametersToCommand(ref oQuoteContractOption3);
                oQuoteContractOption3.SetQuoteContractID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("QuoteContractOption3_Insert"));
                oQuoteContractOption3.Exists = true;
                return oQuoteContractOption3;
            }

            public void Update(QuoteContractOption3 oQuoteContractOption3)
            {
                _database.ClearParameter();
                _database.AddParameter("@QuoteContractID", oQuoteContractOption3.QuoteContractID, true);
                AddQuoteContractOption3ParametersToCommand(ref oQuoteContractOption3);
                _database.ExecuteSP_NO_Return("QuoteContractOption3_Update");
            }

            private void AddQuoteContractOption3ParametersToCommand(ref QuoteContractOption3 oQuoteContractOption3)
            {
                {
                    var withBlock = _database;
                    withBlock.AddParameter("@CustomerID", oQuoteContractOption3.CustomerID, true);
                    withBlock.AddParameter("@QuoteContractReference", oQuoteContractOption3.QuoteContractReference, true);
                    withBlock.AddParameter("@QuoteContractStatusID", oQuoteContractOption3.QuoteContractStatusID, true);
                    withBlock.AddParameter("@QuoteContractDate", oQuoteContractOption3.QuoteContractDate, true);
                    withBlock.AddParameter("@QuoteContractPrice", oQuoteContractOption3.QuoteContractPrice, true);
                    withBlock.AddParameter("@ReasonForReject", oQuoteContractOption3.ReasonForReject, true);
                }
            }

            public double QuoteContractCalculatedTotal(int QuoteContractID)
            {
                _database.ClearParameter();
                _database.AddParameter("@QuoteContractID", QuoteContractID, true);
                return Sys.Helper.MakeDoubleValid(_database.ExecuteSP_OBJECT("QuoteContractOption3CalculatedTotal"));
            }

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}