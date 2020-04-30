using System.Data;

namespace FSM.Entity
{
    namespace ContractOriginalPPMVisits
    {
        public class ContractOriginalPPMVisitSQL
        {
            private Sys.Database _database;

            public ContractOriginalPPMVisitSQL(Sys.Database database)
            {
                _database = database;
            }

            
            public DataView GetAll_For_ContractSiteID(int ContractSiteID)
            {
                _database.ClearParameter();
                _database.AddParameter("@ContractSiteID", ContractSiteID, true);
                var dt = _database.ExecuteSP_DataTable("ContractOriginalPPMVisit_GetAll_For_ContractSiteID");
                dt.TableName = Sys.Enums.TableNames.tblContractPPMVisit.ToString();
                return new DataView(dt);
            }

            public DataView GetAllAssets_For_ContractSiteID(int ContractSiteID)
            {
                _database.ClearParameter();
                _database.AddParameter("@ContractSiteID", ContractSiteID, true);
                var dt = _database.ExecuteSP_DataTable("ContractOriginalPPMVisit_Assets_GetAll_For_ContractSiteID");
                dt.TableName = Sys.Enums.TableNames.tblContractPPMVisit.ToString();
                return new DataView(dt);
            }

            public ContractOriginalPPMVisit Insert(ContractOriginalPPMVisit oContractPPMVisit)
            {
                _database.ClearParameter();
                AddContractPPMVisitParametersToCommand(ref oContractPPMVisit);
                oContractPPMVisit.SetContractPPMVisitID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("ContractOriginalPPMVisit_Insert"));
                oContractPPMVisit.Exists = true;
                return oContractPPMVisit;
            }

            private void AddContractPPMVisitParametersToCommand(ref ContractOriginalPPMVisit oContractPPMVisit)
            {
                {
                    var withBlock = _database;
                    withBlock.AddParameter("@ContractSiteID", oContractPPMVisit.ContractSiteID, true);
                    withBlock.AddParameter("@EstimatedVisitDate", oContractPPMVisit.EstimatedVisitDate, true);
                    withBlock.AddParameter("@JobID", oContractPPMVisit.JobID, true);
                }
            }
            
        }
    }
}