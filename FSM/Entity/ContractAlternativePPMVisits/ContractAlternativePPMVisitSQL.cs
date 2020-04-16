// Decompiled with JetBrains decompiler
// Type: FSM.Entity.ContractAlternativePPMVisits.ContractAlternativePPMVisitSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM.Entity.ContractAlternativePPMVisits
{
  public class ContractAlternativePPMVisitSQL
  {
    private Database _database;

    public ContractAlternativePPMVisitSQL(Database database)
    {
      this._database = database;
    }

    public DataView GetAll_For_ContractSiteJobOfWorkID(int ContractSiteJobOfWorkID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@ContractSiteJobOfWorkID", (object) ContractSiteJobOfWorkID, true);
      DataTable table = this._database.ExecuteSP_DataTable("ContractAlternativePPMVisit_GetAll_For_ContractSiteJobOfWorkID", true);
      table.TableName = Enums.TableNames.tblContractPPMVisit.ToString();
      return new DataView(table);
    }

    public ContractAlternativePPMVisit Insert(
      ContractAlternativePPMVisit oContractPPMVisit)
    {
      this._database.ClearParameter();
      this.AddContractPPMVisitParametersToCommand(ref oContractPPMVisit);
      oContractPPMVisit.SetContractPPMVisitID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("ContractAlternativePPMVisit_Insert", true)));
      oContractPPMVisit.Exists = true;
      return oContractPPMVisit;
    }

    private void AddContractPPMVisitParametersToCommand(
      ref ContractAlternativePPMVisit oContractPPMVisit)
    {
      Database database = this._database;
      database.AddParameter("@ContractSiteJobOfWorkID", (object) oContractPPMVisit.ContractSiteJobOfWorkID, true);
      database.AddParameter("@EstimatedVisitDate", (object) oContractPPMVisit.EstimatedVisitDate, true);
      database.AddParameter("@JobID", (object) oContractPPMVisit.JobID, true);
    }
  }
}
