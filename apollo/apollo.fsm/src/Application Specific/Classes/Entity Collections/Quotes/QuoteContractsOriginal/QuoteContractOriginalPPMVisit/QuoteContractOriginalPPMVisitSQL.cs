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

            private void AddQuoteContractPPMVisitParametersToCommand(ref QuoteContractOriginalPPMVisit oQuoteContractPPMVisit)
            {
                {
                    var withBlock = _database;
                    withBlock.AddParameter("@QuoteContractSiteID", oQuoteContractPPMVisit.QuoteContractSiteID, true);
                    withBlock.AddParameter("@EstimatedVisitDate", oQuoteContractPPMVisit.EstimatedVisitDate, true);
                }
            }
        }
    }
}