using System.Data;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace QuoteContractOriginals
    {
        public class QuoteContractOriginalSQL
        {
            private Sys.Database _database;

            public QuoteContractOriginalSQL(Sys.Database database)
            {
                _database = database;
            }

            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            public DataTable VisitFrequency_Get()
            {
                _database.ClearParameter();
                return _database.ExecuteSP_DataTable("VisitFrequency_Get");
            }

            public QuoteContractOriginal Get(int QuoteContractID)
            {
                _database.ClearParameter();
                _database.AddParameter("@QuoteContractID", QuoteContractID);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("QuoteContractOriginal_Get");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oQuoteContract = new QuoteContractOriginal();
                        oQuoteContract.IgnoreExceptionsOnSetMethods = true;
                        oQuoteContract.SetQuoteContractID = dt.Rows[0]["QuoteContractID"];
                        oQuoteContract.SetCustomerID = dt.Rows[0]["CustomerID"];
                        oQuoteContract.SetQuoteContractReference = dt.Rows[0]["QuoteContractReference"];
                        oQuoteContract.QuoteContractDate = Conversions.ToDate(dt.Rows[0]["QuoteContractDate"]);
                        oQuoteContract.ContractStart = Conversions.ToDate(dt.Rows[0]["ContractStart"]);
                        oQuoteContract.ContractEnd = Conversions.ToDate(dt.Rows[0]["ContractEnd"]);
                        oQuoteContract.SetQuoteContractStatusID = dt.Rows[0]["QuoteContractStatusID"];
                        oQuoteContract.SetQuoteContractPrice = dt.Rows[0]["QuoteContractPrice"];
                        oQuoteContract.SetReasonForReject = dt.Rows[0]["ReasonForReject"];
                        oQuoteContract.SetDeleted = Conversions.ToBoolean(dt.Rows[0]["Deleted"]);
                        oQuoteContract.Exists = true;
                        return oQuoteContract;
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

            public double QuoteContractCalculatedTotal(int QuoteContractID)
            {
                _database.ClearParameter();
                _database.AddParameter("@QuoteContractID", QuoteContractID, true);
                return Sys.Helper.MakeDoubleValid(_database.ExecuteSP_OBJECT("QuoteContractOriginalCalculatedTotal"));
            }

            public QuoteContractOriginal Insert(QuoteContractOriginal oQuoteContract)
            {
                _database.ClearParameter();
                AddQuoteContractParametersToCommand(ref oQuoteContract);
                oQuoteContract.SetQuoteContractID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("QuoteContractOriginal_Insert"));
                oQuoteContract.Exists = true;
                return oQuoteContract;
            }

            public void Update(QuoteContractOriginal oQuoteContract)
            {
                _database.ClearParameter();
                _database.AddParameter("@QuoteContractID", oQuoteContract.QuoteContractID, true);
                AddQuoteContractParametersToCommand(ref oQuoteContract);
                _database.ExecuteSP_NO_Return("QuoteContractOriginal_Update");
            }

            public void Delete(int QuoteContractID)
            {
                _database.ClearParameter();
                _database.AddParameter("@QuoteContractID", QuoteContractID, true);
                _database.ExecuteSP_NO_Return("QuoteContractOriginal_Delete");
            }

            private void AddQuoteContractParametersToCommand(ref QuoteContractOriginal oQuoteContract)
            {
                {
                    var withBlock = _database;
                    withBlock.AddParameter("@CustomerID", oQuoteContract.CustomerID, true);
                    withBlock.AddParameter("@QuoteContractReference", oQuoteContract.QuoteContractReference, true);
                    withBlock.AddParameter("@QuoteContractDate", oQuoteContract.QuoteContractDate, true);
                    withBlock.AddParameter("@ContractStart", oQuoteContract.ContractStart, true);
                    withBlock.AddParameter("@ContractEnd", oQuoteContract.ContractEnd, true);
                    withBlock.AddParameter("@QuoteContractStatusID", oQuoteContract.QuoteContractStatusID, true);
                    withBlock.AddParameter("@QuoteContractPrice", oQuoteContract.QuoteContractPrice, true);
                    withBlock.AddParameter("@ReasonForReject", oQuoteContract.ReasonForReject, true);
                }
            }

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}