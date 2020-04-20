using System.Data;

namespace FSM.Entity
{
    namespace QuoteContractAlternativePPMVisits
    {
        public class QuoteContractAlternativePPMVisitSQL
        {
            private Sys.Database _database;

            public QuoteContractAlternativePPMVisitSQL(Sys.Database database)
            {
                _database = database;
            }

            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            public DataView GetAll_For_QuoteContractSiteJobOfWorkID(int QuoteContractSiteJobOfWorkID)
            {
                _database.ClearParameter();
                _database.AddParameter("@QuoteContractSiteJobOfWorkID", QuoteContractSiteJobOfWorkID, true);
                var dt = _database.ExecuteSP_DataTable("QuoteContractAlternativePPMVisit_GetAll_For_QuoteContractSiteJobOfWorkID");
                dt.TableName = Sys.Enums.TableNames.tblContractPPMVisit.ToString();
                return new DataView(dt);
            }

            public QuoteContractAlternativePPMVisit Insert(QuoteContractAlternativePPMVisit oQuoteContractPPMVisit)
            {
                _database.ClearParameter();
                AddQuoteContractPPMVisitParametersToCommand(ref oQuoteContractPPMVisit);
                oQuoteContractPPMVisit.SetQuoteContractPPMVisitID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("QuoteContractAlternativePPMVisit_Insert"));
                oQuoteContractPPMVisit.Exists = true;
                return oQuoteContractPPMVisit;
            }

            private void AddQuoteContractPPMVisitParametersToCommand(ref QuoteContractAlternativePPMVisit oQuoteContractPPMVisit)
            {
                {
                    var withBlock = _database;
                    withBlock.AddParameter("@QuoteContractSiteJobOfWorkID", oQuoteContractPPMVisit.QuoteContractSiteJobOfWorkID, true);
                    withBlock.AddParameter("@EstimatedVisitDate", oQuoteContractPPMVisit.EstimatedVisitDate, true);
                }
            }
            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}