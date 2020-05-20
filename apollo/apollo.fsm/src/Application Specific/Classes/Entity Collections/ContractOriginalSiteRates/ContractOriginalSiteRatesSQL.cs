using System.Data;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace ContractOriginalSiteRatess
    {
        public class ContractOriginalSiteRatesSQL
        {
            private Sys.Database _database;

            public ContractOriginalSiteRatesSQL(Sys.Database database)
            {
                _database = database;
            }

            public void Delete(int ContractOriginalSiteRateID)
            {
                _database.ClearParameter();
                _database.AddParameter("@ContractOriginalSiteRateID", ContractOriginalSiteRateID, true);
                _database.ExecuteSP_NO_Return("ContractOriginalSiteRates_Delete");
            }

            public DataView ContractOriginalSiteRates_GetForContractSite(int ContractSiteID)
            {
                _database.ClearParameter();
                _database.AddParameter("@ContractSiteID", ContractSiteID);
                var dt = _database.ExecuteSP_DataTable("ContractOriginalSiteRates_GetForContractSite");
                dt.TableName = Sys.Enums.TableNames.tblContractOriginalSiteRates.ToString();
                return new DataView(dt);
            }

            public ContractOriginalSiteRates Insert(ContractOriginalSiteRates oContractOriginalSiteRates)
            {
                _database.ClearParameter();
                AddContractOriginalSiteRatesParametersToCommand(ref oContractOriginalSiteRates);
                oContractOriginalSiteRates.SetContractOriginalSiteRateID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("ContractOriginalSiteRates_Insert"));
                oContractOriginalSiteRates.Exists = true;
                return oContractOriginalSiteRates;
            }

            public void Update(ContractOriginalSiteRates oContractOriginalSiteRates)
            {
                _database.ClearParameter();
                _database.AddParameter("@ContractOriginalSiteRateID", oContractOriginalSiteRates.ContractOriginalSiteRateID, true);
                AddContractOriginalSiteRatesParametersToCommand(ref oContractOriginalSiteRates);
                _database.ExecuteSP_NO_Return("ContractOriginalSiteRates_Update");
            }

            private void AddContractOriginalSiteRatesParametersToCommand(ref ContractOriginalSiteRates oContractOriginalSiteRates)
            {
                {
                    var withBlock = _database;
                    withBlock.AddParameter("@ContractSiteID", oContractOriginalSiteRates.ContractSiteID, true);
                    withBlock.AddParameter("@RateID", oContractOriginalSiteRates.RateID, true);
                    withBlock.AddParameter("@Qty", oContractOriginalSiteRates.Qty, true);
                }
            }
        }
    }
}