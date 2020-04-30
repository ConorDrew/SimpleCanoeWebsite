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

            public ContractOriginalSiteRates ContractOriginalSiteRates_Get(int ContractOriginalSiteRateID)
            {
                _database.ClearParameter();
                _database.AddParameter("@ContractOriginalSiteRateID", ContractOriginalSiteRateID);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("ContractOriginalSiteRates_Get");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oContractOriginalSiteRates = new ContractOriginalSiteRates();
                        oContractOriginalSiteRates.IgnoreExceptionsOnSetMethods = true;
                        oContractOriginalSiteRates.SetContractOriginalSiteRateID = dt.Rows[0]["ContractOriginalSiteRateID"];
                        oContractOriginalSiteRates.SetContractSiteID = dt.Rows[0]["ContractSiteID"];
                        oContractOriginalSiteRates.SetRateID = dt.Rows[0]["RateID"];
                        oContractOriginalSiteRates.SetQty = dt.Rows[0]["Qty"];
                        oContractOriginalSiteRates.SetDeleted = Conversions.ToBoolean(dt.Rows[0]["Deleted"]);
                        oContractOriginalSiteRates.Exists = true;
                        return oContractOriginalSiteRates;
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

            public DataView ContractOriginalSiteRates_GetForContractSite(int ContractSiteID)
            {
                _database.ClearParameter();
                _database.AddParameter("@ContractSiteID", ContractSiteID);
                var dt = _database.ExecuteSP_DataTable("ContractOriginalSiteRates_GetForContractSite");
                dt.TableName = Sys.Enums.TableNames.tblContractOriginalSiteRates.ToString();
                return new DataView(dt);
            }

            public DataView ContractOriginalSiteRates_GetAll()
            {
                _database.ClearParameter();
                var dt = _database.ExecuteSP_DataTable("ContractOriginalSiteRates_GetAll");
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