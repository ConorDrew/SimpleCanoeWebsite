using System.Data;

namespace FSM.Entity
{
    namespace ContractOption3SitePPMVisits
    {
        public class ContractOption3SitePPMVisitSQL
        {
            private Sys.Database _database;

            public ContractOption3SitePPMVisitSQL(Sys.Database database)
            {
                _database = database;
            }

            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            public DataView ContractOption3SitePPMVisit_GetAll_ContractSiteID(int ContractSiteID)
            {
                _database.ClearParameter();
                _database.AddParameter("@ContractSiteID", ContractSiteID, true);
                var dt = _database.ExecuteSP_DataTable("ContractOption3SitePPMVisit_GetAll_ContractSiteID");
                dt.TableName = Sys.Enums.TableNames.tblContractOption3SitePPMVisit.ToString();
                return new DataView(dt);
            }

            public ContractOption3SitePPMVisit Insert(ContractOption3SitePPMVisit oContractOption3SitePPMVisit)
            {
                _database.ClearParameter();
                AddContractOption3SitePPMVisitParametersToCommand(ref oContractOption3SitePPMVisit);
                oContractOption3SitePPMVisit.SetContractSitePPMVisitID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("ContractOption3SitePPMVisit_Insert"));
                oContractOption3SitePPMVisit.Exists = true;
                return oContractOption3SitePPMVisit;
            }

            private void AddContractOption3SitePPMVisitParametersToCommand(ref ContractOption3SitePPMVisit oContractOption3SitePPMVisit)
            {
                {
                    var withBlock = _database;
                    withBlock.AddParameter("@ContractSiteID", oContractOption3SitePPMVisit.ContractSiteID, true);
                    withBlock.AddParameter("@VisitDate", oContractOption3SitePPMVisit.VisitDate, true);
                    withBlock.AddParameter("@JobID", oContractOption3SitePPMVisit.JobID, true);
                }
            }


            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}