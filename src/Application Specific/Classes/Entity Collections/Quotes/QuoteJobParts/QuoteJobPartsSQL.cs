using System;

namespace FSM.Entity
{
    namespace QuoteJobPartss
    {
        public class QuoteJobPartsSQL
        {
            private Sys.Database _database;

            public QuoteJobPartsSQL(Sys.Database database)
            {
                _database = database;
            }

            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            public void Delete(int QuoteJobID)
            {
                _database.ClearParameter();
                _database.AddParameter("@QuoteJobID", QuoteJobID, true);
                _database.ExecuteSP_NO_Return("QuoteJobParts_Delete");
            }

            public void DeleteAll(int QuoteJobID)
            {
                _database.ClearParameter();
                _database.AddParameter("@QuoteJobID", QuoteJobID, true);
                _database.ExecuteSP_NO_Return("QuoteJobParts_DeleteAllMarkedDeleted");
            }

            public QuoteJobParts Insert(QuoteJobParts oQuoteJobParts)
            {
                _database.ClearParameter();
                AddQuoteJobPartsParametersToCommand(ref oQuoteJobParts);
                oQuoteJobParts.SetQuoteJobPartsID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("QuoteJob_Parts_Insert"));
                oQuoteJobParts.Exists = true;
                return oQuoteJobParts;
            }

            private void AddQuoteJobPartsParametersToCommand(ref QuoteJobParts oQuoteJobParts)
            {
                {
                    var withBlock = _database;
                    withBlock.AddParameter("@QuoteJobID", oQuoteJobParts.QuoteJobID, true);
                    withBlock.AddParameter("@PartID", oQuoteJobParts.PartID, true);
                    withBlock.AddParameter("@Quantity", oQuoteJobParts.Quantity, true);
                    withBlock.AddParameter("@BuyPrice", oQuoteJobParts.BuyPrice, true);
                    withBlock.AddParameter("@PartSupplierID", oQuoteJobParts.PartSupplierID, true);
                    if (oQuoteJobParts.SpecialDescription.Length == 0)
                    {
                        withBlock.AddParameter("@SpecialDescription", DBNull.Value, true);
                    }
                    else
                    {
                        withBlock.AddParameter("@SpecialDescription", oQuoteJobParts.SpecialDescription, true);
                    }

                    withBlock.AddParameter("@SpecialCost", oQuoteJobParts.SpecialCost, true);
                    withBlock.AddParameter("@Extra", oQuoteJobParts.Extra, true);
                }
            }

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}