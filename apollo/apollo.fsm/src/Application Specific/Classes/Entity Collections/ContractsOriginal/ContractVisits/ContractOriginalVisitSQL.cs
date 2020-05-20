using System.Data;

namespace FSM.Entity
{
    namespace ContractOriginalVisits
    {
        public class ContractOriginalVisitSQL
        {
            private Sys.Database _database;

            public ContractOriginalVisitSQL(Sys.Database database)
            {
                _database = database;
            }

            
            public DataView GetAll_For_ContractSiteID(int ContractSiteID)
            {
                _database.ClearParameter();
                _database.AddParameter("@ContractSiteID", ContractSiteID, true);
                var dt = _database.ExecuteSP_DataTable("ContractOriginalVisit_GetAll_For_ContractSiteID");
                dt.TableName = "ContractOriginalVisit";
                return new DataView(dt);
            }

            public ContractOriginalVisit Insert(ContractOriginalVisit oContractVisit)
            {
                _database.ClearParameter();
                AddContractVisitParametersToCommand(ref oContractVisit);
                oContractVisit.SetContractVisitID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("ContractOriginalVisit_Insert"));
                oContractVisit.Exists = true;
                return oContractVisit;
            }

            public void Delete(int ContractVisitID)
            {
                _database.ClearParameter();
                _database.AddParameter("@ContractVisitID", ContractVisitID, true);
                _database.ExecuteSP_NO_Return("ContractOriginalVisit_Delete");
            }

            private void AddContractVisitParametersToCommand(ref ContractOriginalVisit oContractVisit)
            {
                {
                    var withBlock = _database;
                    withBlock.AddParameter("@ContractSiteID", oContractVisit.ContractSiteID, true);
                    withBlock.AddParameter("@VisitDate", oContractVisit.EstimatedVisitDate, true);
                    withBlock.AddParameter("@JobID", oContractVisit.JobID, true);
                    withBlock.AddParameter("@Cost", oContractVisit.Cost, true);
                    withBlock.AddParameter("@SubcontractorID", oContractVisit.SubContractorID, true);
                    withBlock.AddParameter("@PreferredEngineerID", oContractVisit.PreferredEngineerID, true);
                    withBlock.AddParameter("@VisitTypeID", oContractVisit.VisitTypeID, true);
                    withBlock.AddParameter("@FrequencyID", oContractVisit.FrequencyID, true);
                    withBlock.AddParameter("@Frequency", oContractVisit.Frequency, true);
                    withBlock.AddParameter("@SubContractor", oContractVisit.SubContractor, true);
                    withBlock.AddParameter("@PreferredEngineer", oContractVisit.PreferredEngineer, true);
                    withBlock.AddParameter("@VisitType", oContractVisit.VisitType, true);
                    withBlock.AddParameter("@HoursReq", oContractVisit.HoursReq, true);
                    withBlock.AddParameter("@AdditionalNotes", oContractVisit.AdditionalNotes, true);
                }
            }
            
        }
    }
}