using System.Data;

namespace FSM.Entity
{
    namespace QuoteContractOriginalPPMVisits
    {
        public class QuoteContractOriginalPPMVisitSQL
        {
            private Sys.Database _database;

            public QuoteContractOriginalPPMVisitSQL(Sys.Database database)
            {
                _database = database;
            }

            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            public DataView GetAll_For_QuoteContractSiteID(int QuoteContractSiteID)
            {
                _database.ClearParameter();
                _database.AddParameter("@QuoteContractSiteID", QuoteContractSiteID, true);
                var dt = _database.ExecuteSP_DataTable("QuoteContractOriginalPPMVisit_GetAll_For_QuoteContractSiteID");
                dt.TableName = Sys.Enums.TableNames.tblQuoteContractPPMVisit.ToString();
                return new DataView(dt);
            }

            public QuoteContractOriginalPPMVisit Insert(QuoteContractOriginalPPMVisit oQuoteContractPPMVisit)
            {
                _database.ClearParameter();
                AddQuoteContractPPMVisitParametersToCommand(ref oQuoteContractPPMVisit);
                oQuoteContractPPMVisit.SetQuoteContractPPMVisitID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("QuoteContractOriginalPPMVisit_Insert"));
                oQuoteContractPPMVisit.Exists = true;
                return oQuoteContractPPMVisit;
            }

            private void AddQuoteContractPPMVisitParametersToCommand(ref QuoteContractOriginalPPMVisit oQuoteContractPPMVisit)
            {
                {
                    var withBlock = _database;
                    withBlock.AddParameter("@QuoteContractSiteID", oQuoteContractPPMVisit.QuoteContractSiteID, true);
                    withBlock.AddParameter("@EstimatedVisitDate", oQuoteContractPPMVisit.EstimatedVisitDate, true);
                }
            }

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}