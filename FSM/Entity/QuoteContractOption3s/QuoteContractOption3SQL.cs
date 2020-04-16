// Decompiled with JetBrains decompiler
// Type: FSM.Entity.QuoteContractOption3s.QuoteContractOption3SQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM.Entity.QuoteContractOption3s
{
  public class QuoteContractOption3SQL
  {
    private Database _database;

    public QuoteContractOption3SQL(Database database)
    {
      this._database = database;
    }

    public DataTable VisitFrequency_Get()
    {
      this._database.ClearParameter();
      return this._database.ExecuteSP_DataTable("VisitFrequencyOption3_Get", true);
    }

    public DataTable InvoiceFrequency_Get()
    {
      this._database.ClearParameter();
      return this._database.ExecuteSP_DataTable(nameof (InvoiceFrequency_Get), true);
    }

    public void Delete(int QuoteContractID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@QuoteContractID", (object) QuoteContractID, true);
      this._database.ExecuteSP_NO_Return("QuoteContractOption3_Delete", true);
    }

    public QuoteContractOption3 QuoteContractOption3_Get(int QuoteContractID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@QuoteContractID", (object) QuoteContractID, false);
      DataTable dataTable = this._database.ExecuteSP_DataTable(nameof (QuoteContractOption3_Get), true);
      if (dataTable == null || dataTable.Rows.Count <= 0)
        return (QuoteContractOption3) null;
      QuoteContractOption3 quoteContractOption3_1 = new QuoteContractOption3();
      QuoteContractOption3 quoteContractOption3_2 = quoteContractOption3_1;
      quoteContractOption3_2.IgnoreExceptionsOnSetMethods = true;
      quoteContractOption3_2.SetQuoteContractID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0][nameof (QuoteContractID)]);
      quoteContractOption3_2.SetCustomerID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CustomerID"]);
      quoteContractOption3_2.SetQuoteContractReference = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["QuoteContractReference"]);
      quoteContractOption3_2.SetQuoteContractStatusID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["QuoteContractStatusID"]);
      quoteContractOption3_2.QuoteContractDate = Conversions.ToDate(dataTable.Rows[0]["QuoteContractDate"]);
      quoteContractOption3_2.SetQuoteContractPrice = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["QuoteContractPrice"]);
      quoteContractOption3_2.SetReasonForReject = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ReasonForReject"]);
      quoteContractOption3_1.Exists = true;
      return quoteContractOption3_1;
    }

    public DataView QuoteContractOption3_GetAll()
    {
      this._database.ClearParameter();
      DataTable table = this._database.ExecuteSP_DataTable(nameof (QuoteContractOption3_GetAll), true);
      table.TableName = Enums.TableNames.tblQuoteContractOption3.ToString();
      return new DataView(table);
    }

    public QuoteContractOption3 Insert(
      QuoteContractOption3 oQuoteContractOption3)
    {
      this._database.ClearParameter();
      this.AddQuoteContractOption3ParametersToCommand(ref oQuoteContractOption3);
      oQuoteContractOption3.SetQuoteContractID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("QuoteContractOption3_Insert", true)));
      oQuoteContractOption3.Exists = true;
      return oQuoteContractOption3;
    }

    public void Update(QuoteContractOption3 oQuoteContractOption3)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@QuoteContractID", (object) oQuoteContractOption3.QuoteContractID, true);
      this.AddQuoteContractOption3ParametersToCommand(ref oQuoteContractOption3);
      this._database.ExecuteSP_NO_Return("QuoteContractOption3_Update", true);
    }

    private void AddQuoteContractOption3ParametersToCommand(
      ref QuoteContractOption3 oQuoteContractOption3)
    {
      Database database = this._database;
      database.AddParameter("@CustomerID", (object) oQuoteContractOption3.CustomerID, true);
      database.AddParameter("@QuoteContractReference", (object) oQuoteContractOption3.QuoteContractReference, true);
      database.AddParameter("@QuoteContractStatusID", (object) oQuoteContractOption3.QuoteContractStatusID, true);
      database.AddParameter("@QuoteContractDate", (object) oQuoteContractOption3.QuoteContractDate, true);
      database.AddParameter("@QuoteContractPrice", (object) oQuoteContractOption3.QuoteContractPrice, true);
      database.AddParameter("@ReasonForReject", (object) oQuoteContractOption3.ReasonForReject, true);
    }

    public double QuoteContractCalculatedTotal(int QuoteContractID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@QuoteContractID", (object) QuoteContractID, true);
      return Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("QuoteContractOption3CalculatedTotal", true)));
    }
  }
}
