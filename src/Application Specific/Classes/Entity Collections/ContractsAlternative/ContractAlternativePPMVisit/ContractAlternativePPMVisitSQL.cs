using System.Data;

namespace FSM.Entity
{
    namespace ContractAlternativePPMVisits
    {
        public class ContractAlternativePPMVisitSQL
        {
            private Sys.Database _database;

            public ContractAlternativePPMVisitSQL(Sys.Database database)
            {
                _database = database;
            }

            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            public DataView GetAll_For_ContractSiteJobOfWorkID(int ContractSiteJobOfWorkID)
            {
                _database.ClearParameter();
                _database.AddParameter("@ContractSiteJobOfWorkID", ContractSiteJobOfWorkID, true);
                var dt = _database.ExecuteSP_DataTable("ContractAlternativePPMVisit_GetAll_For_ContractSiteJobOfWorkID");
                dt.TableName = Sys.Enums.TableNames.tblContractPPMVisit.ToString();
                return new DataView(dt);
            }

            public ContractAlternativePPMVisit Insert(ContractAlternativePPMVisit oContractPPMVisit)
            {
                _database.ClearParameter();
                AddContractPPMVisitParametersToCommand(ref oContractPPMVisit);
                oContractPPMVisit.SetContractPPMVisitID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("ContractAlternativePPMVisit_Insert"));
                oContractPPMVisit.Exists = true;
                return oContractPPMVisit;
            }

            private void AddContractPPMVisitParametersToCommand(ref ContractAlternativePPMVisit oContractPPMVisit)
            {
                {
                    var withBlock = _database;
                    withBlock.AddParameter("@ContractSiteJobOfWorkID", oContractPPMVisit.ContractSiteJobOfWorkID, true);
                    withBlock.AddParameter("@EstimatedVisitDate", oContractPPMVisit.EstimatedVisitDate, true);
                    withBlock.AddParameter("@JobID", oContractPPMVisit.JobID, true);
                }
            }
            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}