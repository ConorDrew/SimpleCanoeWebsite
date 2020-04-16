// Decompiled with JetBrains decompiler
// Type: FSM.Entity.ContractManager.ContractManagerSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using System;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM.Entity.ContractManager
{
    public class ContractManagerSQL
    {
        private Database _database;

        public ContractManagerSQL(Database database)
        {
            this._database = database;
        }

        public DataView Contracts_GetAll(DateTime datefrom)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@ContractType1Enum", (object)1, true);
            this._database.AddParameter("@ContractType2Enum", (object)2, true);
            this._database.AddParameter("@ContractType3Enum", (object)4, true);
            this._database.AddParameter("@UploadStatusEnum", (object)7, true);
            this._database.AddParameter("@DateFrom", (object)datefrom, true);
            DataTable table = this._database.ExecuteSP_DataTable("Contracts_GetAll_Mk1", true);
            table.TableName = Enums.TableNames.tblContract.ToString();
            return new DataView(table);
        }

        public void ContractRenewalsInsert(int oldContractID, int newContractID, int ContractTypeID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@oldContractID", (object)oldContractID, true);
            this._database.AddParameter("@newContractID", (object)newContractID, true);
            this._database.AddParameter("@ContractTypeID", (object)ContractTypeID, true);
            App.DB.ExecuteSP_NO_Return(nameof(ContractRenewalsInsert), true);
        }

        public int ContractRenewals_GetNewID_ByOldID(int oldContractID, int ContractTypeID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@oldContractID", (object)oldContractID, true);
            this._database.AddParameter("@ContractTypeID", (object)ContractTypeID, true);
            return Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(App.DB.ExecuteSP_OBJECT(nameof(ContractRenewals_GetNewID_ByOldID), true)));
        }

        public DataView ContractRenewal_AlternativeSitesJobOfWorks(int ContractID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@ContractID", (object)ContractID, true);
            DataTable table = this._database.ExecuteSP_DataTable(nameof(ContractRenewal_AlternativeSitesJobOfWorks), true);
            table.TableName = Enums.TableNames.NO_TABLE.ToString();
            return new DataView(table);
        }

        public DataView Contracts_GetAddresses(string ContractIDs)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@ContractIDs", (object)ContractIDs, true);
            DataTable table = this._database.ExecuteSP_DataTable(nameof(Contracts_GetAddresses), true);
            table.TableName = Enums.TableNames.NO_TABLE.ToString();
            return new DataView(table);
        }
    }
}