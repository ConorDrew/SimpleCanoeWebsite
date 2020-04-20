// Decompiled with JetBrains decompiler
// Type: FSM.Entity.QuoteContractAlternatives.QuoteContractAlternativeSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM.Entity.QuoteContractAlternatives
{
    public class QuoteContractAlternativeSQL
    {
        private Database _database;

        public QuoteContractAlternativeSQL(Database database)
        {
            this._database = database;
        }

        public double CalculatedTotal(int QuoteContractID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@QuoteContractID", (object)QuoteContractID, true);
            return Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("QuoteContractAlternativeCalculatedTotal", true)));
        }

        public DataTable VisitFrequency_Get()
        {
            this._database.ClearParameter();
            return this._database.ExecuteSP_DataTable(nameof(VisitFrequency_Get), true);
        }

        public QuoteContractAlternative Get(int QuoteContractID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@QuoteContractID", (object)QuoteContractID, false);
            DataTable dataTable = this._database.ExecuteSP_DataTable("QuoteContractAlternative_Get", true);
            if (dataTable == null || dataTable.Rows.Count <= 0)
                return (QuoteContractAlternative)null;
            QuoteContractAlternative contractAlternative1 = new QuoteContractAlternative();
            QuoteContractAlternative contractAlternative2 = contractAlternative1;
            contractAlternative2.IgnoreExceptionsOnSetMethods = true;
            contractAlternative2.SetQuoteContractID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0][nameof(QuoteContractID)]);
            contractAlternative2.SetCustomerID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CustomerID"]);
            contractAlternative2.SetQuoteContractReference = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["QuoteContractReference"]);
            contractAlternative2.QuoteContractDate = Conversions.ToDate(dataTable.Rows[0]["QuoteContractDate"]);
            contractAlternative2.ContractStart = Conversions.ToDate(dataTable.Rows[0]["ContractStart"]);
            contractAlternative2.ContractEnd = Conversions.ToDate(dataTable.Rows[0]["ContractEnd"]);
            contractAlternative2.SetQuoteContractStatusID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["QuoteContractStatusID"]);
            contractAlternative2.SetQuoteContractPrice = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["QuoteContractPrice"]);
            contractAlternative2.SetReasonForReject = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ReasonForReject"]);
            contractAlternative2.SetDeleted = Conversions.ToBoolean(dataTable.Rows[0]["Deleted"]);
            contractAlternative1.Exists = true;
            return contractAlternative1;
        }

        public QuoteContractAlternative Insert(
          QuoteContractAlternative oQuoteContract)
        {
            this._database.ClearParameter();
            this.AddQuoteContractParametersToCommand(ref oQuoteContract);
            oQuoteContract.SetQuoteContractID = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("QuoteContractAlternative_Insert", true)));
            oQuoteContract.Exists = true;
            return oQuoteContract;
        }

        public void Update(QuoteContractAlternative oQuoteContract)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@QuoteContractID", (object)oQuoteContract.QuoteContractID, true);
            this.AddQuoteContractParametersToCommand(ref oQuoteContract);
            this._database.ExecuteSP_NO_Return("QuoteContractAlternative_Update", true);
        }

        public void Delete(int QuoteContractID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@QuoteContractID", (object)QuoteContractID, true);
            this._database.ExecuteSP_NO_Return("QuoteContractAlternative_Delete", true);
        }

        private void AddQuoteContractParametersToCommand(ref QuoteContractAlternative oQuoteContract)
        {
            Database database = this._database;
            database.AddParameter("@CustomerID", (object)oQuoteContract.CustomerID, true);
            database.AddParameter("@QuoteContractReference", (object)oQuoteContract.QuoteContractReference, true);
            database.AddParameter("@QuoteContractDate", (object)oQuoteContract.QuoteContractDate, true);
            database.AddParameter("@ContractStart", (object)oQuoteContract.ContractStart, true);
            database.AddParameter("@ContractEnd", (object)oQuoteContract.ContractEnd, true);
            database.AddParameter("@QuoteContractStatusID", (object)oQuoteContract.QuoteContractStatusID, true);
            database.AddParameter("@QuoteContractPrice", (object)oQuoteContract.QuoteContractPrice, true);
            database.AddParameter("@ReasonForReject", (object)oQuoteContract.ReasonForReject, true);
        }
    }
}