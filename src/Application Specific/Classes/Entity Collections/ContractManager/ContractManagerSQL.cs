using System;
using System.Data;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace ContractManager
    {
        public class ContractManagerSQL
        {
            private Sys.Database _database;

            public ContractManagerSQL(Sys.Database database)
            {
                _database = database;
            }

            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            public DataView Contracts_GetAll(DateTime datefrom)
            {
                _database.ClearParameter();
                _database.AddParameter("@ContractType1Enum", Conversions.ToInteger(Sys.Enums.QuoteType.Contract_Opt_1), true);
                _database.AddParameter("@ContractType2Enum", Conversions.ToInteger(Sys.Enums.QuoteType.Contract_Opt_2), true);
                _database.AddParameter("@ContractType3Enum", Conversions.ToInteger(Sys.Enums.QuoteType.Contract_Opt_3), true);
                _database.AddParameter("@UploadStatusEnum", Conversions.ToInteger(Sys.Enums.VisitStatus.Uploaded), true);
                _database.AddParameter("@DateFrom", datefrom, true);
                var dt = _database.ExecuteSP_DataTable("Contracts_GetAll_Mk1");
                dt.TableName = Sys.Enums.TableNames.tblContract.ToString();
                return new DataView(dt);
            }

            public void ContractRenewalsInsert(int oldContractID, int newContractID, int ContractTypeID)
            {
                _database.ClearParameter();
                _database.AddParameter("@oldContractID", oldContractID, true);
                _database.AddParameter("@newContractID", newContractID, true);
                _database.AddParameter("@ContractTypeID", ContractTypeID, true);
                App.DB.ExecuteSP_NO_Return("ContractRenewalsInsert");
            }

            public int ContractRenewals_GetNewID_ByOldID(int oldContractID, int ContractTypeID)
            {
                _database.ClearParameter();
                _database.AddParameter("@oldContractID", oldContractID, true);
                _database.AddParameter("@ContractTypeID", ContractTypeID, true);
                return Sys.Helper.MakeIntegerValid(App.DB.ExecuteSP_OBJECT("ContractRenewals_GetNewID_ByOldID"));
            }

            public DataView ContractRenewal_AlternativeSitesJobOfWorks(int ContractID)
            {
                _database.ClearParameter();
                _database.AddParameter("@ContractID", ContractID, true);
                var dt = _database.ExecuteSP_DataTable("ContractRenewal_AlternativeSitesJobOfWorks");
                dt.TableName = Sys.Enums.TableNames.NO_TABLE.ToString();
                return new DataView(dt);
            }

            public DataView Contracts_GetAddresses(string ContractIDs)
            {
                _database.ClearParameter();
                _database.AddParameter("@ContractIDs", ContractIDs, true);
                var dt = _database.ExecuteSP_DataTable("Contracts_GetAddresses");
                dt.TableName = Sys.Enums.TableNames.NO_TABLE.ToString();
                return new DataView(dt);
            }

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}