// Decompiled with JetBrains decompiler
// Type: FSM.Entity.QuoteContractAlternativePPMVisits.QuoteContractAlternativePPMVisitSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM.Entity.QuoteContractAlternativePPMVisits
{
  public class QuoteContractAlternativePPMVisitSQL
  {
    private Database _database;

    public QuoteContractAlternativePPMVisitSQL(Database database)
    {
      this._database = database;
    }

    public DataView GetAll_For_QuoteContractSiteJobOfWorkID(int QuoteContractSiteJobOfWorkID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@QuoteContractSiteJobOfWorkID", (object) QuoteContractSiteJobOfWorkID, true);
      DataTable table = this._database.ExecuteSP_DataTable("QuoteContractAlternativePPMVisit_GetAll_For_QuoteContractSiteJobOfWorkID", true);
      table.TableName = Enums.TableNames.tblContractPPMVisit.ToString();
      return new DataView(table);
    }

    public QuoteContractAlternativePPMVisit Insert(
      QuoteContractAlternativePPMVisit oQuoteContractPPMVisit)
    {
      this._database.ClearParameter();
      this.AddQuoteContractPPMVisitParametersToCommand(ref oQuoteContractPPMVisit);
      oQuoteContractPPMVisit.SetQuoteContractPPMVisitID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("QuoteContractAlternativePPMVisit_Insert", true)));
      oQuoteContractPPMVisit.Exists = true;
      return oQuoteContractPPMVisit;
    }

    private void AddQuoteContractPPMVisitParametersToCommand(
      ref QuoteContractAlternativePPMVisit oQuoteContractPPMVisit)
    {
      Database database = this._database;
      database.AddParameter("@QuoteContractSiteJobOfWorkID", (object) oQuoteContractPPMVisit.QuoteContractSiteJobOfWorkID, true);
      database.AddParameter("@EstimatedVisitDate", (object) oQuoteContractPPMVisit.EstimatedVisitDate, true);
    }
  }
}
