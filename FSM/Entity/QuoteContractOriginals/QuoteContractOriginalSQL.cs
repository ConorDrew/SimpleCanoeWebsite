// Decompiled with JetBrains decompiler
// Type: FSM.Entity.QuoteContractOriginals.QuoteContractOriginalSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM.Entity.QuoteContractOriginals
{
  public class QuoteContractOriginalSQL
  {
    private Database _database;

    public QuoteContractOriginalSQL(Database database)
    {
      this._database = database;
    }

    public DataTable VisitFrequency_Get()
    {
      this._database.ClearParameter();
      return this._database.ExecuteSP_DataTable(nameof (VisitFrequency_Get), true);
    }

    public QuoteContractOriginal Get(int QuoteContractID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@QuoteContractID", (object) QuoteContractID, false);
      DataTable dataTable = this._database.ExecuteSP_DataTable("QuoteContractOriginal_Get", true);
      if (dataTable == null || dataTable.Rows.Count <= 0)
        return (QuoteContractOriginal) null;
      QuoteContractOriginal contractOriginal1 = new QuoteContractOriginal();
      QuoteContractOriginal contractOriginal2 = contractOriginal1;
      contractOriginal2.IgnoreExceptionsOnSetMethods = true;
      contractOriginal2.SetQuoteContractID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0][nameof (QuoteContractID)]);
      contractOriginal2.SetCustomerID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CustomerID"]);
      contractOriginal2.SetQuoteContractReference = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["QuoteContractReference"]);
      contractOriginal2.QuoteContractDate = Conversions.ToDate(dataTable.Rows[0]["QuoteContractDate"]);
      contractOriginal2.ContractStart = Conversions.ToDate(dataTable.Rows[0]["ContractStart"]);
      contractOriginal2.ContractEnd = Conversions.ToDate(dataTable.Rows[0]["ContractEnd"]);
      contractOriginal2.SetQuoteContractStatusID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["QuoteContractStatusID"]);
      contractOriginal2.SetQuoteContractPrice = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["QuoteContractPrice"]);
      contractOriginal2.SetReasonForReject = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ReasonForReject"]);
      contractOriginal2.SetDeleted = Conversions.ToBoolean(dataTable.Rows[0]["Deleted"]);
      contractOriginal1.Exists = true;
      return contractOriginal1;
    }

    public double QuoteContractCalculatedTotal(int QuoteContractID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@QuoteContractID", (object) QuoteContractID, true);
      return Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("QuoteContractOriginalCalculatedTotal", true)));
    }

    public QuoteContractOriginal Insert(QuoteContractOriginal oQuoteContract)
    {
      this._database.ClearParameter();
      this.AddQuoteContractParametersToCommand(ref oQuoteContract);
      oQuoteContract.SetQuoteContractID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("QuoteContractOriginal_Insert", true)));
      oQuoteContract.Exists = true;
      return oQuoteContract;
    }

    public void Update(QuoteContractOriginal oQuoteContract)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@QuoteContractID", (object) oQuoteContract.QuoteContractID, true);
      this.AddQuoteContractParametersToCommand(ref oQuoteContract);
      this._database.ExecuteSP_NO_Return("QuoteContractOriginal_Update", true);
    }

    public void Delete(int QuoteContractID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@QuoteContractID", (object) QuoteContractID, true);
      this._database.ExecuteSP_NO_Return("QuoteContractOriginal_Delete", true);
    }

    private void AddQuoteContractParametersToCommand(ref QuoteContractOriginal oQuoteContract)
    {
      Database database = this._database;
      database.AddParameter("@CustomerID", (object) oQuoteContract.CustomerID, true);
      database.AddParameter("@QuoteContractReference", (object) oQuoteContract.QuoteContractReference, true);
      database.AddParameter("@QuoteContractDate", (object) oQuoteContract.QuoteContractDate, true);
      database.AddParameter("@ContractStart", (object) oQuoteContract.ContractStart, true);
      database.AddParameter("@ContractEnd", (object) oQuoteContract.ContractEnd, true);
      database.AddParameter("@QuoteContractStatusID", (object) oQuoteContract.QuoteContractStatusID, true);
      database.AddParameter("@QuoteContractPrice", (object) oQuoteContract.QuoteContractPrice, true);
      database.AddParameter("@ReasonForReject", (object) oQuoteContract.ReasonForReject, true);
    }
  }
}
